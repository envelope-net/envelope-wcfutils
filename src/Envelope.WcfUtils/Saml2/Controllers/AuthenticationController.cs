using Envelope.Trace;
using Envelope.WcfUtils.Saml2.DataStore;
using Envelope.WcfUtils.Saml2.Helpers;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Model;
using Envelope.WcfUtils.Saml2.Security;

namespace Envelope.WcfUtils.Saml2.Controllers;

public class AuthenticationController : IAuthenticationController
{
	/// <summary>
	/// Odosle prihlasovacie AuthnRequest na IDP
	/// </summary>
	/// <param name="samlController">instancia kontrolera, cez ktoreho sa bude sprava posielat</param>
	/// <param name="returnUrl">navratova url po uspesnom prihlaseni</param>
	public Saml2MessageModel SignIn(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		Saml2ServiceProviderController samlController,
		string? returnUrl)
	{
		var sessionStore = new UserDataSessionStore();
		sessionStore.Load(context);
		sessionStore.Set(context, UserDataStore.REQUESTED_URL, returnUrl);
		var saml2MessageModel = samlController.SingIn(traceInfo, context, sessionStore);
		sessionStore.Store(context);
		return saml2MessageModel;
	}

	/// <summary>Odosle prihlasovacie AuthnRequest na IDP</summary>
	/// <param name="samlController">instancia kontrolera, cez ktoreho sa bude sprava posielat</param>
	/// <param name="returnUrl">navratova url po uspesnom prihlaseni</param>
	public Saml2MessageModel CheckSignIn(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		Saml2ServiceProviderController samlController,
		string? returnUrl)
	{
		var sessionStore = new UserDataSessionStore();
		sessionStore.Load(context);
		sessionStore.Set(context, UserDataStore.REQUESTED_URL, returnUrl);
		var saml2MessageModel = samlController.CheckSignIn(traceInfo, context, sessionStore);
		sessionStore.Store(context);
		return saml2MessageModel;
	}

	/// <summary>Odosle prihlasovacie AuthnRequest na IDP</summary>
	/// <param name="samlController">instancia kontrolera, cez ktoreho sa bude sprava posielat</param>
	public Saml2MessageModel RenewSignIn(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		Saml2ServiceProviderController samlController)
	{
		var sessionStore = new UserDataSessionStore();
		sessionStore.Load(context);
		sessionStore.Set(context, UserDataStore.REQUESTED_URL, context.Config.SamlRefreshUrl);
		sessionStore.Set(context, UserDataStore.AUTH_RETRIED, true.ToString());
		var saml2MessageModel = samlController.RenewSignIn(traceInfo, context, sessionStore);
		sessionStore.Store(context);
		return saml2MessageModel;
	}

	/// <summary>
	/// Zopakuje odoslanie prihlasovacieho AuthnRequestu na IDP
	/// </summary>
	/// <param name="samlController">instancia kontrolera, cez ktoreho sa bude sprava posielat</param>
	/// <returns>true ak opakovanie prihlasenia este nebolo pouzite, false ak sa prihlasovanie uz raz opakovalo</returns>
	public bool RetrySignIn(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		Saml2ServiceProviderController samlController)
	{
		var sessionStore = new UserDataSessionStore();
		sessionStore.Load(context);

		if (sessionStore.Get<string>(context, UserDataStore.AUTH_RETRIED) == true.ToString())
			return false;

		sessionStore.Set(context, UserDataStore.AUTH_RETRIED, true.ToString());
		var saml2MessageModel = samlController.SingIn(traceInfo, context, sessionStore);
		sessionStore.Store(context);
		return true;
	}

	/// <summary>Odosle odhlasovaci LogoutRequest na IDP</summary>
	/// <param name="samlController">instancia kontrolera, cez ktoreho sa bude sprava posielat</param>
	/// <param name="returnUrl">navratova url po uspesnom odhlaseni</param>
	public Saml2MessageModel SignOut(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		Saml2ServiceProviderController samlController,
		string returnUrl)
	{
		var sessionStore = new UserDataSessionStore();
		sessionStore.Load(context);
		sessionStore.Set(context, UserDataStore.REQUESTED_URL, returnUrl);
		var saml2MessageModel = samlController.SingOut(traceInfo, context, sessionStore);
		sessionStore.Store(context);
		return saml2MessageModel;
	}

	/// <summary>
	/// Odhlasi usera z lokalnej aplikacie, zrusi sa mu auth cookie aj session data. Nakoniec moze presmerovat usera na login stranku
	/// </summary>
	public void LocalLogout(ISaml2ModuleContext context, bool redirectToLoginPage)
	{
		var sessionStore = new UserDataSessionStore();
		sessionStore.Load(context);
		var key = sessionStore.Get<string>(context, UserDataStore.SESSION_INDEX);

		if (!string.IsNullOrEmpty(key))
		{
			sessionStore.Clear(UserDataStore.SESSION_INDEX);
			sessionStore.Clear(key);
			sessionStore.Store(context);
			context.SessionSet(UserDataStore.AUTHENTICATION_CONTROLLER_SESSION_INDEX, string.Empty);
		}

		context.FormsAuthenticationSignOut(redirectToLoginPage);
	}

	/// <summary>Precita a spracuje prichadzajucu saml spravu</summary>
	/// <returns>prijata saml sprava</returns>
	public async Task<ISaml2Message> ConsumeSamlMessageAsync(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		Func<PrincipalTicketInfo, PrincipalSessionInfo, object?, Task<object?>>? userDataDelegate)
	{
		if (context == null)
			throw new ArgumentNullException(nameof(context));

		var sessionStore = new UserDataSessionStore();
		sessionStore.Load(context);

		var saml2Message = new Saml2ServiceProviderController(context.Logger).ProcessIncommingMessage(traceInfo, context, sessionStore);
		
		if (saml2Message is StatusResponseType message)
		{
			if (MessageHelper.HasNoPassiveStatusCode(message))
			{
				saml2Message.ReturnUrl = RedirectToReturnUrl(context, sessionStore);
				return saml2Message;
			}

			if (message is ResponseType responseType && responseType.Assertion != null)
			{
				var principal = await PrincipalService.CreatePrincipalAsync(responseType.Assertion, responseType.AssertionRaw, context.Config.AssertionAttributes, userDataDelegate);
				context.Principal = principal;
				sessionStore.Clear(UserDataStore.AUTH_RETRIED);
				var str = sessionStore.Get<string>(context, UserDataStore.SESSION_INDEX);
				context.SessionSet(UserDataStore.AUTHENTICATION_CONTROLLER_SESSION_INDEX, str!);
				saml2Message.ReturnUrl = RedirectToReturnUrl(context, sessionStore);
			}

			if (message is LogoutResponseType)
			{
				saml2Message.ReturnUrl = RedirectToReturnUrl(context, sessionStore);
			}
		}

		sessionStore.Store(context);
		return saml2Message;
	}

	/// <summary>
	/// Ulozi udaje prihlaseneho usera, aby mohla byt jeho identita znovu vytvorena pri dalsom requeste
	/// </summary>
	public async Task StoreCurrentUserAsync(ISaml2ModuleContext context, ITraceInfo traceInfo, Func<string, Saml2Principal, DateTime, Task> sessionStoreDelegate)
	{
		if (context.Principal is not Saml2Principal applicationCurrentUser || !applicationCurrentUser.IsFromAssertion)
			return;

		await PrincipalService.StorePrincipal(context.AddCookieToResponse, context.Config.Serializer, applicationCurrentUser, traceInfo, sessionStoreDelegate);
		var sessionStore = new UserDataSessionStore();
		sessionStore.Load(context);
		var sessionIndex = sessionStore.Get<string>(context, UserDataStore.SESSION_INDEX);
		sessionStore.Set(context, sessionIndex!, UserDataStore.PRINCIPAL_SESSION_INFO, context.Config.Serializer.Serialize(applicationCurrentUser.SessionInfo));
		sessionStore.Store(context);
	}

	/// <summary>Vytvori a nastavi identitu prihlaseneho usera</summary>
	public async Task<Saml2Principal?> ReconstructCurrentUserAsync(
		ISaml2ModuleContext context,
		bool readPrincipalSessionInfoFromInMemoryCache,
		Func<IServiceProvider, string, Task<PrincipalSessionData?>> loadPrincipalSessionInfo,
		Func<PrincipalTicketInfo, PrincipalSessionInfo, object?, Task<object?>>? userDataDelegate)
	{
		var formsAuthenticationTicketUserData = context.GetRequestCookieUserData();

		if (string.IsNullOrWhiteSpace(formsAuthenticationTicketUserData) || !formsAuthenticationTicketUserData!.StartsWith("[Saml2Principal]") == true)
			return null;

		object? userInfo = null;
		var sessionInfo = readPrincipalSessionInfoFromInMemoryCache
			? LoadCurrentUserSessionInfo(context)!
			: null;

		if (sessionInfo == null)
		{
			if (loadPrincipalSessionInfo == null)
			{
				return null;
			}
			else
			{
				var principalSessionData = await loadPrincipalSessionInfo(context.ServiceProvider, formsAuthenticationTicketUserData);
				sessionInfo = principalSessionData?.PrincipalSessionInfo;
				userInfo = principalSessionData?.UserInfo;
			}
		}

		if (sessionInfo == null)
			return null;

		var principalTicketInfoSerialized = formsAuthenticationTicketUserData.Substring("[Saml2Principal]".Length);

		var saml2Principal = await PrincipalService.LoadPrincipalAsync(
			context.Config.Serializer,
			principalTicketInfoSerialized,
			sessionInfo,
			userInfo,
			formsAuthenticationTicketUserData!,
			userDataDelegate);

		context.Principal = saml2Principal;
		return saml2Principal;
	}

	/// <summary>Nacita data usera zo session</summary>
	private static PrincipalSessionInfo? LoadCurrentUserSessionInfo(ISaml2ModuleContext context)
	{
		var sessionStore = new UserDataSessionStore();
		sessionStore.Load(context);
		var sessionIndex = sessionStore.Get<string>(context, UserDataStore.SESSION_INDEX);
		
		if (string.IsNullOrEmpty(sessionIndex))
			return null;

		var str = sessionStore.Get<string>(context, sessionIndex, UserDataStore.PRINCIPAL_SESSION_INFO);
		return context.Config.Serializer.Deserialize<PrincipalSessionInfo>(str!);
	}

	/// <summary>
	/// Overi, ze prihlaseny user je zhodny s tym ktory ma nastavene svoje data v session
	/// </summary>
	/// <returns>true ak je user v poriadku, false ak user nesedi voci session</returns>
	public bool VerifyUserSession(ISaml2ModuleContext context)
		=> context.Principal is not Saml2Principal applicationCurrentUser
			|| applicationCurrentUser.TicketInfo.SessionIndex == (context.SessionGet(UserDataStore.AUTHENTICATION_CONTROLLER_SESSION_INDEX) as string);

	/// <summary>
	/// Overi, ci vyprsela platnost tokenu a je nutne provest renew
	/// </summary>
	/// <returns>true ak platnost tokenu vyprsela, false ak je stale platny</returns>
	public bool ReloadToken(ISaml2ModuleContext context)
		=> context.Principal is Saml2Principal applicationCurrentUser
			&& (applicationCurrentUser.TicketInfo.ValidTo - DateTime.UtcNow).TotalSeconds <= 0.0;

	/// <summary>
	/// Overi, ci je nutne vykonat predlzenie platnosti tokenu
	/// </summary>
	/// <returns>true ak ma platnost tokenu vyprsat po uplynuti casoveho intervalu definovaneho parametrom sessionExpirationOffset</returns>
	public bool RenewSessionToken(ISaml2ModuleContext context)
		=> context.RequestRootRelativePath.Equals(context.Config.SamlRefreshUrl)
			&& context.Principal is Saml2Principal applicationCurrentUser
			&& (applicationCurrentUser.TicketInfo.ValidTo - DateTime.UtcNow).TotalSeconds - context.Config.SessionExpirationOffset <= 0.0;

	/// <summary>
	/// Presmerovanie na pozadovanu url. Url je ulozena v session
	/// </summary>
	/// <param name="context"></param>
	/// <param name="store"></param>
	private static string? RedirectToReturnUrl(ISaml2ModuleContext context, UserDataStore store)
	{
		var url = store.Get<string>(context, UserDataStore.REQUESTED_URL);
		return url;
	}
}
