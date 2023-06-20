﻿using Envelope.WcfUtils.Saml2.Config;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Serializers;

namespace Envelope.WcfUtils.Saml2.Security;

internal static class PrincipalService
{
	public static Saml2Principal? CreatePrincipal(
		AssertionType assertion,
		string assertionRaw,
		AssertionAttributeConfig? attrConfig)
	{
		if (attrConfig == null)
			return null;

		assertion.Attributes.MapAttributeValues(attrConfig);

		var multiValue = assertion.Attributes.GetMultiValue(attrConfig.RolesAttribute);
		return 
			new Saml2Principal(
				new PrincipalTicketInfo()
				{
					Username = GetUserNameOrNameID(assertion, attrConfig),
					AuthnType = assertion.AuthnContextClassRef,
					SessionIndex = assertion.AuthnStatement.SessionIndex,
					Id = assertion.Subject.NameID.Value,
					IdFormat = assertion.Subject.NameID.Format,
					IdIdp = assertion.Subject.NameID.NameQualifier,
					IdSp = assertion.Subject.NameID.SPNameQualifier,
					ValidTo = assertion.AuthnStatement.SessionNotOnOrAfter
				},
				new PrincipalSessionInfo()
				{
					Assertion = assertionRaw,
					Attributes = CreateAttributeDictionary(assertion),
					Roles = multiValue
				},
				true);
	}

	public static void StorePrincipal(
		Action<DateTime, string, string> addCookieToResponse,
		ISerializer serializer,
		Saml2Principal principal)
	{
		if (addCookieToResponse == null)
			throw new ArgumentNullException(nameof(addCookieToResponse));

		if (serializer == null)
			throw new ArgumentNullException(nameof(serializer));

		if (principal == null)
			throw new ArgumentNullException(nameof(principal));

		var issueDate = GlobalContext.Instance.Now;
		var userName = principal.Identity.Name!;
		var userData = $"[Saml2Principal]{serializer.Serialize(principal.TicketInfo)}";
		addCookieToResponse(issueDate, userName, userData);
	}

	public static Saml2Principal LoadPrincipal(
		ISerializer serializer,
		string principalTicketInfoSerialized,
		PrincipalSessionInfo sessionInfo)
	{
		try
		{
			var ticketInfo = serializer.Deserialize<PrincipalTicketInfo>(principalTicketInfoSerialized);

			return new Saml2Principal(ticketInfo!, sessionInfo, false);
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException($"Unable to restore {nameof(Saml2Principal)}", ex);
		}
	}

	private static Dictionary<string, List<string>> CreateAttributeDictionary(AssertionType assertion)
	{
		var attributeDictionary = new Dictionary<string, List<string>>();

		foreach (var attributeName in assertion.Attributes.GetAttributeNames())
		{
			var multiValue = assertion.Attributes.GetMultiValue(attributeName);
			attributeDictionary.Add(attributeName, multiValue);
		}

		return attributeDictionary;
	}

	private static string? GetUserNameOrNameID(
		AssertionType assertion,
		AssertionAttributeConfig attrConfig)
	{
		var userNameOrNameId = assertion.Attributes.GetValue(attrConfig.UserNameAttribute);

		if (string.IsNullOrEmpty(userNameOrNameId))
			userNameOrNameId = assertion.Subject.NameID?.Value;

		return userNameOrNameId;
	}
}