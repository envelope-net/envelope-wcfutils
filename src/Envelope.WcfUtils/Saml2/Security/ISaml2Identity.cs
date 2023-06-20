using System.IdentityModel.Tokens;
using System.Security.Principal;

namespace Envelope.WcfUtils.Saml2.Security;

/// <summary>The SAML 2.0 Identity interface</summary>
public interface ISaml2Identity : IIdentity
{
	DateTime ValidTo { get; }
	SecurityToken? SecurityToken { get; }
}
