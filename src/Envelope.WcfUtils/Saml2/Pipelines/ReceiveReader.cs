using System.Text;
using System.Web;
using Envelope.WcfUtils.Saml2.Helpers;
using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.Pipelines;

/// <summary>
/// Precita xml bud z POST requestu, alebo z url ak je to redirect
/// Ak je pri redirecte url podpisana, odlozi podpis do model.UrlSignature
/// </summary>
internal class ReceiveReader : MessageProcessingService
{
	internal override void ValidateModel(Saml2MessageModel model)
	{
	}

	internal override void Process(Saml2MessageModel model)
	{
		string requestHttpMethod = model.Context.RequestHttpMethod;
		string requestUrlAbsoluteUri = model.Context.RequestUrlAbsoluteUri;
		model.Info = new Saml2MessageInfo()
		{
			ReceivedDestination = requestUrlAbsoluteUri
		};
		bool isResponse;
		switch (requestHttpMethod)
		{
			case "POST":
				model.Info.Binding = "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST";
				model.MessageRaw = ReadPostMessage(model.Context, out isResponse);
				break;
			case "GET":
				model.Info.Binding = "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-Redirect";
				model.MessageRaw = ReadRedirectMessage(model.Context, out model.UrlSignature, out isResponse);
				break;
			default:
				throw new InvalidOperationException($"Http method not supported: {requestHttpMethod}");
		}
		model.Info.ReceivedIsResponse = isResponse;
	}

	private static string ReadPostMessage(ISaml2ModuleContext context, out bool isResponse)
	{
		isResponse = false;
		context.RequestPostParams.TryGetValue("SAMLRequest", out var samlRequestParams);
		var requestPostParam = 0 < samlRequestParams?.Count
			? string.Join(",", samlRequestParams)
			: null;

		if (requestPostParam == null)
		{
			context.RequestPostParams.TryGetValue("SAMLResponse", out var samlResponseParams);
			requestPostParam = 0 < samlResponseParams?.Count
				? string.Join(",", samlResponseParams)
				: null;

			isResponse = true;
		}

		if (requestPostParam == null)
			throw new InvalidOperationException("Saml POST binding: no SAML2 parameter in post request");

		try
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String(requestPostParam));
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException($"Saml POST binding: value of SAML2 parameter in post request cannot be decoded: {requestPostParam}", ex);
		}
	}

	private static string ReadRedirectMessage(
		ISaml2ModuleContext context,
		out byte[] urlSignature,
		out bool isResponse)
	{
		isResponse = false;
		urlSignature = null;
		string requestUrlAbsoluteUri = context.RequestUrlAbsoluteUri;
		string? result = null;
		try
		{
			var uri = new Uri(requestUrlAbsoluteUri).Query.Substring(1);
			var chArray = new char[1] { '&' };

			foreach (var chunk in uri.Split(chArray))
			{
				if (chunk.StartsWith("SAMLRequest=") || chunk.StartsWith("SAMLResponse="))
				{
					if (chunk.StartsWith("SAMLResponse="))
						isResponse = true;

					string[] strArray = chunk.Split('=');
					result = DeflateHelper.UnZip(Convert.FromBase64String(HttpUtility.UrlDecode(strArray[1])));
				}

				if (chunk.StartsWith("Signature="))
				{
					string[] strArray = chunk.Split('=');
					urlSignature = Convert.FromBase64String(HttpUtility.UrlDecode(strArray[1]));
				}
			}
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException($"Saml Redirect binding: request url malformed: {requestUrlAbsoluteUri}", ex);
		}

		return !string.IsNullOrEmpty(result)
			? result!
			: throw new InvalidOperationException($"Saml Redirect binding: no SAML2 parameter in url: {requestUrlAbsoluteUri}");
	}
}
