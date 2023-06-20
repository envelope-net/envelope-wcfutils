using Envelope.Validation;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Serializers;

namespace Envelope.WcfUtils.Saml2.Config;

public interface ISaml2Config : IValidable, IInitializationValidable
{
	string CurrentDirectory { get; }

	string SpMetadataFileRelativePath { get; }
	string IdpMetadataFileRelativePath { get; }
	public string? PostBindingHtmlFilePath { get; set; }
	int CookieTimeoutInMinutes { get; }
	int TimeToleranceSeconds { get; }
	Saml2OutgoingMessagesConfig? OutgoingMessages { get; }
	Saml2IncomingMessagesConfig? IncomingMessages { get; }
	CertificateStoreConfig? CertificateStore { get; }
	DataCacheConfig? DataCache { get; }
	AssertionAttributeConfig? AssertionAttributes { get; }
	string SamlRefreshUrl { get; }
	int SamlRefreshInterval { get; }
	int SessionExpirationOffset { get; }

	EntityDescriptorType SpMetadata { get; }
	EntityDescriptorType IdpMetadata { get; }
	string? PostBindingHtml { get; }
	ISerializer Serializer { get; }

	void Initialize();
}
