namespace Envelope.WcfUtils.Saml2.Messages;

public interface ISaml2Message
{
	NameIDType Issuer { get; set; }

	SignatureType Signature { get; set; }

	string ID { get; set; }

	string Version { get; set; }

	DateTime IssueInstant { get; set; }

	string Destination { get; set; }
}
