using Envelope.Validation;

namespace Envelope.WcfUtils.Saml2.Config;

public class DataCacheConfig : IValidable
{
	public int SamlRequestLifespanSeconds { get; set; } = 1200;
	public string? CookieName{ get; set; }
	public string? CookiePath{ get; set; }

	public List<IValidationMessage>? Validate(
		string? propertyPrefix = null,
		ValidationBuilder? validationBuilder = null,
		Dictionary<string, object>? globalValidationContext = null,
		Dictionary<string, object>? customValidationContext = null)
	{
		validationBuilder ??= new ValidationBuilder();
		validationBuilder.SetValidationMessages(propertyPrefix, globalValidationContext)
			.If(SamlRequestLifespanSeconds <= 0)
			.IfNullOrWhiteSpace(CookieName)
			.IfNullOrWhiteSpace(CookiePath);

		return validationBuilder.Build();
	}
}
