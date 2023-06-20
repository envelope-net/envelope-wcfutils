using Envelope.WcfUtils.Saml2.Messages;

namespace Envelope.WcfUtils.Saml2.Events;

public class Saml2MessageEventArgs : EventArgs
{
	public ISaml2Message Message { get; }

	internal Saml2MessageEventArgs(ISaml2Message message)
	{
		Message = message ?? throw new ArgumentNullException(nameof(message));
	}
}
