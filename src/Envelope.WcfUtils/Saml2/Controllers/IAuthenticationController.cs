﻿using Envelope.Trace;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Model;
using Envelope.WcfUtils.Saml2.Security;

namespace Envelope.WcfUtils.Saml2.Controllers;

public interface IAuthenticationController
{
	/// <summary>
	/// Odosle prihlasovacie AuthnRequest na IDP
	/// </summary>
	/// <param name="traceInfo"></param>
	/// <param name="context"></param>
	/// <param name="samlController">instancia kontrolera, cez ktoreho sa bude sprava posielat</param>
	/// <param name="returnUrl">navratova url po uspesnom prihlaseni</param>
	Saml2MessageModel SignIn(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		Saml2ServiceProviderController samlController,
		string? returnUrl);

	/// <summary>Odosle prihlasovacie AuthnRequest na IDP</summary>
	/// <param name="traceInfo"></param>
	/// <param name="context"></param>
	/// <param name="samlController">instancia kontrolera, cez ktoreho sa bude sprava posielat</param>
	/// <param name="returnUrl">navratova url po uspesnom prihlaseni</param>
	Saml2MessageModel CheckSignIn(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		Saml2ServiceProviderController samlController,
		string? returnUrl);

	/// <summary>Odosle prihlasovacie AuthnRequest na IDP</summary>
	/// <param name="traceInfo"></param>
	/// <param name="context"></param>
	/// <param name="samlController">instancia kontrolera, cez ktoreho sa bude sprava posielat</param>
	Saml2MessageModel RenewSignIn(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		Saml2ServiceProviderController samlController);

	/// <summary>
	/// Zopakuje odoslanie prihlasovacieho AuthnRequestu na IDP
	/// </summary>
	/// <param name="traceInfo"></param>
	/// <param name="context"></param>
	/// <param name="samlController">instancia kontrolera, cez ktoreho sa bude sprava posielat</param>
	/// <returns>true ak opakovanie prihlasenia este nebolo pouzite, false ak sa prihlasovanie uz raz opakovalo</returns>
	bool RetrySignIn(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		Saml2ServiceProviderController samlController);

	/// <summary>Odosle odhlasovaci LogoutRequest na IDP</summary>
	/// <param name="traceInfo"></param>
	/// <param name="context"></param>
	/// <param name="samlController">instancia kontrolera, cez ktoreho sa bude sprava posielat</param>
	/// <param name="returnUrl">navratova url po uspesnom odhlaseni</param>
	Saml2MessageModel SignOut(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context,
		Saml2ServiceProviderController samlController,
		string returnUrl);

	/// <summary>
	/// Odhlasi usera z lokalnej aplikacie, zrusi sa mu auth cookie aj session data. Nakoniec moze presmerovat usera na login stranku
	/// </summary>
	void LocalLogout(ISaml2ModuleContext context, bool redirectToLoginPage);

	/// <summary>Precita a spracuje prichadzajucu saml spravu</summary>
	/// <returns>prijata saml sprava</returns>
	ISaml2Message ConsumeSamlMessage(ITraceInfo traceInfo, ISaml2ModuleContext context);

	/// <summary>
	/// Ulozi udaje prihlaseneho usera, aby mohla byt jeho identita znovu vytvorena pri dalsom requeste
	/// </summary>
	void StoreCurrentUser(ISaml2ModuleContext context);

	/// <summary>Vytvori a nastavi identitu prihlaseneho usera</summary>
	Saml2Principal? ReconstructCurrentUser(ISaml2ModuleContext context);

	/// <summary>
	/// Overi, ze prihlaseny user je zhodny s tym ktory ma nastavene svoje data v session
	/// </summary>
	/// <returns>true ak je user v poriadku, false ak user nesedi voci session</returns>
	bool VerifyUserSession(ISaml2ModuleContext context);

	/// <summary>
	/// Overi, ci vyprsela platnost tokenu a je nutne provest renew
	/// </summary>
	/// <returns>true ak platnost tokenu vyprsela, false ak je stale platny</returns>
	bool ReloadToken(ISaml2ModuleContext context);

	/// <summary>
	/// Overi, ci je nutne vykonat predlzenie platnosti tokenu
	/// </summary>
	/// <returns>true ak ma platnost tokenu vyprsat po uplynuti casoveho intervalu definovaneho parametrom sessionExpirationOffset</returns>
	bool RenewSessionToken(ISaml2ModuleContext context);
}