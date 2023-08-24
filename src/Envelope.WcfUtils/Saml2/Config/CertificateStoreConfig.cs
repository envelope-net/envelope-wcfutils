using Envelope.Validation;

namespace Envelope.WcfUtils.Saml2.Config;

public class CertificateStoreConfig : IValidable
{
	public string? CertificateFileFullPath { get; set; }
	public string? CertificatePassword { get; set; }

	public string StoreLocation { get; set; } = "LocalMachine";

	public System.Security.Cryptography.X509Certificates.StoreLocation StoreLocationEnum => 
		(System.Security.Cryptography.X509Certificates.StoreLocation) Enum.Parse(typeof(System.Security.Cryptography.X509Certificates.StoreLocation), StoreLocation);

	public string StoreName { get; set; } = "My";

	public System.Security.Cryptography.X509Certificates.StoreName StoreNameEnum =>
		(System.Security.Cryptography.X509Certificates.StoreName) Enum.Parse(typeof(System.Security.Cryptography.X509Certificates.StoreName), StoreName);

	public System.Security.Cryptography.X509Certificates.X509FindType FindTypeEnum
		=> System.Security.Cryptography.X509Certificates.X509FindType.FindByThumbprint;

	public List<IValidationMessage>? Validate(
		string? propertyPrefix = null,
		ValidationBuilder? validationBuilder = null,
		Dictionary<string, object>? globalValidationContext = null,
		Dictionary<string, object>? customValidationContext = null)
	{
		validationBuilder ??= new ValidationBuilder();
		validationBuilder.SetValidationMessages(propertyPrefix, globalValidationContext)
			.IfNullOrWhiteSpace(StoreLocation)
			.IfNullOrWhiteSpace(StoreName);

		return validationBuilder.Build();
	}
}
