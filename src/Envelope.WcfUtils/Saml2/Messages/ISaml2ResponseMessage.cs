namespace Envelope.WcfUtils.Saml2.Messages;

public interface ISaml2ResponseMessage : ISaml2Message
{
	string InResponseTo { get; set; }

	string? StatusCode { get; set; }

	string? SecondLevelStatusCode { get; set; }
}
