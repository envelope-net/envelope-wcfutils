using Envelope.WcfUtils.Saml2.Messages;

namespace Envelope.WcfUtils.Saml2.Helpers;

internal static class MessageHelper
{
	public const string BINDINGS_HTTPRedirect = "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-Redirect";
	public const string STATUS_SUCCESS = "urn:oasis:names:tc:SAML:2.0:status:Success";
	public const string STATUS_RESPONDER = "urn:oasis:names:tc:SAML:2.0:status:Responder";
	public const string STATUS_REQUESTER = "urn:oasis:names:tc:SAML:2.0:status:Requester";
	public const string STATUS_NO_PASSIVE = "urn:oasis:names:tc:SAML:2.0:status:NoPassive";

	internal static string DateToString(DateTime date)
	{
		if (date.Kind == DateTimeKind.Local)
			date = date.ToUniversalTime();

		return date.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
	}

	internal static DateTime DateFromString(string str)
	{
		try
		{
			return DateTime.Parse(str);
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException($"Unable to parse DateTime: '{str}'", ex);
		}
	}

	internal static string? GetResponseStatus(ISaml2ResponseMessage message)
	{
		if (message is not StatusResponseType statusResponseType)
			return null;

		return statusResponseType.Status?.StatusCode?.Value;
	}

	internal static string? GetSecondLevelResponseStatus(ISaml2ResponseMessage message)
	{
		if (message is not StatusResponseType statusResponseType)
			return null;

		return statusResponseType.Status?.StatusCode?.StatusCode?.Value;
	}

	internal static void SetResponseStatus(ISaml2ResponseMessage message, string statusCode)
	{
		if (message is not StatusResponseType statusResponseType)
			return;

		statusResponseType.Status ??= new StatusType();

		if (statusResponseType.Status.StatusCode == null)
			statusResponseType.Status.StatusCode = new StatusCodeType();

		statusResponseType.Status.StatusCode.Value = statusCode;
	}

	internal static void SetSecondLevelResponseStatus(
		ISaml2ResponseMessage message,
		string statusCode)
	{
		if (message is not StatusResponseType statusResponseType)
			return;

		if (statusResponseType.Status?.StatusCode == null)
			SetResponseStatus(message, "");

		if (statusResponseType.Status!.StatusCode.StatusCode == null)
			statusResponseType.Status.StatusCode.StatusCode = new StatusCodeType();

		statusResponseType.Status.StatusCode.StatusCode.Value = statusCode;
	}

	internal static bool HasNoPassiveStatusCode(ISaml2ResponseMessage message)
		=> message.StatusCode == STATUS_REQUESTER && message.SecondLevelStatusCode == STATUS_NO_PASSIVE;
}