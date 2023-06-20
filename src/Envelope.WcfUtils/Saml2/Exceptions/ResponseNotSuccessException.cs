namespace Envelope.WcfUtils.Saml2.Exceptions;

internal class ResponseNotSuccessException : Exception
{
	internal ResponseNotSuccessException(string message)
		: base(message)
	{
	}

	internal ResponseNotSuccessException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
