using Envelope.WcfUtils.Saml2.Messages;

namespace Envelope.WcfUtils.Saml2.Model;

internal class Saml2MessageInfo
{
	internal Saml2MessageTypeEnum MessageType { get; set; }

	internal bool IsResponse { get; set; }

	internal Saml2ServiceTypeEnum ServiceType { get; set; }

	internal string Binding { get; set; }

	internal string ReceivedDestination { get; set; }

	internal bool ReceivedIsResponse { get; set; }

	internal bool SignMessage { get; set; }

	internal bool MessageSignatureVerified { get; set; }

	internal bool SecondarySignatureVerified { get; set; }
}
