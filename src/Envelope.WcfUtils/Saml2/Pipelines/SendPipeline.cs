using Envelope.Logging.Extensions;
using Envelope.Trace;
using Microsoft.Extensions.Logging;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.Pipelines;

/// <summary>
/// Posielanie requestov
/// </summary>
internal class SendPipeline : Pipeline, ISaml2Sender
{
	internal SendPipeline(ILogger logger)
		: base(logger)
	{
		AddService(new SendMessageCreator());
		AddService(new SendSerializer());
		AddService(new SendSignature());
		AddService((MessageProcessingService)new SendWriter());
	}

	public event Action<ISaml2Message> MessageCreated
	{
		add => ServicesStack[0].AfterProcessed += value;
		remove => ServicesStack[0].AfterProcessed -= value;
	}

	public event Action<ISaml2Message> BeforeResponseWrite
	{
		add => ServicesStack[3].BeforeProcess += value;
		remove => ServicesStack[3].BeforeProcess -= value;
	}

	public Saml2MessageModel SendMessage(
		ITraceInfo traceInfo,
		Saml2MessageTypeEnum messageType,
		string binding,
		ISaml2ModuleContext context)
	{
		traceInfo = TraceInfo.Create(traceInfo);

		var model = new Saml2MessageModel()
		{
			Context = context,
			Info = new Saml2MessageInfo()
			{
				Binding = binding,
				MessageType = messageType
			},
			Sender = context.Config.SpMetadata,
			Receiver = context.Config.IdpMetadata,
			Config = context.Config
		};

		model.Info.SignMessage = NeedsSignature(
			model.Info.MessageType,
			model.Config.OutgoingMessages?.SignRequest ?? true,
			model.Config.OutgoingMessages?.SignResponse ?? true);

		Process(model);

		Logger.LogTraceMessage(traceInfo, x => x.Detail(model.MessageRaw));

		return model;
	}

	private static bool NeedsSignature(
		Saml2MessageTypeEnum messageType,
		bool signRequest,
		bool signResponse)
	{
		return
			((messageType == Saml2MessageTypeEnum.AuthnRequest
				? 1
				: (messageType == Saml2MessageTypeEnum.LogoutRequest
					? 1
					: 0))
				& (signRequest
					? 1
					: 0)) != 0
			|| ((messageType == Saml2MessageTypeEnum.LogoutResponse
				? 1
				: (messageType == Saml2MessageTypeEnum.Response
					? 1
					: 0))
				& (signResponse
					? 1
					: 0)) != 0;
	}
}
