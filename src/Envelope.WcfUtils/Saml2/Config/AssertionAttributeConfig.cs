using Envelope.Validation;

namespace Envelope.WcfUtils.Saml2.Config;

public class AssertionAttributeConfig : IValidable
{
	public string UserNameAttribute { get; set; } = "SubjectID";
	public string RolesAttribute { get; set; } = "Role";
	public List<RoleMappingRecord> RoleMappingRecords { get; set; }

	public List<IValidationMessage>? Validate(
		string? propertyPrefix = null,
		ValidationBuilder? validationBuilder = null,
		Dictionary<string, object>? globalValidationContext = null,
		Dictionary<string, object>? customValidationContext = null)
	{
		validationBuilder ??= new ValidationBuilder();
		validationBuilder.SetValidationMessages(propertyPrefix, globalValidationContext)
			.IfNullOrWhiteSpace(UserNameAttribute)
			.IfNullOrWhiteSpace(RolesAttribute)
			.Validate(RoleMappingRecords);

		return validationBuilder.Build();
	}
}

public class RoleMappingRecord : IValidable
{
	public string Name { get; set; }
	public string? Prefix { get; set; }
	public string Regex { get; set; }

	public List<IValidationMessage>? Validate(
		string? propertyPrefix = null,
		ValidationBuilder? validationBuilder = null,
		Dictionary<string, object>? globalValidationContext = null,
		Dictionary<string, object>? customValidationContext = null)
	{
		validationBuilder ??= new ValidationBuilder();
		validationBuilder.SetValidationMessages(propertyPrefix, globalValidationContext)
			.IfNullOrWhiteSpace(Name)
			.IfNullOrWhiteSpace(Regex);

		return validationBuilder.Build();
	}
}
