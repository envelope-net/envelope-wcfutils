using Envelope.Exceptions;
using Envelope.Identity;
using System.Security.Principal;

namespace Envelope.WcfUtils.Saml2.Security;

[Serializable]
public class Saml2Principal : EnvelopePrincipal, ISaml2Principal, IPrincipal
{
	internal PrincipalTicketInfo TicketInfo { get; }

	public DateTime ValidTo => TicketInfo?.ValidTo ?? default;

	public PrincipalSessionInfo SessionInfo { get; }

	internal bool IsFromAssertion { get; }

	public string NameID => TicketInfo.Id;

	public string NameIDFormat => TicketInfo.IdFormat;

	public string NameIDIdp => TicketInfo.IdIdp;

	public string NameIDSp => TicketInfo.IdSp;

	public string SessionIndex => TicketInfo.SessionIndex;

	public string Assertion => SessionInfo.Assertion;

	public IEnumerable<string> Roles => SessionInfo.Roles;

	public string FormsAuthenticationTicketUserData { get; }

	public Saml2Principal(
		PrincipalTicketInfo ticketInfo,
		PrincipalSessionInfo sessionInfo,
		bool isFromAssertion,
		string formsAuthenticationTicketUserData,
		object? userData)
		: base(new Saml2Identity(ticketInfo, sessionInfo, true, formsAuthenticationTicketUserData, userData))
	{
		Throw.ArgumentNull(ticketInfo);
		Throw.ArgumentNull(sessionInfo);

		TicketInfo = ticketInfo;
		SessionInfo = sessionInfo;
		IsFromAssertion = isFromAssertion;
		FormsAuthenticationTicketUserData = formsAuthenticationTicketUserData;
	}
}
