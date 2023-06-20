namespace Envelope.WcfUtils.Saml2.Security;

[Serializable]
public class PrincipalTicketInfo
{
	public string Username { get; set; }

	public string AuthnType { get; set; }

	public string SessionIndex { get; set; }

	public string Id { get; set; }

	public string IdFormat { get; set; }

	public string IdIdp { get; set; }

	public string IdSp { get; set; }

	public DateTime ValidTo { get; set; }
}
