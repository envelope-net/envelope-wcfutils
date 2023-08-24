using Envelope.WcfUtils.Saml2.Config;
using Envelope.WcfUtils.Saml2.Security;
using Microsoft.Extensions.Logging;

namespace Envelope.WcfUtils.Saml2;

public interface ISaml2ModuleContext
{
	IServiceProvider ServiceProvider { get; }

	ISaml2Config Config { get; }

	ILogger Logger { get; }

	/// <summary>
	/// adresa pre obnovovanie tokenu
	/// </summary>
	string RequestRootRelativePath { get; }

	Func<string?> GetRequestCookieUserData { get; }

	Action<DateTime, string, string, Saml2Principal> AddCookieToResponse { get; }

	Action<bool> FormsAuthenticationSignOut { get; }

	Action<string> ResponseRedirectToUrl { get; }

	string RequestUrlAbsoluteUri { get; }

	string RequestHttpMethod { get; }

	Dictionary<string, List<string>> RequestPostParams { get; }

	Action<string> ResponseWrite { get; }

	Saml2Principal? Principal { get; set; }

	object? SessionGet(string key);

	void SessionSet(string key, object value);
}
