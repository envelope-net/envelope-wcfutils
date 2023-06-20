using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using Envelope.WcfUtils.Saml2.Helpers;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.Pipelines;

/// <summary>
/// Overi podpisy v prichadzajucej sprave. Ak je v sprave assertion, overi aj jeho podpis.
/// Vysledky overenia ulozi do model.Info
/// </summary>
internal class ReceiveSignature : MessageProcessingService
{
	internal override void ValidateModel(Saml2MessageModel model)
	{
		if (model == null)
			throw new ArgumentNullException(nameof(model));

		if (model.Info == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Info)}");

		if (string.IsNullOrWhiteSpace(model.Info.Binding))
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Info)}.{nameof(model.Info.Binding)}");

		if (string.IsNullOrWhiteSpace(model.Info.ReceivedDestination))
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Info)}.{nameof(model.Info.ReceivedDestination)}");

		if (string.IsNullOrWhiteSpace(model.MessageRaw))
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Message)}");

		if (model.Sender == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Sender)}");
	}

	internal override void Process(Saml2MessageModel model)
	{
		var metadataCertificate = CertificateHelper.GetMetadataCertificate(model.Config, model.Sender, KeyTypes.signing, false);

		model.Info.MessageSignatureVerified = model.Info.Binding switch
		{
			"urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" => VerifyTopXmlSignature(metadataCertificate, model.MessageRaw, model.Config.IncomingMessages.ValidateIdpCert),
			"urn:oasis:names:tc:SAML:2.0:bindings:HTTP-Redirect" => VerifyUrlSignature(metadataCertificate, model.Info.ReceivedDestination, model.UrlSignature, model.Config.IncomingMessages.ValidateIdpCert),
			_ => throw new InvalidOperationException("Binding not supported: {model.Info.Binding}"),
		};

		model.Info.SecondarySignatureVerified = VerifyAssertionSignature((ResponseType)model.Message, metadataCertificate, model.Config.IncomingMessages.ValidateIdpCert);
	}

	private static bool VerifyAssertionSignature(
		ResponseType response,
		X509Certificate2 cert,
		bool validateIdpCert)
	{
		return !string.IsNullOrEmpty(response?.AssertionRaw) && VerifyTopXmlSignature(cert, response.AssertionRaw, validateIdpCert);
	}

	private static bool VerifyTopXmlSignature(X509Certificate2 cert, string xml, bool validateCert)
	{
		try
		{
			var xmlDocument = new XmlDocument()
			{
				PreserveWhitespace = true
			};

			xmlDocument.LoadXml(xml);
			var namespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
			namespaceManager.AddNamespace("zyxq987", "urn:oasis:names:tc:SAML:2.0:protocol");
			namespaceManager.AddNamespace("zyxq987dsig", "http://www.w3.org/2000/09/xmldsig#");
			var xmlElement = VerifySignatureIntegrity(xmlDocument);

			if (xmlElement == null)
				return false;

			var signedXml = new SignedXml(xmlDocument);
			signedXml.LoadXml(xmlElement);
			var flag = signedXml.CheckSignature(cert, true);
			
			if (validateCert)
				flag &= CertificateHelper.ValidateCertificate(cert);

			return flag;
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Error while verifying xml message signature", ex);
		}
	}

	private static XmlElement? VerifySignatureIntegrity(XmlDocument doc)
	{
		var childElements1 = GetChildElements(doc.DocumentElement, "Signature", "http://www.w3.org/2000/09/xmldsig#");
		if (childElements1.Count != 1)
			return null;

		var childElements2 = GetChildElements(childElements1[0], "SignedInfo", "http://www.w3.org/2000/09/xmldsig#");
		if (childElements2.Count != 1)
			return null;

		var childElements3 = GetChildElements(childElements2[0], "Reference", "http://www.w3.org/2000/09/xmldsig#");
		if (childElements3.Count != 1)
			return null;

		var str1 = childElements3[0].Attributes["URI"].Value;
		if (doc.DocumentElement == null)
			return childElements1[0];

		var str2 = "#" + doc.DocumentElement.Attributes["ID"].Value;

		return (str1 != string.Empty && str1 != str2)
			? null
			: childElements1[0];
	}

	private static bool VerifyUrlSignature(
		X509Certificate2 cert,
		string url,
		byte[] signature,
		bool validateCertificate)
	{
		if (signature == null)
			return false;

		string s;
		try
		{
			var seed = new Uri(url).Query.Substring(1);
			s = seed.Split('&').Where(param => param.StartsWith("Signature=")).Aggregate(seed, (current, param) => current.Replace($"&{param}", string.Empty));
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException($"Url malformed: {url}", ex);
		}

		bool flag;
		try
		{
			var signatureDeformatter = new RSAPKCS1SignatureDeformatter(cert.PublicKey.Key);
			signatureDeformatter.SetHashAlgorithm("SHA256");
			flag = signatureDeformatter.VerifySignature(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(s)), signature);
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException($"Error while verifying url signature: {url}", ex);
		}

		if (validateCertificate)
			flag &= CertificateHelper.ValidateCertificate(cert);

		return flag;
	}

	private static IList<XmlElement> GetChildElements(XmlNode parent, string localName, string ns)
	{
		var childElements = new List<XmlElement>();

		foreach (XmlElement parent1 in parent.ChildNodes.OfType<XmlElement>())
		{
			if (parent1.LocalName == localName && parent1.NamespaceURI == ns)
				childElements.Add(parent1);

			if (parent1.HasChildNodes)
				childElements.AddRange(GetChildElements(parent1, localName, ns));
		}

		return childElements;
	}
}
