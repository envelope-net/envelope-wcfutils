using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using Envelope.WcfUtils.Saml2.Config;
using Envelope.WcfUtils.Saml2.Helpers;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.Pipelines;

/// <summary>
/// Deserializuje model.MessageRaw, a objekt ulozi do model.Message
/// Ak v Response najde zasifrovane assertion, desifruje ho a potom ho tiez deserializuje
/// Nastavi model.Info, aby bolo jasne co to je za spravu.
/// </summary>
internal class ReceiveDeserializer : MessageProcessingService
{
	internal override void ValidateModel(Saml2MessageModel model)
	{
		if (model == null)
			throw new ArgumentNullException(nameof(model));

		if (model.Info == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Info)}");

		if (string.IsNullOrWhiteSpace(model.MessageRaw))
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Info)}.{nameof(model.MessageRaw)}");

		if (model.Receiver == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Receiver)}");
	}

	internal override void Process(Saml2MessageModel model)
	{
		var responseXmlDoc = new XmlDocument();
		try
		{
			responseXmlDoc.LoadXml(model.MessageRaw);
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException($"Error while reading received xml message: {model.MessageRaw}", ex);
		}

		if (responseXmlDoc.DocumentElement == null)
			throw new InvalidOperationException("Received xml is not a SAML2 message");

		if (responseXmlDoc.DocumentElement.NamespaceURI != "urn:oasis:names:tc:SAML:2.0:protocol")
			throw new InvalidOperationException($"Received xml is not a SAML2 message: {responseXmlDoc.DocumentElement.NamespaceURI}:{responseXmlDoc.DocumentElement.LocalName}");

		Saml2MessageTypeEnum saml2MessageTypeEnum;
		try
		{
			saml2MessageTypeEnum = (Saml2MessageTypeEnum)Enum.Parse(typeof(Saml2MessageTypeEnum), responseXmlDoc.DocumentElement.LocalName);
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException($"Message type not supported: {responseXmlDoc.DocumentElement.LocalName}", ex);
		}

		switch (saml2MessageTypeEnum)
		{
			case Saml2MessageTypeEnum.AuthnRequest:
				model.Info.ServiceType = Saml2ServiceTypeEnum.SingleSignOnService;
				model.Message = Envelope.Serializer.XmlSerializerHelper.ReadFromString<AuthnRequestType>(model.MessageRaw)!;
				break;
			case Saml2MessageTypeEnum.LogoutRequest:
				model.Info.ServiceType = Saml2ServiceTypeEnum.SingleLogoutService;
				model.Message = Envelope.Serializer.XmlSerializerHelper.ReadFromString<LogoutRequestType>(model.MessageRaw)!;
				break;
			case Saml2MessageTypeEnum.Response:
				model.Info.ServiceType = Saml2ServiceTypeEnum.AssertionConsumerService;
				model.Info.IsResponse = true;
				model.Message = Envelope.Serializer.XmlSerializerHelper.ReadFromString<ResponseType>(model.MessageRaw)!;
				break;
			case Saml2MessageTypeEnum.LogoutResponse:
				model.Info.ServiceType = Saml2ServiceTypeEnum.SingleLogoutService;
				model.Info.IsResponse = true;
				model.Message = Envelope.Serializer.XmlSerializerHelper.ReadFromString<LogoutResponseType>(model.MessageRaw)!;
				break;
			default:
				throw new InvalidOperationException($"message type not supported: {saml2MessageTypeEnum}");
		}
		
		model.Info.MessageType = saml2MessageTypeEnum;
		
		if (model.Info.IsResponse != model.Info.ReceivedIsResponse)
		{
			if (model.Info.ReceivedIsResponse)
				throw new InvalidOperationException($"message received inside SAMLResponse parameter is a request: {saml2MessageTypeEnum}");

			throw new InvalidOperationException($"message received inside SAMLRequest paramter is a response: {saml2MessageTypeEnum}");
		}

		if (saml2MessageTypeEnum != Saml2MessageTypeEnum.Response)
			return;

		ProcessResponse(model.Config, model.Receiver, (ResponseType)model.Message, responseXmlDoc);
	}

	private static void ProcessResponse(
		ISaml2Config config,
		EntityDescriptorType receiver,
		ResponseType response,
		XmlDocument responseXmlDoc)
	{
		var namespaceManager = new XmlNamespaceManager(responseXmlDoc.NameTable);
		namespaceManager.AddNamespace("zyxq987", "urn:oasis:names:tc:SAML:2.0:protocol");
		namespaceManager.AddNamespace("zyxq987asser", "urn:oasis:names:tc:SAML:2.0:assertion");

		if (response.Assertion != null)
		{
			XmlNode xmlNode = responseXmlDoc.SelectSingleNode("/zyxq987:Response/zyxq987asser:Assertion[1]", namespaceManager);
			if (xmlNode != null)
				response.AssertionRaw = xmlNode.OuterXml;
		}

		if (response.EncryptedAssertion == null)
			return;

		response.AssertionRaw = Decrypt(config, receiver, response.EncryptedAssertion, responseXmlDoc, namespaceManager);
		response.Assertion = Envelope.Serializer.XmlSerializerHelper.ReadFromString<AssertionType>(response.AssertionRaw);
	}

	private static string? Decrypt(
		ISaml2Config config,
		EntityDescriptorType receiver,
		EncryptedElementType encryptedElem,
		XmlDocument doc,
		XmlNamespaceManager nsMgr)
	{
		var certificate = CertificateHelper.GetMetadataCertificate(config, receiver, KeyTypes.encryption, true);

		try
		{
			if (certificate.PrivateKey is System.Security.Cryptography.RSACng rsaCngPrivateKey)
			{
				var rgb = (byte[])encryptedElem.EncryptedKey[0].CipherData.Item;
				var numArray = rsaCngPrivateKey.Decrypt(rgb, RSAEncryptionPadding.Pkcs1);
				var aes = Aes.Create();

				if (aes == null)
					return null;

				aes.Key = numArray;
				var encryptedData = new EncryptedData();

				if (doc.SelectSingleNode("/zyxq987:Response/zyxq987asser:EncryptedAssertion[1]/node()[local-name()='EncryptedData']", nsMgr) is XmlElement xmlElement)
					encryptedData.LoadXml(xmlElement);

				return Encoding.UTF8.GetString(new EncryptedXml(doc).DecryptData(encryptedData, aes));
			}
			else
			{
				var privateKey = (RSACryptoServiceProvider)certificate.GetRSAPrivateKey();
				var rgb = (byte[])encryptedElem.EncryptedKey[0].CipherData.Item;
				var numArray = privateKey.Decrypt(rgb, false);
				var aes = Aes.Create();

				if (aes == null)
					return null;

				aes.Key = numArray;
				var encryptedData = new EncryptedData();

				if (doc.SelectSingleNode("/zyxq987:Response/zyxq987asser:EncryptedAssertion[1]/node()[local-name()='EncryptedData']", nsMgr) is XmlElement xmlElement)
					encryptedData.LoadXml(xmlElement);

				return Encoding.UTF8.GetString(new EncryptedXml(doc).DecryptData(encryptedData, aes));
			}
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Cannot decrypt encrypted assertion", ex);
		}
	}
}
