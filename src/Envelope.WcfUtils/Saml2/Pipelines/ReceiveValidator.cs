using Envelope;
using Envelope.WcfUtils.Saml2.Exceptions;
using Envelope.WcfUtils.Saml2.Helpers;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.Pipelines;

/// <summary>
/// Overuje hodnoty v deserializovanej sprave
/// Ak sa v konfigu vyzaduje overenie podpisu, validuje ci ReceiveSignature nastavil v model.Info uspesne overenie podpisu
/// Ak je v sprave aj Assertion, validuje sa aj to.
/// </summary>
internal class ReceiveValidator : MessageProcessingService
{
	internal override void ValidateModel(Saml2MessageModel model)
	{
		if (model == null)
			throw new ArgumentNullException(nameof(model));

		if (model.Info == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Info)}");

		if (string.IsNullOrWhiteSpace(model.Info.ReceivedDestination))
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Info)}.{nameof(model.Info.ReceivedDestination)}");

		if (model.Message == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Message)}");

		if (model.Sender == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Sender)}");
	}

	internal override void Process(Saml2MessageModel model)
	{
		var signaturesReuslt = ValidateSignatures(
			model.Info.MessageSignatureVerified,
			model.Info.SecondarySignatureVerified,
			model.Info.IsResponse,
			model.Info.MessageType == Saml2MessageTypeEnum.Response && ((ResponseType)model.Message).Assertion != null,
			model.Config.IncomingMessages?.WantRequestSinged,
			model.Config.IncomingMessages?.WantResponseSinged,
			model.Config.IncomingMessages?.WantAssertionSigned);

		var signatureAndVersionResult = $"{signaturesReuslt}{ValidateVersion(model.Message.Version)}";

		var destinationByServiceType = MetadataHelper.GetReceiverDestinationByServiceType(model.Receiver, model.Info.ServiceType, model.Info.Binding, model.Info.IsResponse);
		var destinationResult = 
			ValidateDestination(
				model.Info.ReceivedDestination,
				model.Message.Destination,
				destinationByServiceType,
				model.Info.ServiceType,
				model.Info.Binding,
				model.Config.IncomingMessages?.ValidateHttpHttps,
				model.Config.IncomingMessages?.ValidateDestinationUrl);

		var issueInstantResult =
			ValidateIssueInstant(
				GlobalContext.Instance.Now,
				model.Message.IssueInstant,
				model.Config.TimeToleranceSeconds,
				model.Config.IncomingMessages.MaxMessageAgeInSeconds);

		var issuerResult =
			ValidateIssuer(
				model.Message.Issuer,
				model.Sender.entityID);

		var result = $"{signatureAndVersionResult}{destinationResult}{issueInstantResult}{issuerResult}";
		
		if (model.Message is ResponseType message)
		{
			var responseStatus = MessageHelper.GetResponseStatus((ISaml2ResponseMessage)model.Message);
			if (responseStatus == "urn:oasis:names:tc:SAML:2.0:status:Success")
			{
				var assertion = message.Assertion;
				var tmp = ValidateAssertion(
					assertion,
					GlobalContext.Instance.Now,
					model.Config.TimeToleranceSeconds,
					model.Config.IncomingMessages.MaxMessageAgeInSeconds,
					model.Sender.entityID,
					model.Info.ReceivedDestination,
					model.Config.IncomingMessages.ValidateHttpHttps,
					model.Receiver.entityID,
					model.Config.IncomingMessages.ValidateDestinationUrl);
				result = $"{result}{tmp}";
			}
			else if (!MessageHelper.HasNoPassiveStatusCode((ISaml2ResponseMessage)model.Message))
			{
				throw new ResponseNotSuccessException(responseStatus!);
			}
		}

		if (!string.IsNullOrEmpty(result))
			throw new InvalidOperationException($"{model.Info.MessageType} validation error: {result}");
	}

	private static string ValidateAssertion(
		AssertionType? assertion,
		DateTime now,
		int timeTolerance,
		int maxMessageAge,
		string expectedIssuer,
		string destination,
		bool validateHttpHttps,
		string receiverEntityId,
		bool validateDestionationUrl)
	{
		if (assertion == null)
			return "Response message doesn't contain an Assertion";

		var versionAndIssueInstantResult = $"{ValidateVersion(assertion.Version)}{ValidateIssueInstant(now, assertion.IssueInstant, timeTolerance, maxMessageAge)}";

		var requiredFieldsResult = ValidateRequiredFields(assertion);

		string result;
		if (string.IsNullOrEmpty(requiredFieldsResult))
		{
			var versionAndIssueInstantResultAndIssuer = $"{versionAndIssueInstantResult}{ValidateIssuer(assertion.Issuer, expectedIssuer)}";
			var confirmationData = assertion.Subject.SubjectConfirmation?.SubjectConfirmationData;

			if (confirmationData?.NotBeforeSpecified == true)
				versionAndIssueInstantResultAndIssuer = $"{versionAndIssueInstantResultAndIssuer}{ValidateNotBefore(now, confirmationData.NotBefore, timeTolerance, "SubjectConfirationData NotBefore")}";

			if (confirmationData?.NotOnOrAfterSpecified == true)
				versionAndIssueInstantResultAndIssuer = $"{versionAndIssueInstantResultAndIssuer}{ValidateNotOnOrAfter(now, confirmationData.NotOnOrAfter, timeTolerance, "SubjectConfirationData NotOnOrAfter")}";

			if (confirmationData?.Recipient != null)
				versionAndIssueInstantResultAndIssuer = $"{versionAndIssueInstantResultAndIssuer}{ValidateRecipient(destination, confirmationData.Recipient, validateHttpHttps, validateDestionationUrl)}";

			result = $"{versionAndIssueInstantResultAndIssuer}{ValidateNotBefore(now, assertion.AuthnStatement.AuthnInstant, timeTolerance, "AuthnStatement AuthnInstant")}";
		}
		else
		{
			result = $"{versionAndIssueInstantResult}{requiredFieldsResult}{Environment.NewLine}{Environment.NewLine}";
		}

		if (assertion.Conditions != null)
		{
			if (assertion.Conditions.NotBeforeSpecified)
				result = $"{result}{ValidateNotBefore(now, assertion.Conditions.NotBefore, timeTolerance, "Conditions NotBefore")}";

			if (assertion.Conditions.NotOnOrAfterSpecified)
				result = $"{result}{ValidateNotOnOrAfter(now, assertion.Conditions.NotOnOrAfter, timeTolerance, "Conditions NotOnOrAfter")}";

			if (assertion.Conditions.AudienceRestriction?.Audience != null)
				result = $"{result}{ValidateAudienceRestriction(receiverEntityId, assertion.Conditions.AudienceRestriction.Audience)}";
		}

		if (!string.IsNullOrEmpty(result))
			result = $"Assertion validation error: {result}";

		return result;
	}

	private static string? ValidateVersion(string version)
		=> version != "2.0"
			? $"message version is not 2.0: {version}{Environment.NewLine}"
			: null;

	private static string? ValidateDestination(
		string received,
		string expected,
		string fromMetadata,
		Saml2ServiceTypeEnum serviceType,
		string binding,
		bool? validateHttpHttps,
		bool? validateDestionationUrl)
	{
		if (validateDestionationUrl != true)
			return null;

		string receivedUrl = GetDestinationUrl(received, validateHttpHttps);
		string expectedUrl = GetDestinationUrl(expected, validateHttpHttps);
		string fromMetadataUrl = GetDestinationUrl(fromMetadata, validateHttpHttps);

		if (receivedUrl != expectedUrl)
			return $"message destination differs from request url:  message destination: {expectedUrl}{Environment.NewLine}actual request url: {receivedUrl}{Environment.NewLine}";

		if (!(receivedUrl != fromMetadataUrl))
			return null;

		return $"message destination differs from metadata url: service {serviceType} and binding {binding} message destination: {expectedUrl}{Environment.NewLine} metadata destination: {fromMetadataUrl}{Environment.NewLine}";
	}

	private static string? ValidateIssueInstant(
		DateTime now,
		DateTime issueInstant,
		int timeTolerance,
		int maxMessgeAge)
	{
		now = now.ToUniversalTime();
		issueInstant = issueInstant.ToUniversalTime();
		var timeToleranceTimeSpan = TimeSpan.FromSeconds(timeTolerance);
		var maxMessgeAgeTimeSpan = TimeSpan.FromSeconds(maxMessgeAge);
		var dateTime1 = issueInstant - timeToleranceTimeSpan;
		var dateTime2 = issueInstant + maxMessgeAgeTimeSpan + timeToleranceTimeSpan;

		if (dateTime1 <= now && now <= dateTime2)
			return null;

		return $"message creation time is {(now < dateTime1 ? "in the future" : "in the past")}{Environment.NewLine}IssueInstant: {issueInstant:yyyy.MM.dd HH:mm:ss.fff UTC}{Environment.NewLine}{GetLocalTimeInfo(now, timeTolerance)}, message validity {maxMessgeAge}{Environment.NewLine}{Environment.NewLine}";
	}

	private static string? ValidateIssuer(NameIDType nameIdType, string expected)
	{
		if (nameIdType == null)
			return $"message Issuer is missing{Environment.NewLine}";

		if (!(nameIdType.Value != expected))
			return null;

		return $"message Issuer does not match metadata:{Environment.NewLine}message Issuer: {nameIdType.Value}metadata entityID: {expected}{Environment.NewLine}";
	}

	private static string? ValidateSignatures(
		bool messageSigned,
		bool secondaryMessageSigned,
		bool isResponse,
		bool isAssertion,
		bool? wantRequestSigned,
		bool? wantResponseSigned,
		bool? wantAssertionSigned)
	{
		if (isResponse)
		{
			if (wantResponseSigned == true && !messageSigned)
				return $"response message signature is invalid, or the message is not signed.{Environment.NewLine}If certificate validation is turned on in config(incomingMessages - validateIdpCert), check if the signing certificate si considered valid on the SP machine{Environment.NewLine}";
			
			if (isAssertion == true & wantAssertionSigned == true && !secondaryMessageSigned)
				return $"response Assertion signature is invalid, or the Assertion is not signed{Environment.NewLine}If certificate validation is turned on in config(incomingMessages - validateIdpCert), check if the signing certificate si considered valid on the SP machine{Environment.NewLine}";
		}
		else if (wantRequestSigned == true && !messageSigned)
			return $"request signature is invalid, or the request is not signed{Environment.NewLine}If certificate validation is turned on in config(incomingMessages - validateIdpCert), check if the signing certificate si considered valid on the SP machine{Environment.NewLine}";

		return null;
	}

	private static string RemoveUrlHttpProtocol(string url)
	{
		if (url.StartsWith("http://"))
			return url.Substring("http://".Length);

		return !url.StartsWith("https://") ? url : url.Substring("https://".Length);
	}

	private static string GetDestinationUrl(string url, bool? validateHttpHttps)
	{
		var urlLeftPart = new Uri(url).GetLeftPart(UriPartial.Path);

		if (validateHttpHttps != true)
			urlLeftPart = RemoveUrlHttpProtocol(urlLeftPart);

		return urlLeftPart;
	}

	private static string? ValidateRequiredFields(AssertionType assertion)
	{
		if (assertion.Issuer == null)
			return "assertion issuer is missing";

		if (assertion.Subject == null)
			return "assertion Subject is missing";

		if (string.IsNullOrEmpty(assertion.Subject.NameID?.Value))
			return "assertion Subject NameID is missing or has no value";

		if (string.IsNullOrEmpty(assertion.Subject.NameID.Format))
			return "assertion Subject NameID Format is missing or has no value";

		if (string.IsNullOrEmpty(assertion.Subject.NameID.NameQualifier))
			return "assertion Subject NameID NameQualifier is missing or has no value";

		if (string.IsNullOrEmpty(assertion.Subject.NameID.SPNameQualifier))
			return "assertion Subject NameID SPNameQualifier is missing or has no value";

		if (assertion.Subject.SubjectConfirmation == null)
			return "assertion Subject has no SubjectConfirmation";

		if (assertion.Subject.SubjectConfirmation.SubjectConfirmationData == null)
			return "assertion SubjectConfirmation has no SubjectConfirmationData";

		if (assertion.AuthnStatement == null)
			return "assertion AuthnStatement is missing";

		if (assertion.AuthnStatement.AuthnInstant == DateTime.MinValue)
			return "assertion AuthnStatement AuthnInstant is missing or empty";

		if (assertion.AuthnStatement.AuthnContext == null)
			return "assertion AuthnStatement has no AuthnContext";

		if (string.IsNullOrEmpty(assertion.AuthnStatement.SessionIndex))
			return "assertion AuthnStatement SessionIndex is empty";

		return (assertion.AuthnStatement.AuthnContext.Items == null || assertion.AuthnStatement.AuthnContext.Items.Length == 0)
			? "assertion AuthnStatement AuthnContext is empty"
			: null;
	}

	private static string? ValidateNotOnOrAfter(
		DateTime now,
		DateTime value,
		int timeTolerance,
		string propertyName)
	{
		now = now.ToUniversalTime();
		value = value.ToUniversalTime();
		var timeSpan = TimeSpan.FromSeconds((double)timeTolerance);

		if (!(value + timeSpan <= now))
			return null;

		return $"{propertyName} is in the past:{Environment.NewLine}value: {value:yyyy.MM.dd HH:mm:ss.fff UTC}{Environment.NewLine}{GetLocalTimeInfo(now, timeTolerance)}{Environment.NewLine}{Environment.NewLine}";
	}

	private static string? ValidateNotBefore(
		DateTime now,
		DateTime value,
		int timeTolerance,
		string propertyName)
	{
		now = now.ToUniversalTime();
		value = value.ToUniversalTime();
		var timeSpan = TimeSpan.FromSeconds(timeTolerance);

		if (!(now < value - timeSpan))
			return null;

		return $"{propertyName} is in the future:{Environment.NewLine}value: {value:yyyy.MM.dd HH:mm:ss.fff UTC}{Environment.NewLine}{GetLocalTimeInfo(now, timeTolerance)}{Environment.NewLine}{Environment.NewLine}";
	}

	private static string? ValidateRecipient(
		string destination,
		string recipient,
		bool validateHttpHttps,
		bool validateDestionationUrl)
	{
		if (!validateDestionationUrl)
			return null;

		var recipientUrl = GetDestinationUrl(recipient, validateHttpHttps);
		var destinationUrl = GetDestinationUrl(destination, validateHttpHttps);

		if (!(recipientUrl != destinationUrl))
			return null;

		return $"SubjectConfirationData Recipient doesn't match the message destination: {Environment.NewLine}recipient: {recipientUrl}{Environment.NewLine} message destination: {destinationUrl}{Environment.NewLine}{Environment.NewLine}";
	}

	private static string GetLocalTimeInfo(DateTime now, int timeTolerance)
		=> $"local time is {now:yyyy.MM.dd HH:mm:ss.fff UTC}, time toleracne {timeTolerance} seconds";

	private static string? ValidateAudienceRestriction(
		string receiverEntityId,
		string[] audienceRestriction)
	{
		if (audienceRestriction.Contains(receiverEntityId))
			return null;

		return $"Audience restriction doesn't match receiver entityID: {Environment.NewLine}Audience restriction: {string.Join(", ", audienceRestriction)}{Environment.NewLine}Receiver entityID: {receiverEntityId}{Environment.NewLine}{Environment.NewLine}";
	}
}