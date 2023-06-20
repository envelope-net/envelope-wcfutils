using Envelope.Exceptions;
using Envelope.Identity;
using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Principal;
using System.Xml;

namespace Envelope.WcfUtils.Saml2.Security;

[Serializable]
internal class Saml2Identity : EnvelopeIdentity, ISaml2Identity, IIdentity
{
	public override bool IsAuthenticated { get; }

	internal PrincipalTicketInfo TicketInfo { get; }

	public DateTime ValidTo => TicketInfo?.ValidTo ?? default;

	internal PrincipalSessionInfo SessionInfo { get; }

	public SecurityToken? SecurityToken
	{
		get
		{
			if (string.IsNullOrEmpty(SessionInfo.Assertion))
				return null;

			var xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(SessionInfo.Assertion);
			return new GenericXmlSecurityToken(xmlDocument.DocumentElement, null, DateTime.Now, DateTime.Now.AddDays(1.0), null, null, (ReadOnlyCollection<IAuthorizationPolicy>)null!);
		}
		set => throw new NotSupportedException();
	}

	internal Saml2Identity(
		PrincipalTicketInfo ticketInfo,
		PrincipalSessionInfo sessionInfo,
		bool isAuthenticated)
		: base(CreateClaimsIdentity(ticketInfo, sessionInfo),
			Guid.NewGuid(),
			ticketInfo.Username,
			ticketInfo.Username,
			null,
			false,
			sessionInfo.Roles,
			null,
			null,
			null,
			false,
			false)
	{
		Throw.ArgumentNull(ticketInfo);
		Throw.ArgumentNull(sessionInfo);

		SessionInfo = sessionInfo;
		TicketInfo = ticketInfo;
		IsAuthenticated = isAuthenticated;

		//var name = TicketInfo.Username;
		//if (!string.IsNullOrWhiteSpace(name))
		//	base.AddClaim(new Claim(base.NameClaimType, name, ClaimValueTypes.String, ClaimsIdentity.DefaultIssuer, ClaimsIdentity.DefaultIssuer, this));

		//if (CookieInfo.Roles != null)
		//	foreach (var role in CookieInfo.Roles)
		//		base.AddClaim(new Claim(ClaimTypes.Role, role));

		//var attributes = SessionInfo.Attributes;

		//foreach (string key in attributes.Keys)
		//{
		//	foreach (string str in attributes[key])
		//		base.AddClaim(new Claim(key, str));
		//}
	}

	private static ClaimsIdentity CreateClaimsIdentity(
		PrincipalTicketInfo ticketInfo,
		PrincipalSessionInfo sessionInfo)
	{
		Throw.ArgumentNull(ticketInfo);
		Throw.ArgumentNull(sessionInfo);

		var identity = new ClaimsIdentity(ticketInfo.AuthnType);

		var name = ticketInfo.Username;
		if (!string.IsNullOrWhiteSpace(name))
			identity.AddClaim(new Claim(identity.NameClaimType, name, ClaimValueTypes.String, ClaimsIdentity.DefaultIssuer, ClaimsIdentity.DefaultIssuer, identity));

		var attributes = sessionInfo.Attributes;

		var roles = new List<string>();
		foreach (string key in attributes.Keys)
		{
			if (key == nameof(PrincipalSessionInfo.Roles))
			{
				foreach (string role in attributes[key])
					if (!roles.Contains(role))
					{
						identity.AddClaim(new Claim(ClaimTypes.Role, role));
						roles.Add(role);
					}
			}
			else
			{
				foreach (string str in attributes[key])
					identity.AddClaim(new Claim(key, str));
			}
		}
		foreach (var role in sessionInfo.Roles)
		{
			if (!roles.Contains(role))
				identity.AddClaim(new Claim(ClaimTypes.Role, role));
		}

		return identity;
	}
}
