// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.EntityDescriptorType
// Assembly: RBTeam.Saml2Lib, Version=4.7.2.1, Culture=neutral, PublicKeyToken=443400c129882e90
// MVID: 625824D1-DBAD-407F-86EE-CFDC4EF71CC8
// Assembly location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.dll
// XML documentation location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.xml

using Envelope.Validation;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace Envelope.WcfUtils.Saml2.Messages;

/// <remarks />
[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
[System.Xml.Serialization.XmlRoot("EntityDescriptor", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
[Serializable]
public class EntityDescriptorType : IInitializationValidable
{
	private SignatureType signatureField;
	private ExtensionsType1 extensionsField;
	private object[] itemsField;
	private OrganizationType organizationField;
	private ContactType[] contactPersonField;
	private AdditionalMetadataLocationType[] additionalMetadataLocationField;
	private string entityIDField;
	private DateTime validUntilField;
	private bool validUntilFieldSpecified;
	private string cacheDurationField;
	private string idField;
	private XmlAttribute[] anyAttrField;

	public const string IsServiceProvider = "IsServiceProvider";
	public const string IsIdentityProvider = "IsIdentityProvider";

	public SSODescriptorType? Entity
	{
		get
		{
			if (Items == null || !Items.Any())
				return null;

			return Items.Length == 1
				? Items[0] as SSODescriptorType
				: throw new InvalidOperationException($"None or multiple entity roles in metadata for: {entityID}");
		}
	}

	/// <summary>Gets a value indicating whether this instance is idp.</summary>
	/// <value>
	///   <c>true</c> if this instance is idp; otherwise, <c>false</c>.
	/// </value>
	public bool IsIDP => Entity is IDPSSODescriptorType;

	/// <summary>Gets a value indicating whether this instance is sp.</summary>
	/// <value>
	///   <c>true</c> if this instance is sp; otherwise, <c>false</c>.
	/// </value>
	public bool IsSP => Entity is SPSSODescriptorType;

	public List<IValidationMessage>? ValidateInitialization(
		string? propertyPrefix = null,
		ValidationBuilder? validationBuilder = null,
		Dictionary<string, object>? globalValidationContext = null,
		Dictionary<string, object>? customValidationContext = null)
	{
		var isSP = customValidationContext?.TryGetValue(IsServiceProvider, out var spValue) == true && spValue is bool sp && sp;
		var isIDP = customValidationContext?.TryGetValue(IsIdentityProvider, out var idpValue) == true && idpValue is bool idp && idp;

		var detail = entityID;
		var keyDescriptor_signing = Entity?.KeyDescriptor?.FirstOrDefault(keyDesc => keyDesc.use == KeyTypes.signing);
		var keyDescriptor_encryption = Entity?.KeyDescriptor?.FirstOrDefault(keyDesc => keyDesc.use == KeyTypes.encryption);

		validationBuilder ??= new ValidationBuilder();
		var rules = validationBuilder.SetValidationMessages(propertyPrefix, globalValidationContext);
		rules
			.If((isSP && IsSP) || (!isSP && !IsSP), $"invalid {nameof(customValidationContext)}")
			.If(isSP && !IsSP, "entity is not service provider")
			.If(isIDP && !IsIDP, "entity is not identity provider")
			.IfNull(Entity)
			.IfNullOrWhiteSpace(entityID)
			.IfNullOrEmpty(Entity?.KeyDescriptor, detailMessage: entityID)
			.IfNull(keyDescriptor_signing, detailMessage: entityID)
			.IfNull(keyDescriptor_encryption, detailMessage: entityID)
			;

		if (keyDescriptor_signing != null)
		{
			rules
				.IfNull(keyDescriptor_signing.KeyInfo, detailMessage: entityID)
				.IfNullOrEmpty(keyDescriptor_signing.KeyInfo?.Items, detailMessage: entityID);

			var keyDescriptor_signing_x509DataType = keyDescriptor_signing.KeyInfo?.Items?.FirstOrDefault() as X509DataType;

			rules
				.IfNull(keyDescriptor_signing_x509DataType, detailMessage: entityID);

			if (keyDescriptor_signing_x509DataType != null)
			{
				rules
					.IfNullOrEmpty(keyDescriptor_signing_x509DataType.Items, detailMessage: entityID);

				var keyDescriptor_signing_x509DataType_X509Certificate = keyDescriptor_signing_x509DataType?.Items?.FirstOrDefault() as byte[];

				rules
					.IfNull(keyDescriptor_signing_x509DataType_X509Certificate, detailMessage: entityID);
			}
		}

		if (keyDescriptor_encryption != null)
		{
			rules
				.IfNull(keyDescriptor_encryption.KeyInfo, detailMessage: entityID)
				.IfNullOrEmpty(keyDescriptor_encryption.KeyInfo?.Items, detailMessage: entityID);

			var keyDescriptor_encryption_x509DataType = keyDescriptor_encryption.KeyInfo?.Items?.FirstOrDefault() as X509DataType;

			rules
				.IfNull(keyDescriptor_encryption_x509DataType, detailMessage: entityID);

			if (keyDescriptor_encryption_x509DataType != null)
			{
				rules
					.IfNullOrEmpty(keyDescriptor_encryption_x509DataType.Items, detailMessage: entityID);

				var keyDescriptor_encryption_x509DataType_X509Certificate = keyDescriptor_encryption_x509DataType?.Items?.FirstOrDefault() as byte[];

				rules
					.IfNull(keyDescriptor_encryption_x509DataType_X509Certificate, detailMessage: entityID);
			}
		}

		return validationBuilder.Build();
	}

	/// <remarks />
	[XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
	public SignatureType Signature
	{
		get => this.signatureField;
		set => this.signatureField = value;
	}

	/// <remarks />
	public ExtensionsType1 Extensions
	{
		get => this.extensionsField;
		set => this.extensionsField = value;
	}

	/// <remarks />
	[XmlElement("AffiliationDescriptor", typeof(AffiliationDescriptorType))]
	[XmlElement("AttributeAuthorityDescriptor", typeof(AttributeAuthorityDescriptorType))]
	[XmlElement("AuthnAuthorityDescriptor", typeof(AuthnAuthorityDescriptorType))]
	[XmlElement("IDPSSODescriptor", typeof(IDPSSODescriptorType))]
	[XmlElement("PDPDescriptor", typeof(PDPDescriptorType))]
	[XmlElement("RoleDescriptor", typeof(RoleDescriptorType))]
	[XmlElement("SPSSODescriptor", typeof(SPSSODescriptorType))]
	public object[] Items
	{
		get => this.itemsField;
		set => this.itemsField = value;
	}

	/// <remarks />
	public OrganizationType Organization
	{
		get => this.organizationField;
		set => this.organizationField = value;
	}

	/// <remarks />
	[XmlElement("ContactPerson")]
	public ContactType[] ContactPerson
	{
		get => this.contactPersonField;
		set => this.contactPersonField = value;
	}

	/// <remarks />
	[XmlElement("AdditionalMetadataLocation")]
	public AdditionalMetadataLocationType[] AdditionalMetadataLocation
	{
		get => this.additionalMetadataLocationField;
		set => this.additionalMetadataLocationField = value;
	}

	/// <remarks />
	[XmlAttribute(DataType = "anyURI")]
	public string entityID
	{
		get => this.entityIDField;
		set => this.entityIDField = value;
	}

	/// <remarks />
	[XmlAttribute]
	public DateTime validUntil
	{
		get => this.validUntilField;
		set => this.validUntilField = value;
	}

	/// <remarks />
	[XmlIgnore]
	public bool validUntilSpecified
	{
		get => this.validUntilFieldSpecified;
		set => this.validUntilFieldSpecified = value;
	}

	/// <remarks />
	[XmlAttribute(DataType = "duration")]
	public string cacheDuration
	{
		get => this.cacheDurationField;
		set => this.cacheDurationField = value;
	}

	/// <remarks />
	[XmlAttribute(DataType = "ID")]
	public string ID
	{
		get => this.idField;
		set => this.idField = value;
	}

	/// <remarks />
	[XmlAnyAttribute]
	public XmlAttribute[] AnyAttr
	{
		get => this.anyAttrField;
		set => this.anyAttrField = value;
	}
}
