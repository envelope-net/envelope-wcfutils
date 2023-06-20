using Envelope.Validation;

namespace Envelope.WcfUtils.Saml2.Config;

public class Saml2IncomingMessagesConfig : IValidable
{
	public bool? WantRequestSinged { get; set; } = true;
	public bool? WantResponseSinged { get; set; } = true;
	public bool WantAssertionSigned { get; set; } = true;
	public bool ValidateIdpCert { get; set; } = true;
	public bool ValidateHttpHttps { get; set; } = true;
	public int MaxMessageAgeInSeconds { get; set; }
	public bool ValidateDestinationUrl { get; set; } = true;

	public List<IValidationMessage>? Validate(
		string? propertyPrefix = null,
		ValidationBuilder? validationBuilder = null,
		Dictionary<string, object>? globalValidationContext = null,
		Dictionary<string, object>? customValidationContext = null)
	{
		validationBuilder ??= new ValidationBuilder();
		validationBuilder.SetValidationMessages(propertyPrefix, globalValidationContext)
			.If(MaxMessageAgeInSeconds <= 0);

		return validationBuilder.Build();
	}
}
