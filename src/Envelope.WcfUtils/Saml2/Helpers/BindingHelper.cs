using System.Text;
using System.Web;

namespace Envelope.WcfUtils.Saml2.Helpers;

/// <summary>
/// Sklada url pre redirect binding
/// </summary>
internal static class BindingHelper
{
	internal static string GetRedirectQueryStringWithSignAlg(
		string messageRaw,
		bool isResponse)
	{
		string redirectQueryString = GetRedirectQueryString(messageRaw, isResponse);
		string url = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";
		return $"{redirectQueryString}&SigAlg={HttpUtility.UrlEncode(url)}";
	}

	internal static string GetRedirectQueryString(
		string messageRaw,
		bool isResponse)
		=> $"{GetSaml2ParameterName(isResponse)}={HttpUtility.UrlEncode(Convert.ToBase64String(DeflateHelper.Zip(Encoding.UTF8.GetBytes(messageRaw))))}";

	internal static string GetSaml2ParameterName(bool isResponse)
		=> !isResponse
			? "SAMLRequest"
			: "SAMLResponse";
}