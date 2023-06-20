//using Envelope.Validation;
//using System.Xml.Serialization;
//using Envelope.WcfUtils.Saml2.Helpers;
//using Envelope.WcfUtils.Saml2.Model;

//namespace Envelope.WcfUtils.Saml2.Messages;

///// <summary>
///// element LogoutResponse sa nevygeneroval cez generator (ale jeho complexType StatusResponse tam je), takze rucne strucne:
///// </summary>
///// <seealso cref="T:Envelope.WcfUtils.Saml2.Messages.StatusResponseType" />
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot("LogoutResponse", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
//[Serializable]
//public class LogoutResponseType : StatusResponseType
//{
//}

//public partial class StatusResponseType : ISaml2ResponseMessage, ISaml2Message
//{
//	public StatusResponseType()
//	{
//		Version = "2.0";
//	}

//	[System.Xml.Serialization.XmlIgnore]
//	public string? StatusCode
//	{
//		get => MessageHelper.GetResponseStatus(this);
//		set => MessageHelper.SetResponseStatus(this, value!);
//	}

//	[System.Xml.Serialization.XmlIgnore]
//	public string? SecondLevelStatusCode
//	{
//		get => MessageHelper.GetSecondLevelResponseStatus(this);
//		set => MessageHelper.SetResponseStatus(this, value!);
//	}
//}

//public abstract partial class RequestAbstractType : ISaml2Message
//{
//	public RequestAbstractType()
//	{
//		Version = "2.0";
//	}
//}

//public partial class AssertionType
//{

//	/// <summary>
//	/// zvlast serizalizacia pre datumy, OIF vyzaduje v datumoch milisekundy
//	/// </summary>
//	/// <value>The custom issue instant.</value>
//	[System.Xml.Serialization.XmlAttribute("IssueInstant")]
//	public string CustomIssueInstant
//	{
//		get => MessageHelper.DateToString(issueInstantField);
//		set => issueInstantField = MessageHelper.DateFromString(value);
//	}

//	/// <summary>Gets the authn statement.</summary>
//	/// <value>The authn statement.</value>
//	public AuthnStatementType? AuthnStatement => (Items == null || Items.Length == 0)
//		? null
//		: (Items.FirstOrDefault(item => item is AuthnStatementType) as AuthnStatementType);

//	public string? AuthnContextClassRef => (AuthnStatement?.AuthnContext?.Items == null || AuthnStatement.AuthnContext.Items.Length == 0)
//		? null
//		: AuthnStatement.AuthnContext.Items[0] as string;

//	private AssertionAttributes _attributes;
//	internal AssertionAttributes Attributes => _attributes ??= new AssertionAttributes(Items);

//}

//public partial class ResponseType : StatusResponseType
//{
//	public string AssertionRaw { get; set; }

//	public AssertionType? Assertion
//	{
//		get => (Items != null && Items.Length != 0)
//			? Items[0] as AssertionType
//			: null;

//		set
//		{
//			if (Items == null || Items.Length != 1)
//				Items = new object[1];

//			Items[0] = value!;
//		}
//	}

//	public EncryptedElementType? EncryptedAssertion
//	{
//		get => (Items != null && Items.Length != 0)
//			? Items[0] as EncryptedElementType
//			: null;

//		set
//		{
//			if (Items == null || Items.Length != 1)
//				Items = new object[1];

//			Items[0] = value!;
//		}
//	}
//}

//public partial class SubjectType
//{
//	public NameIDType? NameID => (Items == null || Items.Length == 0)
//		? null
//		: (Items).FirstOrDefault(item => item is NameIDType) as NameIDType;

//	public SubjectConfirmationType? SubjectConfirmation => (Items == null || Items.Length == 0)
//		? null
//		: Items.FirstOrDefault(item => item is SubjectConfirmationType) as SubjectConfirmationType;

//}

//public partial class EntityDescriptorType : IInitializationValidable
//{
//	public const string IsServiceProvider = "IsServiceProvider";
//	public const string IsIdentityProvider = "IsIdentityProvider";

//	public SSODescriptorType? Entity
//	{
//		get
//		{
//			if (Items == null || !Items.Any())
//				return null;

//			return Items.Length == 1
//				? Items[0] as SSODescriptorType
//				: throw new InvalidOperationException($"None or multiple entity roles in metadata for: {entityID}");
//		}
//	}

//	/// <summary>Gets a value indicating whether this instance is idp.</summary>
//	/// <value>
//	///   <c>true</c> if this instance is idp; otherwise, <c>false</c>.
//	/// </value>
//	public bool IsIDP => Entity is IDPSSODescriptorType;

//	/// <summary>Gets a value indicating whether this instance is sp.</summary>
//	/// <value>
//	///   <c>true</c> if this instance is sp; otherwise, <c>false</c>.
//	/// </value>
//	public bool IsSP => Entity is SPSSODescriptorType;

//	public List<IValidationMessage>? ValidateInitialization(
//		string? propertyPrefix = null,
//		ValidationBuilder? validationBuilder = null,
//		Dictionary<string, object>? globalValidationContext = null,
//		Dictionary<string, object>? customValidationContext = null)
//	{
//		var isSP = customValidationContext?.TryGetValue(IsServiceProvider, out var spValue) == true && spValue is bool sp && sp;
//		var isIDP = customValidationContext?.TryGetValue(IsIdentityProvider, out var idpValue) == true && idpValue is bool idp && idp;

//		var detail = entityID;
//		var keyDescriptor_signing = Entity?.KeyDescriptor?.FirstOrDefault(keyDesc => keyDesc.use == KeyTypes.signing);
//		var keyDescriptor_encryption = Entity?.KeyDescriptor?.FirstOrDefault(keyDesc => keyDesc.use == KeyTypes.encryption);

//		validationBuilder ??= new ValidationBuilder();
//		var rules = validationBuilder.SetValidationMessages(propertyPrefix, globalValidationContext);
//		rules
//			.If((isSP && IsSP) || (!isSP && !IsSP), customValidationContext, $"invalid {nameof(customValidationContext)}")
//			.If(isSP && !IsSP, IsSP, "entity is not service provider")
//			.If(isIDP && !IsIDP, IsIDP, "entity is not identity provider")
//			.IfNull(Entity)
//			.IfNullOrWhiteSpace(entityID)
//			.IfNullOrEmpty(Entity?.KeyDescriptor, detailMessage: entityID)
//			.IfNull(keyDescriptor_signing, detailMessage: entityID)
//			.IfNull(keyDescriptor_encryption, detailMessage: entityID)
//			;

//		if (keyDescriptor_signing != null)
//		{
//			rules
//				.IfNull(keyDescriptor_signing.KeyInfo, detailMessage: entityID)
//				.IfNullOrEmpty(keyDescriptor_signing.KeyInfo?.Items, detailMessage: entityID);

//			var keyDescriptor_signing_x509DataType = keyDescriptor_signing.KeyInfo?.Items?.FirstOrDefault() as X509DataType;

//			rules
//				.IfNull(keyDescriptor_signing_x509DataType, detailMessage: entityID);

//			if (keyDescriptor_signing_x509DataType != null)
//			{
//				rules
//					.IfNullOrEmpty(keyDescriptor_signing_x509DataType.Items, detailMessage: entityID);

//				var keyDescriptor_signing_x509DataType_X509Certificate = keyDescriptor_signing_x509DataType?.Items?.FirstOrDefault() as byte[];

//				rules
//					.IfNull(keyDescriptor_signing_x509DataType_X509Certificate, detailMessage: entityID);
//			}
//		}

//		if (keyDescriptor_encryption != null)
//		{
//			rules
//				.IfNull(keyDescriptor_encryption.KeyInfo, detailMessage: entityID)
//				.IfNullOrEmpty(keyDescriptor_encryption.KeyInfo?.Items, detailMessage: entityID);

//			var keyDescriptor_encryption_x509DataType = keyDescriptor_encryption.KeyInfo?.Items?.FirstOrDefault() as X509DataType;

//			rules
//				.IfNull(keyDescriptor_encryption_x509DataType, detailMessage: entityID);

//			if (keyDescriptor_encryption_x509DataType != null)
//			{
//				rules
//					.IfNullOrEmpty(keyDescriptor_encryption_x509DataType.Items, detailMessage: entityID);

//				var keyDescriptor_encryption_x509DataType_X509Certificate = keyDescriptor_encryption_x509DataType?.Items?.FirstOrDefault() as byte[];

//				rules
//					.IfNull(keyDescriptor_encryption_x509DataType_X509Certificate, detailMessage: entityID);
//			}
//		}

//		return validationBuilder.Build();
//	}
//}

//public partial class ConditionsType
//{
//	/// <summary>Gets the audience restriction.</summary>
//	/// <value>The audience restriction.</value>
//	public AudienceRestrictionType? AudienceRestriction
//		=> (Items == null || Items.Length == 0)
//			? null
//			: Items.FirstOrDefault(item => item is AudienceRestrictionType) as AudienceRestrictionType;
//}

//public partial class SubjectConfirmationDataType
//{
//	private DateTime notBeforeField;
//	private bool notBeforeFieldSpecified;
//	private DateTime notOnOrAfterField;
//	private bool notOnOrAfterFieldSpecified;
//	private string recipientField;

//	/// <summary>Gets or sets the not before.</summary>
//	/// <value>The not before.</value>
//	[XmlIgnore]
//	public DateTime NotBefore
//	{
//		get => notBeforeField;
//		set => notBeforeField = value;
//	}

//	/// <summary>The Custom Not Before</summary>
//	/// <value>The custom not before.</value>
//	/// <remarks>
//	/// zvlast serizalizacia pre datumy, OIF vyzaduje v datumoch milisekundy
//	/// </remarks>
//	[XmlAttribute("NotBefore")]
//	public string CustomNotBefore
//	{
//		get => MessageHelper.DateToString(notBeforeField);
//		set => notBeforeField = MessageHelper.DateFromString(value);
//	}

//	/// <summary>
//	/// Gets or sets a value indicating whether [not before specified].
//	/// </summary>
//	/// <value>
//	///   <c>true</c> if [not before specified]; otherwise, <c>false</c>.
//	/// </value>
//	[XmlIgnore]
//	public bool NotBeforeSpecified
//	{
//		get => notBeforeFieldSpecified;
//		set => notBeforeFieldSpecified = value;
//	}

//	/// <summary>Gets or sets the not on or after.</summary>
//	/// <value>The not on or after.</value>
//	[XmlIgnore]
//	public DateTime NotOnOrAfter
//	{
//		get => notOnOrAfterField;
//		set => notOnOrAfterField = value;
//	}

//	/// <summary>Gets or sets the custom not on or after.</summary>
//	/// <value>The custom not on or after.</value>
//	[XmlAttribute("NotOnOrAfter")]
//	public string CustomNotOnOrAfter
//	{
//		get => MessageHelper.DateToString(notOnOrAfterField);
//		set => notOnOrAfterField = MessageHelper.DateFromString(value);
//	}

//	/// <summary>
//	/// Gets or sets a value indicating whether [not on or after specified].
//	/// </summary>
//	/// <value>
//	/// <c>true</c> if [not on or after specified]; otherwise, <c>false</c>.
//	/// </value>
//	[XmlIgnore]
//	public bool NotOnOrAfterSpecified
//	{
//		get => notOnOrAfterFieldSpecified;
//		set => notOnOrAfterFieldSpecified = value;
//	}

//	/// <summary>Gets or sets the recipient.</summary>
//	/// <value>The recipient.</value>
//	[XmlAttribute]
//	public string Recipient
//	{
//		get => recipientField;
//		set => recipientField = value;
//	}
//}
