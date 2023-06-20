using Envelope.WcfUtils.Saml2.DataStore;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Security;

namespace Envelope.WcfUtils.Saml2.Helpers;

internal static class Saml2ControllerHelper
{
	internal static string GetStoredAuthnRequestIDKey(string id)
		=> $"{nameof(Saml2MessageTypeEnum.AuthnRequest)}{id}";

	internal static string GetStoredLogoutRequestIDKey(string id)
		=> $"{nameof(Saml2MessageTypeEnum.AuthnRequest)}{id}";

	internal static string? GetSessionIndexFromStore(ISaml2ModuleContext context, UserDataStore store)
		=> store.Get<string>(context, UserDataStore.SESSION_INDEX);

	internal static NameIDType? GetTicketNameID(ISaml2ModuleContext context)
	{
		if (context.Principal is not ISaml2Principal applicationCurrentUser)
			return null;

		return new NameIDType()
		{
			Value = applicationCurrentUser.NameID,
			Format = applicationCurrentUser.NameIDFormat,
			NameQualifier = applicationCurrentUser.NameIDIdp,
			SPNameQualifier = applicationCurrentUser.NameIDSp
		};
	}
}
