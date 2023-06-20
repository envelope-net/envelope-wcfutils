using Envelope.Logging.Extensions;
using Envelope.Serializer;
using Envelope.Trace;
using Microsoft.Extensions.Logging;
using Envelope.WcfUtils.Saml2.DataStore;
using Envelope.WcfUtils.Saml2.Events;
using Envelope.WcfUtils.Saml2.Helpers;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Pipelines;
using Envelope.WcfUtils.Saml2.Security;
using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.Controllers;

public class Saml2ServiceProviderController
{
	private readonly ILogger _logger;
	public event Saml2MessageEventHandler? MessageCreated;

	public Saml2ServiceProviderController(ILogger logger)
	{
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
	}

	/// <summary>
	/// Odosle prihlasovaci AuthnRequest na IDP
	/// </summary>
	internal Saml2MessageModel SingIn(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		UserDataStore store)
	{
		traceInfo = TraceInfo.Create(traceInfo);
		_logger.LogTraceMessage(traceInfo, x => x.Detail(nameof(SingIn)));

		var sender = new SendPipeline(_logger);
		sender.MessageCreated += message =>
		{
			var messageCreated = MessageCreated;
			if (messageCreated == null)
				return;

			messageCreated(this, new Saml2MessageEventArgs(message));
		};

		var saml2MessageModel = sender.SendMessage(
			traceInfo,
			Saml2MessageTypeEnum.AuthnRequest,
			MessageHelper.BINDINGS_HTTPRedirect,
			context);

		store.SetExpirable(context, Saml2ControllerHelper.GetStoredAuthnRequestIDKey(saml2MessageModel.Message.ID), saml2MessageModel.Message.ID);
		return saml2MessageModel;
	}

	/// <summary>
	/// Odosle prihlasovaci AuthnRequest na IDP
	/// </summary>
	internal Saml2MessageModel RenewSignIn(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		UserDataStore store)
	{
		traceInfo = TraceInfo.Create(traceInfo);
		_logger.LogTraceMessage(traceInfo, x => x.Detail(nameof(RenewSignIn)));

		var sender = new SendPipeline(_logger);

		sender.MessageCreated += message =>
		{
			if (message is AuthnRequestType authnRequestType2)
			{
				if (context.Config.OutgoingMessages?.RenewUseForceAuthn == true)
				{
					authnRequestType2.ForceAuthn = true;
					authnRequestType2.ForceAuthnSpecified = true;
				}
				authnRequestType2.IsPassive = true;
				authnRequestType2.IsPassiveSpecified = true;
			}

			MessageCreated?.Invoke(this, new Saml2MessageEventArgs(message));
		};

		var saml2MessageModel = sender.SendMessage(
			traceInfo,
			Saml2MessageTypeEnum.AuthnRequest,
			MessageHelper.BINDINGS_HTTPRedirect,
			context);

		store.SetExpirable(context, Saml2ControllerHelper.GetStoredAuthnRequestIDKey(saml2MessageModel.Message.ID), saml2MessageModel.Message.ID);
		return saml2MessageModel;
	}

	/// <summary>
	/// Odosle prihlasovaci AuthnRequest na IDP
	/// </summary>
	internal Saml2MessageModel CheckSignIn(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		UserDataStore store)
	{
		traceInfo = TraceInfo.Create(traceInfo);
		_logger.LogTraceMessage(traceInfo, x => x.Detail(nameof(CheckSignIn)));

		var sender = new SendPipeline(_logger);

		sender.MessageCreated += message =>
		{
			if (message is AuthnRequestType authnRequestType2)
			{
				if (context.Config.OutgoingMessages?.RenewUseForceAuthn == true)
				{
					authnRequestType2.ForceAuthn = false;
					authnRequestType2.ForceAuthnSpecified = false;
				}
				authnRequestType2.IsPassive = true;
				authnRequestType2.IsPassiveSpecified = true;
			}

			MessageCreated?.Invoke(this, new Saml2MessageEventArgs(message));
		};

		var saml2MessageModel = sender.SendMessage(
			traceInfo,
			Saml2MessageTypeEnum.AuthnRequest,
			MessageHelper.BINDINGS_HTTPRedirect,
			context);

		store.SetExpirable(context, Saml2ControllerHelper.GetStoredAuthnRequestIDKey(saml2MessageModel.Message.ID), saml2MessageModel.Message.ID);
		return saml2MessageModel;
	}

	/// <summary>
	/// Odosle odhlasovaci LogoutRequest
	/// </summary>
	internal Saml2MessageModel SingOut(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		UserDataStore store)
	{
		traceInfo = TraceInfo.Create(traceInfo);
		_logger.LogTraceMessage(traceInfo, x => x.Detail(nameof(SingOut)));

		var samlPrincipal = context.Principal as ISaml2Principal ?? throw new InvalidOperationException($"Single logout not possible: Current user is not {nameof(ISaml2Principal)}");
		var sender = new SendPipeline(_logger);

		sender.MessageCreated += message =>
		{
			var logoutRequestType = (LogoutRequestType)message;
			logoutRequestType.SessionIndex = new string[1]
			{
				samlPrincipal.SessionIndex
			};

			logoutRequestType.Item = Saml2ControllerHelper.GetTicketNameID(context)!;
		};

		var saml2MessageModel = sender.SendMessage(
			traceInfo,
			Saml2MessageTypeEnum.LogoutRequest,
			MessageHelper.BINDINGS_HTTPRedirect,
			context);

		store.SetExpirable(context, Saml2ControllerHelper.GetStoredLogoutRequestIDKey(saml2MessageModel.Message.ID), saml2MessageModel.Message.ID);
		return saml2MessageModel;
	}

	/// <summary>
	/// Precita a spracuje prichadzajucu saml spravu
	/// </summary>
	/// <returns>prichadzajuca saml sprava</returns>
	internal ISaml2Message ProcessIncommingMessage(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		UserDataStore store)
	{
		traceInfo = TraceInfo.Create(traceInfo);
		_logger.LogTraceMessage(traceInfo, x => x.Detail(nameof(ProcessIncommingMessage)));

		var saml2Message = new ReceivePipeline(_logger).ReadMessage(traceInfo, context);

		switch (saml2Message)
		{
			case RequestAbstractType request:
				ProcessRequest(traceInfo, context, request, store);
				return saml2Message;
			case StatusResponseType response:
				ProcessResponse(traceInfo, context, response, store);
				return saml2Message;
			default:
				throw new NotSupportedException($"Message type not supported: {saml2Message?.GetType().Name ?? "NULL"}");
		}
	}

	/// <summary>
	/// Spracuje saml spravu typu request
	/// </summary>
	/// <returns>prichadzajuca saml sprava</returns>
	private Saml2MessageModel ProcessRequest(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		RequestAbstractType request,
		UserDataStore store)
	{
		traceInfo = TraceInfo.Create(traceInfo);
		_logger.LogTraceMessage(traceInfo, x => x.Detail(nameof(ProcessRequest)));

		var logoutRequest = request as LogoutRequestType ?? throw new InvalidOperationException($"Request message type not supported: {request?.GetType().Name ?? "NULL"}");
		var sender = new SendPipeline(_logger);

		bool success = ProcessLogoutRequest(traceInfo, context, logoutRequest);
		sender.MessageCreated += msg =>
		{
			var logoutResponseType = (LogoutResponseType)msg;
			logoutResponseType.InResponseTo = logoutRequest.ID;
			logoutResponseType.StatusCode = success ? MessageHelper.STATUS_SUCCESS : MessageHelper.STATUS_RESPONDER;
		};

		var saml2MessageModel = sender.SendMessage(
			traceInfo,
			Saml2MessageTypeEnum.LogoutResponse,
			MessageHelper.BINDINGS_HTTPRedirect,
			context);

		if (!success)
			throw new InvalidOperationException($"single logout not possible: Current user is not {nameof(ISaml2Principal)}");

		return saml2MessageModel;
	}

	/// <summary>
	/// Spracuje saml spravu typu response
	/// </summary>
	/// <returns>prichadzajuca saml sprava</returns>
	private void ProcessResponse(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		ISaml2ResponseMessage response,
		UserDataStore store)
	{
		traceInfo = TraceInfo.Create(traceInfo);
		_logger.LogTraceMessage(traceInfo, x => x.Detail(nameof(ProcessResponse)));

		if (response.StatusCode != MessageHelper.STATUS_SUCCESS && !MessageHelper.HasNoPassiveStatusCode(response))
			throw new InvalidOperationException($"Response status code is not Success: {response.StatusCode}");

		string? key = null;
		if (response is ResponseType)
			key = Saml2ControllerHelper.GetStoredAuthnRequestIDKey(response.InResponseTo);

		if (response is LogoutResponseType)
			key = Saml2ControllerHelper.GetStoredLogoutRequestIDKey(response.InResponseTo);

		string? str = null;

		if (!string.IsNullOrEmpty(key))
			str = store.Get<string>(context, key);

		if (string.IsNullOrEmpty(str))
		{
			_logger.LogDebugMessage(traceInfo, x => x.Detail($"Request {response.InResponseTo} was not found in cache for the response: {response.ID}{Environment.NewLine}Response: " + XmlSerializerHelper.SerializeToString(response)));
			throw new InvalidOperationException($"Request {response.InResponseTo} was not found in cache for the response: {response.ID}");
		}

		var responseStatus = MessageHelper.GetResponseStatus(response);

		if (responseStatus != MessageHelper.STATUS_SUCCESS && !MessageHelper.HasNoPassiveStatusCode(response))
			throw new InvalidOperationException($"Response status is: {responseStatus}");

		store.Clear(key!);

		if (MessageHelper.HasNoPassiveStatusCode(response))
			return;

		if (response is ResponseType responseType)
		{
			ProcessAssertion(context, store, responseType.Assertion);
			store.Store(context);
		}
		else
		{
			store.Store(context);
		}
	}

	/// <summary>
	/// Spracuje prichadzajucy spravu typu assertion
	/// </summary>
	private static void ProcessAssertion(
		ISaml2ModuleContext context,
		UserDataStore store,
		AssertionType? assertion)
	{
		store.Set(context, UserDataStore.SESSION_INDEX, assertion?.AuthnStatement?.SessionIndex);
	}

	/// <summary>
	/// Spracovanie saml spravy typu logout request
	/// </summary>
	/// <param name="logoutRequest">saml sprava typu logout request</param>
	/// <returns>status pre odoslanie odpovede na tento request</returns>
	private bool ProcessLogoutRequest(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		LogoutRequestType logoutRequest)
	{
		traceInfo = TraceInfo.Create(traceInfo);

		if (context.Principal is not ISaml2Principal)
		{
			_logger.LogWarningMessage(traceInfo, x => x.Detail($"HttpContext.Current.User is not {nameof(ISaml2Principal)}, may be expired."));
			return true;
		}

		var ticketNameId = Saml2ControllerHelper.GetTicketNameID(context);

		return logoutRequest.Item is NameIDType nameIdType
			&& ticketNameId?.Value == nameIdType.Value
			&& ticketNameId?.Format == nameIdType.Format
			&& ticketNameId?.NameQualifier == nameIdType.NameQualifier
			&& ticketNameId?.SPNameQualifier == nameIdType.SPNameQualifier;
	}
}
