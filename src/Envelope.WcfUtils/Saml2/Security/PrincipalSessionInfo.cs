namespace Envelope.WcfUtils.Saml2.Security;

[Serializable]
public class PrincipalSessionInfo
{
	public string Assertion { get; set; }
	public Dictionary<string, List<string>> Attributes { get; set; }
	public List<string> Roles { get; set; }

	public PrincipalSessionInfo()
	{
		Attributes = new Dictionary<string, List<string>>();
		Roles = new List<string>();
	}
}
