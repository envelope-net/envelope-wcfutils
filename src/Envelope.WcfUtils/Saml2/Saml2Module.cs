using Envelope.Logging.Extensions;
using Envelope.Trace;
using Envelope.WcfUtils.Saml2.Controllers;
using Envelope.WcfUtils.Saml2.Events;
using Envelope.WcfUtils.Saml2.Exceptions;
using Envelope.WcfUtils.Saml2.Helpers;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Model;
using Envelope.WcfUtils.Saml2.Security;

namespace Envelope.WcfUtils.Saml2;

public class Saml2Module
{
	private readonly IAuthenticationController authController;
	private readonly Saml2ServiceProviderController saml2Controller;

	public ISaml2ModuleContext Context { get; }

	public event Saml2MessageEventHandler? BeforeSignIn;

	public event Saml2EventHandler? SignedIn;

	public event Saml2EventHandler? AnonymousSignInAttempt;

	public event Saml2EventHandler? SignedOut;

	public event Saml2ErrorEventHandler? Error;

	public Saml2Module(ISaml2ModuleContext context)
	{
		Context = context ?? throw new ArgumentNullException(nameof(context));
		authController = new AuthenticationController();
		saml2Controller = new Saml2ServiceProviderController(Context.Logger);
	}

	/// <summary>Prihlasenie</summary>
	public Saml2MessageModel? SignIn(ITraceInfo traceInfo)
	{
		Context.Logger.LogTraceMessage(traceInfo, x => x.Detail(nameof(SignIn)));
		var saml2MessageModel = HandleError(traceInfo , () => authController.SignIn(traceInfo, Context, saml2Controller, null));
		return saml2MessageModel;
	}

	/// <summary>Prihlasenie s presmerovanim na pozadovanu adresu</summary>
	public Saml2MessageModel? SignIn(ITraceInfo traceInfo, string returnUrl)
	{
		Context.Logger.LogTraceMessage(traceInfo, x => x.Detail($"{nameof(SignIn)} | {nameof(returnUrl)} = {returnUrl}"));
		var saml2MessageModel = HandleError(traceInfo, () => authController.SignIn(traceInfo, Context, saml2Controller, returnUrl));
		return saml2MessageModel;
	}

	/// <summary>Predlzenie platnosti prihlasenie</summary>
	public Saml2MessageModel? RenewSignIn(ITraceInfo traceInfo)
	{
		Context.Logger.LogTraceMessage(traceInfo, x => x.Detail(nameof(RenewSignIn)));
		var saml2MessageModel = HandleError(traceInfo, () => authController.RenewSignIn(traceInfo, Context, saml2Controller));
		return saml2MessageModel;
	}

	/// <summary>
	/// Pasivne prihlasenie s presmerovanim na vychodziu adresu
	/// </summary>
	public Saml2MessageModel? CheckSignIn(ITraceInfo traceInfo)
	{
		Context.Logger.LogTraceMessage(traceInfo, x => x.Detail(nameof(CheckSignIn)));
		var saml2MessageModel = HandleError(traceInfo, () => authController.CheckSignIn(traceInfo, Context, saml2Controller, null));
		return saml2MessageModel;
	}

	/// <summary>
	/// Pasivne prihlasenie s presmerovanim na pozadovanu adresu
	/// </summary>
	public Saml2MessageModel? CheckSignIn(ITraceInfo traceInfo, string returnUrl)
	{
		Context.Logger.LogTraceMessage(traceInfo, x => x.Detail($"{nameof(CheckSignIn)} | {nameof(returnUrl)} = {returnUrl}"));
		var saml2MessageModel = HandleError(traceInfo, () => authController.CheckSignIn(traceInfo, Context, saml2Controller, returnUrl));
		return saml2MessageModel;
	}

	/// <summary>Odhlasenie pouzivatela</summary>
	public Saml2MessageModel? SignOut(ITraceInfo traceInfo, string returnUrl)
	{
		Context.Logger.LogTraceMessage(traceInfo, x => x.Detail($"{nameof(SignOut)} | {nameof(returnUrl)} = {returnUrl}"));
		var saml2MessageModel = HandleError(traceInfo, () => authController.SignOut(traceInfo, Context, saml2Controller, returnUrl));
		return saml2MessageModel;
	}

	/// <summary>Odhlasenie pouzivatela</summary>
	public void LocalLogout(ITraceInfo traceInfo, bool redirectToLoginPage)
	{
		Context.Logger.LogTraceMessage(traceInfo, x => x.Detail($"{nameof(LocalLogout)}"));
		HandleError(traceInfo, () =>
		{
			authController.LocalLogout(Context, redirectToLoginPage);
			FireSignedOut();
		});
	}

	public Task<Saml2Principal?> ReconstructCurrentUserAsync(
		bool readPrincipalSessionInfoFromInMemoryCache,
		Func<IServiceProvider, string, Task<PrincipalSessionData?>> loadPrincipalSessionInfo,
		Func<PrincipalTicketInfo, PrincipalSessionInfo, object?, Task<object?>>? userDataDelegate)
		=> authController.ReconstructCurrentUserAsync(Context, readPrincipalSessionInfoFromInMemoryCache, loadPrincipalSessionInfo, userDataDelegate);

	public void PostAcquireRequestState(ITraceInfo traceInfo)
	{
		if (!authController.VerifyUserSession(Context))
			LocalLogout(traceInfo, true);

		if (authController.ReloadToken(Context))
		{
			LocalLogout(traceInfo, false);
			SignIn(traceInfo);
		}

		if (!authController.RenewSessionToken(Context))
			return;

		RenewSignIn(traceInfo);
	}

	/// <summary>Processes the message.</summary>
	public async Task ProcessMessageAsync(
		ITraceInfo traceInfo,
		Func<string, Saml2Principal, DateTime, Task> sessionStoreDelegate,
		Func<PrincipalTicketInfo, PrincipalSessionInfo, object?, Task<object?>>? userDataDelegate)
	{
		bool isLogout = false;
		await HandleErrorAsync(
			traceInfo,
			async () =>
			{
				var saml2Message = await authController.ConsumeSamlMessageAsync(traceInfo, Context, userDataDelegate);
				if (saml2Message is ISaml2ResponseMessage saml2ResponseMessage
					&& saml2ResponseMessage.StatusCode == MessageHelper.STATUS_REQUESTER
					&& saml2ResponseMessage.SecondLevelStatusCode == MessageHelper.STATUS_NO_PASSIVE)
				{
					FireAnonymousSignInAttempt();
				}
				else
				{
					if (saml2Message is ResponseType)
					{
						await authController.StoreCurrentUserAsync(Context, traceInfo, sessionStoreDelegate);
						FireSignedIn();
					}

					if (saml2Message is not LogoutRequestType && saml2Message is not LogoutResponseType)
						return;

					isLogout = true;
				}
			},
			() =>
			{
				if (!isLogout)
					return;

				LocalLogout(traceInfo, false);
			});
	}

	private Saml2MessageModel? HandleError(
		ITraceInfo traceInfo,
		Func<Saml2MessageModel> action,
		Action? postAction = null)
	{
		Exception? e = null;
		Saml2MessageModel? result = null;

		try
		{
			result = action();
		}
		catch (Exception ex)
		{
			Context.Logger.LogErrorMessage(traceInfo, x => x.ExceptionInfo(ex));

			if (ex is ResponseNotSuccessException && authController.RetrySignIn(traceInfo, Context, saml2Controller))
				return result;

			e = ex;
		}

		postAction?.Invoke();

		if (e == null)
			return result;

		FireError(e);

		return result;
	}

	private void HandleError(
		ITraceInfo traceInfo,
		Action action,
		Action? postAction = null)
	{
		Exception? e = null;

		try
		{
			action();
		}
		catch (Exception ex)
		{
			Context.Logger.LogErrorMessage(traceInfo, x => x.ExceptionInfo(ex));

			if (ex is ResponseNotSuccessException && authController.RetrySignIn(traceInfo, Context, saml2Controller))
				return;

			e = ex;
		}

		postAction?.Invoke();

		if (e == null)
			return;

		FireError(e);
	}

	private async Task HandleErrorAsync(
		ITraceInfo traceInfo,
		Func<Task> action,
		Action? postAction = null)
	{
		Exception? e = null;

		try
		{
			await action();
		}
		catch (Exception ex)
		{
			Context.Logger.LogErrorMessage(traceInfo, x => x.ExceptionInfo(ex));

			if (ex is ResponseNotSuccessException && authController.RetrySignIn(traceInfo, Context, saml2Controller))
				return;

			e = ex;
		}

		postAction?.Invoke();

		if (e == null)
			return;

		FireError(e);
	}

	private void FireError(
		Exception e)
	{
		var error = Error;
		if (error != null)
		{
			error(this, new Saml2ErrorEventArgs(e));
		}
		else
		{
			throw e;
		}
	}

	private void FireBeforeSignIn(Saml2MessageEventArgs args)
	{
		var beforeSignIn = BeforeSignIn;

		if (beforeSignIn == null)
			return;

		beforeSignIn(this, args);
	}

	private void FireSignedOut()
	{
		var signedOut = SignedOut;

		if (signedOut == null)
			return;

		signedOut(this, new EventArgs());
	}

	private void FireAnonymousSignInAttempt()
	{
		var anonymousSignInAttempt = AnonymousSignInAttempt;

		if (anonymousSignInAttempt == null)
			return;

		anonymousSignInAttempt(this, new EventArgs());
	}

	private void FireSignedIn()
	{
		var signedIn = SignedIn;

		if (signedIn == null)
			return;

		signedIn(this, new EventArgs());
	}
}
