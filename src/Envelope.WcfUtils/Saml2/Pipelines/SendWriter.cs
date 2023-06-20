using System.Text;
using System.Web;
using Envelope.WcfUtils.Saml2.Helpers;
using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.Pipelines;

/// <summary>
/// Zapise spravu do http response, podla toho ci je to post binding alebo redirekt binding
/// Ak je to redirekt a je vyzadovany aj podpis, tak posklada vyslednu podpisanu url
/// </summary>
internal class SendWriter : MessageProcessingService
{
	internal override void ValidateModel(Saml2MessageModel model)
	{
		if (model == null)
			throw new ArgumentNullException(nameof(model));

		if (model.Info == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Info)}");

		if (string.IsNullOrWhiteSpace(model.Info.Binding))
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Info)}.{nameof(model.Info.Binding)}");

		if (model.Message == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Message)}");

		if (string.IsNullOrWhiteSpace(model.Message.Destination))
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Message)}.{nameof(model.Message.Destination)}");

		if (string.IsNullOrWhiteSpace(model.MessageRaw))
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Message)}");
	}

	internal override void Process(Saml2MessageModel model)
	{
		switch (model.Info.Binding)
		{
			case "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST":
				WritePostMessage(model.Context, model.Message.Destination, model.MessageRaw, model.Config.PostBindingHtml, model.Info.IsResponse);
				break;
			case "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-Redirect":
				WriteRedirectMessage(model, model.Message.Destination, model.MessageRaw, model.UrlSignature, model.Info.IsResponse);
				break;
			default:
				throw new InvalidOperationException($"Binding not supported: {model.Info.Binding}");
		}
	}

	private static void WritePostMessage(
		ISaml2ModuleContext context,
		string destination,
		string messageRaw,
		string postBindingHtml,
		bool isResponse)
	{
		string saml2ParameterName = BindingHelper.GetSaml2ParameterName(isResponse);
		string base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes(messageRaw));
		postBindingHtml = postBindingHtml.Replace("{samlDestination}", destination);
		postBindingHtml = postBindingHtml.Replace("{samlMessageType}", saml2ParameterName);
		postBindingHtml = postBindingHtml.Replace("{samlMessage}", base64String);
		context.ResponseWrite(postBindingHtml);
	}

	private static void WriteRedirectMessage(
		Saml2MessageModel model,
		string destination,
		string messageRaw,
		byte[] urlSignature,
		bool isResponse)
	{
		string str = destination.Contains('?') ? "&" : "?";
		string url;
		if (urlSignature == null)
			url = $"{destination}{str}{BindingHelper.GetRedirectQueryString(messageRaw, isResponse)}";
		else
			url = $"{destination}{str}{BindingHelper.GetRedirectQueryStringWithSignAlg(messageRaw, isResponse)}&Signature={HttpUtility.UrlEncode(Convert.ToBase64String(urlSignature))}";

		model.IAMSignInUrl = url;
		model.Context.ResponseRedirectToUrl(url);
	}
}
