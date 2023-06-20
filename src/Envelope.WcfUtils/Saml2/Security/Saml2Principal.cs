using Envelope.Exceptions;
using Envelope.Identity;
using System.Security.Principal;

namespace Envelope.WcfUtils.Saml2.Security;

[Serializable]
public class Saml2Principal : EnvelopePrincipal, ISaml2Principal, IPrincipal
{
	internal PrincipalTicketInfo TicketInfo { get; }

	public DateTime ValidTo => TicketInfo?.ValidTo ?? default;

	internal PrincipalSessionInfo SessionInfo { get; }

	internal bool IsFromAssertion { get; }

	public string NameID => TicketInfo.Id;

	public string NameIDFormat => TicketInfo.IdFormat;

	public string NameIDIdp => TicketInfo.IdIdp;

	public string NameIDSp => TicketInfo.IdSp;

	public string SessionIndex => TicketInfo.SessionIndex;

	public string Assertion => SessionInfo.Assertion;

	public IEnumerable<string> Roles => SessionInfo.Roles;

	internal Saml2Principal(
		PrincipalTicketInfo ticketInfo,
		PrincipalSessionInfo sessionInfo,
		bool isFromAssertion)
		: base(new Saml2Identity(ticketInfo, sessionInfo, true))
	{
		Throw.ArgumentNull(ticketInfo);
		Throw.ArgumentNull(sessionInfo);

		SessionInfo = sessionInfo;
		TicketInfo = ticketInfo;
		IsFromAssertion = isFromAssertion;
	}
}
