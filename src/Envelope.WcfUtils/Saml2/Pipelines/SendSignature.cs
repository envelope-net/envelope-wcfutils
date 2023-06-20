using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using Envelope.WcfUtils.Saml2.Helpers;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.Pipelines;


/// <summary>Podpisuje spravu, ak je treba</summary>
internal class SendSignature : MessageProcessingService
{
	internal override void ValidateModel(Saml2MessageModel model)
	{
		if (model == null)
			throw new ArgumentNullException(nameof(model));

		if (model.Info == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Info)}");

		if (string.IsNullOrWhiteSpace(model.Info.Binding))
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Info)}.{nameof(model.Info.Binding)}");

		if (string.IsNullOrWhiteSpace(model.MessageRaw))
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Message)}");

		if (model.Sender == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Sender)}");
	}

	internal override void Process(Saml2MessageModel model)
	{
		if (!model.Info.SignMessage)
			return;

		try
		{
			var metadataCertificate = CertificateHelper.GetMetadataCertificate(model.Config, model.Sender, KeyTypes.signing, true);
			switch (model.Info.Binding)
			{
				case "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST":
					var xmlDocument = SignXml(metadataCertificate, model.MessageRaw);
					model.MessageRaw = xmlDocument.OuterXml;
					break;
				case "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-Redirect":
					var stringWithSignAlg = BindingHelper.GetRedirectQueryStringWithSignAlg(model.MessageRaw, model.Info.IsResponse);
					model.UrlSignature = SignString(metadataCertificate, stringWithSignAlg);
					break;
				default:
					throw new InvalidOperationException($"Unsupported binding type: {model.Info.Binding}");
			}
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Error while signing saml message", ex);
		}
	}

	private static XmlDocument SignXml(X509Certificate2 cert, string xml)
	{
		var privateKey = (RSACryptoServiceProvider)cert.PrivateKey;
		var reference = new Reference()
		{
			Uri = string.Empty
		};

		reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
		reference.AddTransform(new XmlDsigExcC14NTransform());

		var document = new XmlDocument();
		document.LoadXml(xml);

		var signedXml = new SignedXml(document)
		{
			SigningKey = privateKey
		};
		signedXml.KeyInfo.AddClause(new KeyInfoX509Data(cert));
		signedXml.AddReference(reference);
		signedXml.ComputeSignature();

		var documentElement = document.DocumentElement;
		if (documentElement == null)
			return document;

		documentElement.AppendChild(signedXml.GetXml());
		return document;
	}

	private static byte[] SignString(X509Certificate2 cert, string str)
	{
		var signatureFormatter = new RSAPKCS1SignatureFormatter(cert.PrivateKey);
		signatureFormatter.SetHashAlgorithm("SHA256");
		return signatureFormatter.CreateSignature(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(str)));
	}
}
