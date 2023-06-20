namespace Envelope.WcfUtils.Saml2.Security;

/// <summary>
/// The SAML 2.0 Principal interface
/// </summary>
public interface ISaml2Principal
{
	/// <summary>
	/// The name identifier
	/// </summary>
	string NameID { get; }

	/// <summary>
	/// The name identifier format
	/// </summary>
	string NameIDFormat { get; }

	/// <summary>
	/// The name identifier idp
	/// </summary>
	string NameIDIdp { get; }

	/// <summary>
	/// The name identifier sp
	/// </summary>
	string NameIDSp { get; }

	string SessionIndex { get; }

	string Assertion { get; }

	IEnumerable<string> Roles { get; }

	DateTime ValidTo { get; }
}
