namespace Envelope.WcfUtils.Saml2.Events;

public class Saml2ErrorEventArgs : EventArgs
{
	public Exception Exception { get; }

	internal Saml2ErrorEventArgs(Exception exception)
	{
		Exception = exception ?? throw new NullReferenceException(nameof(exception));
	}
}
