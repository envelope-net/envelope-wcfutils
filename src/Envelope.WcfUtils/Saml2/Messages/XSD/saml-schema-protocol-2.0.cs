//namespace Envelope.WcfUtils.Saml2.Messages;

///// <remarks/>
//[System.Xml.Serialization.XmlInclude(typeof(NameIDMappingRequestType))]
//[System.Xml.Serialization.XmlInclude(typeof(LogoutRequestType))]
//[System.Xml.Serialization.XmlInclude(typeof(ManageNameIDRequestType))]
//[System.Xml.Serialization.XmlInclude(typeof(ArtifactResolveType))]
//[System.Xml.Serialization.XmlInclude(typeof(AuthnRequestType))]
//[System.Xml.Serialization.XmlInclude(typeof(SubjectQueryAbstractType))]
//[System.Xml.Serialization.XmlInclude(typeof(AuthzDecisionQueryType))]
//[System.Xml.Serialization.XmlInclude(typeof(AttributeQueryType))]
//[System.Xml.Serialization.XmlInclude(typeof(AuthnQueryType))]
//[System.Xml.Serialization.XmlInclude(typeof(AssertionIDRequestType))]
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public abstract partial class RequestAbstractType
//{

//	private NameIDType issuerField;

//	private SignatureType signatureField;

//	private ExtensionsType extensionsField;

//	private string idField;

//	private string versionField;

//	private DateTime issueInstantField;

//	private string destinationField;

//	private string consentField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	public NameIDType Issuer
//	{
//		get
//		{
//			return issuerField;
//		}
//		set
//		{
//			issuerField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//	public SignatureType Signature
//	{
//		get
//		{
//			return signatureField;
//		}
//		set
//		{
//			signatureField = value;
//		}
//	}

//	/// <remarks/>
//	public ExtensionsType Extensions
//	{
//		get
//		{
//			return extensionsField;
//		}
//		set
//		{
//			extensionsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string ID
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string Version
//	{
//		get
//		{
//			return versionField;
//		}
//		set
//		{
//			versionField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public DateTime IssueInstant
//	{
//		get
//		{
//			return issueInstantField;
//		}
//		set
//		{
//			issueInstantField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Destination
//	{
//		get
//		{
//			return destinationField;
//		}
//		set
//		{
//			destinationField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Consent
//	{
//		get
//		{
//			return consentField;
//		}
//		set
//		{
//			consentField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//public partial class NameIDType
//{

//	private string nameQualifierField;

//	private string sPNameQualifierField;

//	private string formatField;

//	private string sPProvidedIDField;

//	private string valueField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string NameQualifier
//	{
//		get
//		{
//			return nameQualifierField;
//		}
//		set
//		{
//			nameQualifierField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string SPNameQualifier
//	{
//		get
//		{
//			return sPNameQualifierField;
//		}
//		set
//		{
//			sPNameQualifierField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Format
//	{
//		get
//		{
//			return formatField;
//		}
//		set
//		{
//			formatField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string SPProvidedID
//	{
//		get
//		{
//			return sPProvidedIDField;
//		}
//		set
//		{
//			sPProvidedIDField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText()]
//	public string Value
//	{
//		get
//		{
//			return valueField;
//		}
//		set
//		{
//			valueField = value;
//		}
//	}
//}

///// <remarks/>
//[System.Xml.Serialization.XmlInclude(typeof(KeyInfoConfirmationDataType))]
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//public partial class SubjectConfirmationDataType
//{

//	private string[] textField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText()]
//	public string[] Text
//	{
//		get
//		{
//			return textField;
//		}
//		set
//		{
//			textField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//public partial class KeyInfoConfirmationDataType : SubjectConfirmationDataType
//{
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//[System.Xml.Serialization.XmlRoot("AdditionalMetadataLocation", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
//public partial class AdditionalMetadataLocationType
//{

//	private string namespaceField;

//	private string valueField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string @namespace
//	{
//		get
//		{
//			return namespaceField;
//		}
//		set
//		{
//			namespaceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText(DataType = "anyURI")]
//	public string Value
//	{
//		get
//		{
//			return valueField;
//		}
//		set
//		{
//			valueField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//[System.Xml.Serialization.XmlRoot("AffiliationDescriptor", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
//public partial class AffiliationDescriptorType
//{

//	private SignatureType signatureField;

//	private ExtensionsType1 extensionsField;

//	private string[] affiliateMemberField;

//	private string affiliationOwnerIDField;

//	private DateTime validUntilField;

//	private bool validUntilFieldSpecified;

//	private string cacheDurationField;

//	private string idField;

//	private System.Xml.XmlAttribute[] anyAttrField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//	public SignatureType Signature
//	{
//		get
//		{
//			return signatureField;
//		}
//		set
//		{
//			signatureField = value;
//		}
//	}

//	/// <remarks/>
//	public ExtensionsType1 Extensions
//	{
//		get
//		{
//			return extensionsField;
//		}
//		set
//		{
//			extensionsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AffiliateMember", DataType = "anyURI")]
//	public string[] AffiliateMember
//	{
//		get
//		{
//			return affiliateMemberField;
//		}
//		set
//		{
//			affiliateMemberField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string affiliationOwnerID
//	{
//		get
//		{
//			return affiliationOwnerIDField;
//		}
//		set
//		{
//			affiliationOwnerIDField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public DateTime validUntil
//	{
//		get
//		{
//			return validUntilField;
//		}
//		set
//		{
//			validUntilField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool validUntilSpecified
//	{
//		get
//		{
//			return validUntilFieldSpecified;
//		}
//		set
//		{
//			validUntilFieldSpecified = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "duration")]
//	public string cacheDuration
//	{
//		get
//		{
//			return cacheDurationField;
//		}
//		set
//		{
//			cacheDurationField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string ID
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyAttribute()]
//	public System.Xml.XmlAttribute[] AnyAttr
//	{
//		get
//		{
//			return anyAttrField;
//		}
//		set
//		{
//			anyAttrField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class SignatureType
//{

//	private SignedInfoType signedInfoField;

//	private SignatureValueType signatureValueField;

//	private KeyInfoType keyInfoField;

//	private ObjectType[] objectField;

//	private string idField;

//	/// <remarks/>
//	public SignedInfoType SignedInfo
//	{
//		get
//		{
//			return signedInfoField;
//		}
//		set
//		{
//			signedInfoField = value;
//		}
//	}

//	/// <remarks/>
//	public SignatureValueType SignatureValue
//	{
//		get
//		{
//			return signatureValueField;
//		}
//		set
//		{
//			signatureValueField = value;
//		}
//	}

//	/// <remarks/>
//	public KeyInfoType KeyInfo
//	{
//		get
//		{
//			return keyInfoField;
//		}
//		set
//		{
//			keyInfoField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("Object")]
//	public ObjectType[] Object
//	{
//		get
//		{
//			return objectField;
//		}
//		set
//		{
//			objectField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string Id
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class SignedInfoType
//{

//	private CanonicalizationMethodType canonicalizationMethodField;

//	private SignatureMethodType signatureMethodField;

//	private ReferenceType[] referenceField;

//	private string idField;

//	/// <remarks/>
//	public CanonicalizationMethodType CanonicalizationMethod
//	{
//		get
//		{
//			return canonicalizationMethodField;
//		}
//		set
//		{
//			canonicalizationMethodField = value;
//		}
//	}

//	/// <remarks/>
//	public SignatureMethodType SignatureMethod
//	{
//		get
//		{
//			return signatureMethodField;
//		}
//		set
//		{
//			signatureMethodField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("Reference")]
//	public ReferenceType[] Reference
//	{
//		get
//		{
//			return referenceField;
//		}
//		set
//		{
//			referenceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string Id
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//[System.Xml.Serialization.XmlRoot("CanonicalizationMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
//public partial class CanonicalizationMethodType
//{

//	private System.Xml.XmlNode[] anyField;

//	private string algorithmField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText()]
//	[System.Xml.Serialization.XmlAnyElement()]
//	public System.Xml.XmlNode[] Any
//	{
//		get
//		{
//			return anyField;
//		}
//		set
//		{
//			anyField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Algorithm
//	{
//		get
//		{
//			return algorithmField;
//		}
//		set
//		{
//			algorithmField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class SignatureMethodType
//{

//	private string hMACOutputLengthField;

//	private System.Xml.XmlNode[] anyField;

//	private string algorithmField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(DataType = "integer")]
//	public string HMACOutputLength
//	{
//		get
//		{
//			return hMACOutputLengthField;
//		}
//		set
//		{
//			hMACOutputLengthField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText()]
//	[System.Xml.Serialization.XmlAnyElement()]
//	public System.Xml.XmlNode[] Any
//	{
//		get
//		{
//			return anyField;
//		}
//		set
//		{
//			anyField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Algorithm
//	{
//		get
//		{
//			return algorithmField;
//		}
//		set
//		{
//			algorithmField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class ReferenceType
//{

//	private TransformType[] transformsField;

//	private DigestMethodType digestMethodField;

//	private byte[] digestValueField;

//	private string idField;

//	private string uRIField;

//	private string typeField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlArrayItem("Transform", IsNullable = false)]
//	public TransformType[] Transforms
//	{
//		get
//		{
//			return transformsField;
//		}
//		set
//		{
//			transformsField = value;
//		}
//	}

//	/// <remarks/>
//	public DigestMethodType DigestMethod
//	{
//		get
//		{
//			return digestMethodField;
//		}
//		set
//		{
//			digestMethodField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(DataType = "base64Binary")]
//	public byte[] DigestValue
//	{
//		get
//		{
//			return digestValueField;
//		}
//		set
//		{
//			digestValueField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string Id
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string URI
//	{
//		get
//		{
//			return uRIField;
//		}
//		set
//		{
//			uRIField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Type
//	{
//		get
//		{
//			return typeField;
//		}
//		set
//		{
//			typeField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class TransformType
//{

//	private object[] itemsField;

//	private string[] textField;

//	private string algorithmField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyElement()]
//	[System.Xml.Serialization.XmlElement("XPath", typeof(string))]
//	public object[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText()]
//	public string[] Text
//	{
//		get
//		{
//			return textField;
//		}
//		set
//		{
//			textField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Algorithm
//	{
//		get
//		{
//			return algorithmField;
//		}
//		set
//		{
//			algorithmField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//[System.Xml.Serialization.XmlRoot("DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
//public partial class DigestMethodType
//{

//	private System.Xml.XmlNode[] anyField;

//	private string algorithmField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText()]
//	[System.Xml.Serialization.XmlAnyElement()]
//	public System.Xml.XmlNode[] Any
//	{
//		get
//		{
//			return anyField;
//		}
//		set
//		{
//			anyField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Algorithm
//	{
//		get
//		{
//			return algorithmField;
//		}
//		set
//		{
//			algorithmField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class SignatureValueType
//{

//	private string idField;

//	private byte[] valueField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string Id
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText(DataType = "base64Binary")]
//	public byte[] Value
//	{
//		get
//		{
//			return valueField;
//		}
//		set
//		{
//			valueField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class KeyInfoType
//{

//	private object[] itemsField;

//	private ItemsChoiceType2[] itemsElementNameField;

//	private string[] textField;

//	private string idField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyElement()]
//	[System.Xml.Serialization.XmlElement("KeyName", typeof(string))]
//	[System.Xml.Serialization.XmlElement("KeyValue", typeof(KeyValueType))]
//	[System.Xml.Serialization.XmlElement("MgmtData", typeof(string))]
//	[System.Xml.Serialization.XmlElement("PGPData", typeof(PGPDataType))]
//	[System.Xml.Serialization.XmlElement("RetrievalMethod", typeof(RetrievalMethodType))]
//	[System.Xml.Serialization.XmlElement("SPKIData", typeof(SPKIDataType))]
//	[System.Xml.Serialization.XmlElement("X509Data", typeof(X509DataType))]
//	[System.Xml.Serialization.XmlChoiceIdentifier("ItemsElementName")]
//	public object[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("ItemsElementName")]
//	[System.Xml.Serialization.XmlIgnore()]
//	public ItemsChoiceType2[] ItemsElementName
//	{
//		get
//		{
//			return itemsElementNameField;
//		}
//		set
//		{
//			itemsElementNameField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText()]
//	public string[] Text
//	{
//		get
//		{
//			return textField;
//		}
//		set
//		{
//			textField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string Id
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class KeyValueType
//{

//	private object itemField;

//	private string[] textField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyElement()]
//	[System.Xml.Serialization.XmlElement("DSAKeyValue", typeof(DSAKeyValueType))]
//	[System.Xml.Serialization.XmlElement("RSAKeyValue", typeof(RSAKeyValueType))]
//	public object Item
//	{
//		get
//		{
//			return itemField;
//		}
//		set
//		{
//			itemField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText()]
//	public string[] Text
//	{
//		get
//		{
//			return textField;
//		}
//		set
//		{
//			textField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//[System.Xml.Serialization.XmlRoot("DSAKeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
//public partial class DSAKeyValueType
//{

//	private byte[] pField;

//	private byte[] qField;

//	private byte[] gField;

//	private byte[] yField;

//	private byte[] jField;

//	private byte[] seedField;

//	private byte[] pgenCounterField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(DataType = "base64Binary")]
//	public byte[] P
//	{
//		get
//		{
//			return pField;
//		}
//		set
//		{
//			pField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(DataType = "base64Binary")]
//	public byte[] Q
//	{
//		get
//		{
//			return qField;
//		}
//		set
//		{
//			qField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(DataType = "base64Binary")]
//	public byte[] G
//	{
//		get
//		{
//			return gField;
//		}
//		set
//		{
//			gField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(DataType = "base64Binary")]
//	public byte[] Y
//	{
//		get
//		{
//			return yField;
//		}
//		set
//		{
//			yField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(DataType = "base64Binary")]
//	public byte[] J
//	{
//		get
//		{
//			return jField;
//		}
//		set
//		{
//			jField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(DataType = "base64Binary")]
//	public byte[] Seed
//	{
//		get
//		{
//			return seedField;
//		}
//		set
//		{
//			seedField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(DataType = "base64Binary")]
//	public byte[] PgenCounter
//	{
//		get
//		{
//			return pgenCounterField;
//		}
//		set
//		{
//			pgenCounterField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class RSAKeyValueType
//{

//	private byte[] modulusField;

//	private byte[] exponentField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(DataType = "base64Binary")]
//	public byte[] Modulus
//	{
//		get
//		{
//			return modulusField;
//		}
//		set
//		{
//			modulusField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(DataType = "base64Binary")]
//	public byte[] Exponent
//	{
//		get
//		{
//			return exponentField;
//		}
//		set
//		{
//			exponentField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class PGPDataType
//{

//	private object[] itemsField;

//	private ItemsChoiceType1[] itemsElementNameField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyElement()]
//	[System.Xml.Serialization.XmlElement("PGPKeyID", typeof(byte[]), DataType = "base64Binary")]
//	[System.Xml.Serialization.XmlElement("PGPKeyPacket", typeof(byte[]), DataType = "base64Binary")]
//	[System.Xml.Serialization.XmlChoiceIdentifier("ItemsElementName")]
//	public object[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("ItemsElementName")]
//	[System.Xml.Serialization.XmlIgnore()]
//	public ItemsChoiceType1[] ItemsElementName
//	{
//		get
//		{
//			return itemsElementNameField;
//		}
//		set
//		{
//			itemsElementNameField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
//public enum ItemsChoiceType1
//{

//	/// <remarks/>
//	[System.Xml.Serialization.XmlEnum("##any:")]
//	Item,

//	/// <remarks/>
//	PGPKeyID,

//	/// <remarks/>
//	PGPKeyPacket,
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class RetrievalMethodType
//{

//	private TransformType[] transformsField;

//	private string uRIField;

//	private string typeField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlArrayItem("Transform", IsNullable = false)]
//	public TransformType[] Transforms
//	{
//		get
//		{
//			return transformsField;
//		}
//		set
//		{
//			transformsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string URI
//	{
//		get
//		{
//			return uRIField;
//		}
//		set
//		{
//			uRIField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Type
//	{
//		get
//		{
//			return typeField;
//		}
//		set
//		{
//			typeField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class SPKIDataType
//{

//	private byte[][] sPKISexpField;

//	private System.Xml.XmlElement anyField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("SPKISexp", DataType = "base64Binary")]
//	public byte[][] SPKISexp
//	{
//		get
//		{
//			return sPKISexpField;
//		}
//		set
//		{
//			sPKISexpField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyElement()]
//	public System.Xml.XmlElement Any
//	{
//		get
//		{
//			return anyField;
//		}
//		set
//		{
//			anyField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class X509DataType
//{

//	private object[] itemsField;

//	private ItemsChoiceType[] itemsElementNameField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyElement()]
//	[System.Xml.Serialization.XmlElement("X509CRL", typeof(byte[]), DataType = "base64Binary")]
//	[System.Xml.Serialization.XmlElement("X509Certificate", typeof(byte[]), DataType = "base64Binary")]
//	[System.Xml.Serialization.XmlElement("X509IssuerSerial", typeof(X509IssuerSerialType))]
//	[System.Xml.Serialization.XmlElement("X509SKI", typeof(byte[]), DataType = "base64Binary")]
//	[System.Xml.Serialization.XmlElement("X509SubjectName", typeof(string))]
//	[System.Xml.Serialization.XmlChoiceIdentifier("ItemsElementName")]
//	public object[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("ItemsElementName")]
//	[System.Xml.Serialization.XmlIgnore()]
//	public ItemsChoiceType[] ItemsElementName
//	{
//		get
//		{
//			return itemsElementNameField;
//		}
//		set
//		{
//			itemsElementNameField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class X509IssuerSerialType
//{

//	private string x509IssuerNameField;

//	private string x509SerialNumberField;

//	/// <remarks/>
//	public string X509IssuerName
//	{
//		get
//		{
//			return x509IssuerNameField;
//		}
//		set
//		{
//			x509IssuerNameField = value;
//		}
//	}

//	/// <remarks/>
//	public string X509SerialNumber
//	{
//		get
//		{
//			return x509SerialNumberField;
//		}
//		set
//		{
//			x509SerialNumberField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
//public enum ItemsChoiceType
//{

//	/// <remarks/>
//	[System.Xml.Serialization.XmlEnum("##any:")]
//	Item,

//	/// <remarks/>
//	X509CRL,

//	/// <remarks/>
//	X509Certificate,

//	/// <remarks/>
//	X509IssuerSerial,

//	/// <remarks/>
//	X509SKI,

//	/// <remarks/>
//	X509SubjectName,
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
//public enum ItemsChoiceType2
//{

//	/// <remarks/>
//	[System.Xml.Serialization.XmlEnum("##any:")]
//	Item,

//	/// <remarks/>
//	KeyName,

//	/// <remarks/>
//	KeyValue,

//	/// <remarks/>
//	MgmtData,

//	/// <remarks/>
//	PGPData,

//	/// <remarks/>
//	RetrievalMethod,

//	/// <remarks/>
//	SPKIData,

//	/// <remarks/>
//	X509Data,
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class ObjectType
//{

//	private System.Xml.XmlNode[] anyField;

//	private string idField;

//	private string mimeTypeField;

//	private string encodingField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText()]
//	[System.Xml.Serialization.XmlAnyElement()]
//	public System.Xml.XmlNode[] Any
//	{
//		get
//		{
//			return anyField;
//		}
//		set
//		{
//			anyField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string Id
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string MimeType
//	{
//		get
//		{
//			return mimeTypeField;
//		}
//		set
//		{
//			mimeTypeField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Encoding
//	{
//		get
//		{
//			return encodingField;
//		}
//		set
//		{
//			encodingField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(TypeName = "ExtensionsType", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public partial class ExtensionsType1
//{

//	private System.Xml.XmlElement[] anyField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyElement()]
//	public System.Xml.XmlElement[] Any
//	{
//		get
//		{
//			return anyField;
//		}
//		set
//		{
//			anyField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//[System.Xml.Serialization.XmlRoot("AttributeConsumingService", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
//public partial class AttributeConsumingServiceType
//{

//	private localizedNameType[] serviceNameField;

//	private localizedNameType[] serviceDescriptionField;

//	private RequestedAttributeType[] requestedAttributeField;

//	private ushort indexField;

//	private bool isDefaultField;

//	private bool isDefaultFieldSpecified;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("ServiceName")]
//	public localizedNameType[] ServiceName
//	{
//		get
//		{
//			return serviceNameField;
//		}
//		set
//		{
//			serviceNameField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("ServiceDescription")]
//	public localizedNameType[] ServiceDescription
//	{
//		get
//		{
//			return serviceDescriptionField;
//		}
//		set
//		{
//			serviceDescriptionField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("RequestedAttribute")]
//	public RequestedAttributeType[] RequestedAttribute
//	{
//		get
//		{
//			return requestedAttributeField;
//		}
//		set
//		{
//			requestedAttributeField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public ushort index
//	{
//		get
//		{
//			return indexField;
//		}
//		set
//		{
//			indexField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public bool isDefault
//	{
//		get
//		{
//			return isDefaultField;
//		}
//		set
//		{
//			isDefaultField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool isDefaultSpecified
//	{
//		get
//		{
//			return isDefaultFieldSpecified;
//		}
//		set
//		{
//			isDefaultFieldSpecified = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public partial class localizedNameType
//{

//	private string langField;

//	private string valueField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
//	public string lang
//	{
//		get
//		{
//			return langField;
//		}
//		set
//		{
//			langField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText()]
//	public string Value
//	{
//		get
//		{
//			return valueField;
//		}
//		set
//		{
//			valueField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public partial class RequestedAttributeType : AttributeType
//{

//	private bool isRequiredField;

//	private bool isRequiredFieldSpecified;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public bool isRequired
//	{
//		get
//		{
//			return isRequiredField;
//		}
//		set
//		{
//			isRequiredField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool isRequiredSpecified
//	{
//		get
//		{
//			return isRequiredFieldSpecified;
//		}
//		set
//		{
//			isRequiredFieldSpecified = value;
//		}
//	}
//}

///// <remarks/>
//[System.Xml.Serialization.XmlInclude(typeof(RequestedAttributeType))]
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//[System.Xml.Serialization.XmlRoot("Attribute", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
//public partial class AttributeType
//{

//	private object[] attributeValueField;

//	private string nameField;

//	private string nameFormatField;

//	private string friendlyNameField;

//	private System.Xml.XmlAttribute[] anyAttrField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AttributeValue", IsNullable = true)]
//	public object[] AttributeValue
//	{
//		get
//		{
//			return attributeValueField;
//		}
//		set
//		{
//			attributeValueField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string Name
//	{
//		get
//		{
//			return nameField;
//		}
//		set
//		{
//			nameField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string NameFormat
//	{
//		get
//		{
//			return nameFormatField;
//		}
//		set
//		{
//			nameFormatField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string FriendlyName
//	{
//		get
//		{
//			return friendlyNameField;
//		}
//		set
//		{
//			friendlyNameField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyAttribute()]
//	public System.Xml.XmlAttribute[] AnyAttr
//	{
//		get
//		{
//			return anyAttrField;
//		}
//		set
//		{
//			anyAttrField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//[System.Xml.Serialization.XmlRoot("ContactPerson", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
//public partial class ContactType
//{

//	private ExtensionsType1 extensionsField;

//	private string companyField;

//	private string givenNameField;

//	private string surNameField;

//	private string[] emailAddressField;

//	private string[] telephoneNumberField;

//	private ContactTypeType contactTypeField;

//	private System.Xml.XmlAttribute[] anyAttrField;

//	/// <remarks/>
//	public ExtensionsType1 Extensions
//	{
//		get
//		{
//			return extensionsField;
//		}
//		set
//		{
//			extensionsField = value;
//		}
//	}

//	/// <remarks/>
//	public string Company
//	{
//		get
//		{
//			return companyField;
//		}
//		set
//		{
//			companyField = value;
//		}
//	}

//	/// <remarks/>
//	public string GivenName
//	{
//		get
//		{
//			return givenNameField;
//		}
//		set
//		{
//			givenNameField = value;
//		}
//	}

//	/// <remarks/>
//	public string SurName
//	{
//		get
//		{
//			return surNameField;
//		}
//		set
//		{
//			surNameField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("EmailAddress", DataType = "anyURI")]
//	public string[] EmailAddress
//	{
//		get
//		{
//			return emailAddressField;
//		}
//		set
//		{
//			emailAddressField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("TelephoneNumber")]
//	public string[] TelephoneNumber
//	{
//		get
//		{
//			return telephoneNumberField;
//		}
//		set
//		{
//			telephoneNumberField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public ContactTypeType contactType
//	{
//		get
//		{
//			return contactTypeField;
//		}
//		set
//		{
//			contactTypeField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyAttribute()]
//	public System.Xml.XmlAttribute[] AnyAttr
//	{
//		get
//		{
//			return anyAttrField;
//		}
//		set
//		{
//			anyAttrField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public enum ContactTypeType
//{

//	/// <remarks/>
//	technical,

//	/// <remarks/>
//	support,

//	/// <remarks/>
//	administrative,

//	/// <remarks/>
//	billing,

//	/// <remarks/>
//	other,
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public partial class localizedURIType
//{

//	private string langField;

//	private string valueField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
//	public string lang
//	{
//		get
//		{
//			return langField;
//		}
//		set
//		{
//			langField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText(DataType = "anyURI")]
//	public string Value
//	{
//		get
//		{
//			return valueField;
//		}
//		set
//		{
//			valueField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public partial class OrganizationType
//{

//	private ExtensionsType1 extensionsField;

//	private localizedNameType[] organizationNameField;

//	private localizedNameType[] organizationDisplayNameField;

//	private localizedURIType[] organizationURLField;

//	private System.Xml.XmlAttribute[] anyAttrField;

//	/// <remarks/>
//	public ExtensionsType1 Extensions
//	{
//		get
//		{
//			return extensionsField;
//		}
//		set
//		{
//			extensionsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("OrganizationName")]
//	public localizedNameType[] OrganizationName
//	{
//		get
//		{
//			return organizationNameField;
//		}
//		set
//		{
//			organizationNameField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("OrganizationDisplayName")]
//	public localizedNameType[] OrganizationDisplayName
//	{
//		get
//		{
//			return organizationDisplayNameField;
//		}
//		set
//		{
//			organizationDisplayNameField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("OrganizationURL")]
//	public localizedURIType[] OrganizationURL
//	{
//		get
//		{
//			return organizationURLField;
//		}
//		set
//		{
//			organizationURLField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyAttribute()]
//	public System.Xml.XmlAttribute[] AnyAttr
//	{
//		get
//		{
//			return anyAttrField;
//		}
//		set
//		{
//			anyAttrField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public partial class KeyDescriptorType
//{

//	private KeyInfoType keyInfoField;

//	private EncryptionMethodType[] encryptionMethodField;

//	private KeyTypes useField;

//	private bool useFieldSpecified;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//	public KeyInfoType KeyInfo
//	{
//		get
//		{
//			return keyInfoField;
//		}
//		set
//		{
//			keyInfoField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("EncryptionMethod")]
//	public EncryptionMethodType[] EncryptionMethod
//	{
//		get
//		{
//			return encryptionMethodField;
//		}
//		set
//		{
//			encryptionMethodField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public KeyTypes use
//	{
//		get
//		{
//			return useField;
//		}
//		set
//		{
//			useField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool useSpecified
//	{
//		get
//		{
//			return useFieldSpecified;
//		}
//		set
//		{
//			useFieldSpecified = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2001/04/xmlenc#")]
//public partial class EncryptionMethodType
//{

//	private string keySizeField;

//	private byte[] oAEPparamsField;

//	private System.Xml.XmlNode[] anyField;

//	private string algorithmField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(DataType = "integer")]
//	public string KeySize
//	{
//		get
//		{
//			return keySizeField;
//		}
//		set
//		{
//			keySizeField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(DataType = "base64Binary")]
//	public byte[] OAEPparams
//	{
//		get
//		{
//			return oAEPparamsField;
//		}
//		set
//		{
//			oAEPparamsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText()]
//	[System.Xml.Serialization.XmlAnyElement()]
//	public System.Xml.XmlNode[] Any
//	{
//		get
//		{
//			return anyField;
//		}
//		set
//		{
//			anyField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Algorithm
//	{
//		get
//		{
//			return algorithmField;
//		}
//		set
//		{
//			algorithmField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public enum KeyTypes
//{

//	/// <remarks/>
//	encryption,

//	/// <remarks/>
//	signing,
//}

///// <remarks/>
//[System.Xml.Serialization.XmlInclude(typeof(AttributeAuthorityDescriptorType))]
//[System.Xml.Serialization.XmlInclude(typeof(PDPDescriptorType))]
//[System.Xml.Serialization.XmlInclude(typeof(AuthnAuthorityDescriptorType))]
//[System.Xml.Serialization.XmlInclude(typeof(SSODescriptorType))]
//[System.Xml.Serialization.XmlInclude(typeof(SPSSODescriptorType))]
//[System.Xml.Serialization.XmlInclude(typeof(IDPSSODescriptorType))]
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public abstract partial class RoleDescriptorType
//{

//	private SignatureType signatureField;

//	private ExtensionsType1 extensionsField;

//	private KeyDescriptorType[] keyDescriptorField;

//	private OrganizationType organizationField;

//	private ContactType[] contactPersonField;

//	private string idField;

//	private DateTime validUntilField;

//	private bool validUntilFieldSpecified;

//	private string cacheDurationField;

//	private string[] protocolSupportEnumerationField;

//	private string errorURLField;

//	private System.Xml.XmlAttribute[] anyAttrField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//	public SignatureType Signature
//	{
//		get
//		{
//			return signatureField;
//		}
//		set
//		{
//			signatureField = value;
//		}
//	}

//	/// <remarks/>
//	public ExtensionsType1 Extensions
//	{
//		get
//		{
//			return extensionsField;
//		}
//		set
//		{
//			extensionsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("KeyDescriptor")]
//	public KeyDescriptorType[] KeyDescriptor
//	{
//		get
//		{
//			return keyDescriptorField;
//		}
//		set
//		{
//			keyDescriptorField = value;
//		}
//	}

//	/// <remarks/>
//	public OrganizationType Organization
//	{
//		get
//		{
//			return organizationField;
//		}
//		set
//		{
//			organizationField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("ContactPerson")]
//	public ContactType[] ContactPerson
//	{
//		get
//		{
//			return contactPersonField;
//		}
//		set
//		{
//			contactPersonField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string ID
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public DateTime validUntil
//	{
//		get
//		{
//			return validUntilField;
//		}
//		set
//		{
//			validUntilField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool validUntilSpecified
//	{
//		get
//		{
//			return validUntilFieldSpecified;
//		}
//		set
//		{
//			validUntilFieldSpecified = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "duration")]
//	public string cacheDuration
//	{
//		get
//		{
//			return cacheDurationField;
//		}
//		set
//		{
//			cacheDurationField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string[] protocolSupportEnumeration
//	{
//		get
//		{
//			return protocolSupportEnumerationField;
//		}
//		set
//		{
//			protocolSupportEnumerationField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string errorURL
//	{
//		get
//		{
//			return errorURLField;
//		}
//		set
//		{
//			errorURLField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyAttribute()]
//	public System.Xml.XmlAttribute[] AnyAttr
//	{
//		get
//		{
//			return anyAttrField;
//		}
//		set
//		{
//			anyAttrField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//[System.Xml.Serialization.XmlRoot("AttributeAuthorityDescriptor", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
//public partial class AttributeAuthorityDescriptorType : RoleDescriptorType
//{

//	private EndpointType[] attributeServiceField;

//	private EndpointType[] assertionIDRequestServiceField;

//	private string[] nameIDFormatField;

//	private string[] attributeProfileField;

//	private AttributeType[] attributeField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AttributeService")]
//	public EndpointType[] AttributeService
//	{
//		get
//		{
//			return attributeServiceField;
//		}
//		set
//		{
//			attributeServiceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AssertionIDRequestService")]
//	public EndpointType[] AssertionIDRequestService
//	{
//		get
//		{
//			return assertionIDRequestServiceField;
//		}
//		set
//		{
//			assertionIDRequestServiceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("NameIDFormat", DataType = "anyURI")]
//	public string[] NameIDFormat
//	{
//		get
//		{
//			return nameIDFormatField;
//		}
//		set
//		{
//			nameIDFormatField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AttributeProfile", DataType = "anyURI")]
//	public string[] AttributeProfile
//	{
//		get
//		{
//			return attributeProfileField;
//		}
//		set
//		{
//			attributeProfileField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("Attribute", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	public AttributeType[] Attribute
//	{
//		get
//		{
//			return attributeField;
//		}
//		set
//		{
//			attributeField = value;
//		}
//	}
//}

///// <remarks/>
//[System.Xml.Serialization.XmlInclude(typeof(IndexedEndpointType))]
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public partial class EndpointType
//{

//	private System.Xml.XmlElement[] anyField;

//	private string bindingField;

//	private string locationField;

//	private string responseLocationField;

//	private System.Xml.XmlAttribute[] anyAttrField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyElement()]
//	public System.Xml.XmlElement[] Any
//	{
//		get
//		{
//			return anyField;
//		}
//		set
//		{
//			anyField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Binding
//	{
//		get
//		{
//			return bindingField;
//		}
//		set
//		{
//			bindingField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Location
//	{
//		get
//		{
//			return locationField;
//		}
//		set
//		{
//			locationField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string ResponseLocation
//	{
//		get
//		{
//			return responseLocationField;
//		}
//		set
//		{
//			responseLocationField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyAttribute()]
//	public System.Xml.XmlAttribute[] AnyAttr
//	{
//		get
//		{
//			return anyAttrField;
//		}
//		set
//		{
//			anyAttrField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public partial class IndexedEndpointType : EndpointType
//{

//	private ushort indexField;

//	private bool isDefaultField;

//	private bool isDefaultFieldSpecified;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public ushort index
//	{
//		get
//		{
//			return indexField;
//		}
//		set
//		{
//			indexField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public bool isDefault
//	{
//		get
//		{
//			return isDefaultField;
//		}
//		set
//		{
//			isDefaultField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool isDefaultSpecified
//	{
//		get
//		{
//			return isDefaultFieldSpecified;
//		}
//		set
//		{
//			isDefaultFieldSpecified = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public partial class PDPDescriptorType : RoleDescriptorType
//{

//	private EndpointType[] authzServiceField;

//	private EndpointType[] assertionIDRequestServiceField;

//	private string[] nameIDFormatField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AuthzService")]
//	public EndpointType[] AuthzService
//	{
//		get
//		{
//			return authzServiceField;
//		}
//		set
//		{
//			authzServiceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AssertionIDRequestService")]
//	public EndpointType[] AssertionIDRequestService
//	{
//		get
//		{
//			return assertionIDRequestServiceField;
//		}
//		set
//		{
//			assertionIDRequestServiceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("NameIDFormat", DataType = "anyURI")]
//	public string[] NameIDFormat
//	{
//		get
//		{
//			return nameIDFormatField;
//		}
//		set
//		{
//			nameIDFormatField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//[System.Xml.Serialization.XmlRoot("AuthnAuthorityDescriptor", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
//public partial class AuthnAuthorityDescriptorType : RoleDescriptorType
//{

//	private EndpointType[] authnQueryServiceField;

//	private EndpointType[] assertionIDRequestServiceField;

//	private string[] nameIDFormatField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AuthnQueryService")]
//	public EndpointType[] AuthnQueryService
//	{
//		get
//		{
//			return authnQueryServiceField;
//		}
//		set
//		{
//			authnQueryServiceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AssertionIDRequestService")]
//	public EndpointType[] AssertionIDRequestService
//	{
//		get
//		{
//			return assertionIDRequestServiceField;
//		}
//		set
//		{
//			assertionIDRequestServiceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("NameIDFormat", DataType = "anyURI")]
//	public string[] NameIDFormat
//	{
//		get
//		{
//			return nameIDFormatField;
//		}
//		set
//		{
//			nameIDFormatField = value;
//		}
//	}
//}

///// <remarks/>
//[System.Xml.Serialization.XmlInclude(typeof(SPSSODescriptorType))]
//[System.Xml.Serialization.XmlInclude(typeof(IDPSSODescriptorType))]
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public abstract partial class SSODescriptorType : RoleDescriptorType
//{

//	private IndexedEndpointType[] artifactResolutionServiceField;

//	private EndpointType[] singleLogoutServiceField;

//	private EndpointType[] manageNameIDServiceField;

//	private string[] nameIDFormatField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("ArtifactResolutionService")]
//	public IndexedEndpointType[] ArtifactResolutionService
//	{
//		get
//		{
//			return artifactResolutionServiceField;
//		}
//		set
//		{
//			artifactResolutionServiceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("SingleLogoutService")]
//	public EndpointType[] SingleLogoutService
//	{
//		get
//		{
//			return singleLogoutServiceField;
//		}
//		set
//		{
//			singleLogoutServiceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("ManageNameIDService")]
//	public EndpointType[] ManageNameIDService
//	{
//		get
//		{
//			return manageNameIDServiceField;
//		}
//		set
//		{
//			manageNameIDServiceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("NameIDFormat", DataType = "anyURI")]
//	public string[] NameIDFormat
//	{
//		get
//		{
//			return nameIDFormatField;
//		}
//		set
//		{
//			nameIDFormatField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public partial class SPSSODescriptorType : SSODescriptorType
//{

//	private IndexedEndpointType[] assertionConsumerServiceField;

//	private AttributeConsumingServiceType[] attributeConsumingServiceField;

//	private bool authnRequestsSignedField;

//	private bool authnRequestsSignedFieldSpecified;

//	private bool wantAssertionsSignedField;

//	private bool wantAssertionsSignedFieldSpecified;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AssertionConsumerService")]
//	public IndexedEndpointType[] AssertionConsumerService
//	{
//		get
//		{
//			return assertionConsumerServiceField;
//		}
//		set
//		{
//			assertionConsumerServiceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AttributeConsumingService")]
//	public AttributeConsumingServiceType[] AttributeConsumingService
//	{
//		get
//		{
//			return attributeConsumingServiceField;
//		}
//		set
//		{
//			attributeConsumingServiceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public bool AuthnRequestsSigned
//	{
//		get
//		{
//			return authnRequestsSignedField;
//		}
//		set
//		{
//			authnRequestsSignedField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool AuthnRequestsSignedSpecified
//	{
//		get
//		{
//			return authnRequestsSignedFieldSpecified;
//		}
//		set
//		{
//			authnRequestsSignedFieldSpecified = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public bool WantAssertionsSigned
//	{
//		get
//		{
//			return wantAssertionsSignedField;
//		}
//		set
//		{
//			wantAssertionsSignedField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool WantAssertionsSignedSpecified
//	{
//		get
//		{
//			return wantAssertionsSignedFieldSpecified;
//		}
//		set
//		{
//			wantAssertionsSignedFieldSpecified = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public partial class IDPSSODescriptorType : SSODescriptorType
//{

//	private EndpointType[] singleSignOnServiceField;

//	private EndpointType[] nameIDMappingServiceField;

//	private EndpointType[] assertionIDRequestServiceField;

//	private string[] attributeProfileField;

//	private AttributeType[] attributeField;

//	private bool wantAuthnRequestsSignedField;

//	private bool wantAuthnRequestsSignedFieldSpecified;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("SingleSignOnService")]
//	public EndpointType[] SingleSignOnService
//	{
//		get
//		{
//			return singleSignOnServiceField;
//		}
//		set
//		{
//			singleSignOnServiceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("NameIDMappingService")]
//	public EndpointType[] NameIDMappingService
//	{
//		get
//		{
//			return nameIDMappingServiceField;
//		}
//		set
//		{
//			nameIDMappingServiceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AssertionIDRequestService")]
//	public EndpointType[] AssertionIDRequestService
//	{
//		get
//		{
//			return assertionIDRequestServiceField;
//		}
//		set
//		{
//			assertionIDRequestServiceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AttributeProfile", DataType = "anyURI")]
//	public string[] AttributeProfile
//	{
//		get
//		{
//			return attributeProfileField;
//		}
//		set
//		{
//			attributeProfileField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("Attribute", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	public AttributeType[] Attribute
//	{
//		get
//		{
//			return attributeField;
//		}
//		set
//		{
//			attributeField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public bool WantAuthnRequestsSigned
//	{
//		get
//		{
//			return wantAuthnRequestsSignedField;
//		}
//		set
//		{
//			wantAuthnRequestsSignedField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool WantAuthnRequestsSignedSpecified
//	{
//		get
//		{
//			return wantAuthnRequestsSignedFieldSpecified;
//		}
//		set
//		{
//			wantAuthnRequestsSignedFieldSpecified = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//[System.Xml.Serialization.XmlRoot("EntityDescriptor", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
//public partial class EntityDescriptorType
//{

//	private SignatureType signatureField;

//	private ExtensionsType1 extensionsField;

//	private object[] itemsField;

//	private OrganizationType organizationField;

//	private ContactType[] contactPersonField;

//	private AdditionalMetadataLocationType[] additionalMetadataLocationField;

//	private string entityIDField;

//	private DateTime validUntilField;

//	private bool validUntilFieldSpecified;

//	private string cacheDurationField;

//	private string idField;

//	private System.Xml.XmlAttribute[] anyAttrField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//	public SignatureType Signature
//	{
//		get
//		{
//			return signatureField;
//		}
//		set
//		{
//			signatureField = value;
//		}
//	}

//	/// <remarks/>
//	public ExtensionsType1 Extensions
//	{
//		get
//		{
//			return extensionsField;
//		}
//		set
//		{
//			extensionsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AffiliationDescriptor", typeof(AffiliationDescriptorType))]
//	[System.Xml.Serialization.XmlElement("AttributeAuthorityDescriptor", typeof(AttributeAuthorityDescriptorType))]
//	[System.Xml.Serialization.XmlElement("AuthnAuthorityDescriptor", typeof(AuthnAuthorityDescriptorType))]
//	[System.Xml.Serialization.XmlElement("IDPSSODescriptor", typeof(IDPSSODescriptorType))]
//	[System.Xml.Serialization.XmlElement("PDPDescriptor", typeof(PDPDescriptorType))]
//	[System.Xml.Serialization.XmlElement("RoleDescriptor", typeof(RoleDescriptorType))]
//	[System.Xml.Serialization.XmlElement("SPSSODescriptor", typeof(SPSSODescriptorType))]
//	public object[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}

//	/// <remarks/>
//	public OrganizationType Organization
//	{
//		get
//		{
//			return organizationField;
//		}
//		set
//		{
//			organizationField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("ContactPerson")]
//	public ContactType[] ContactPerson
//	{
//		get
//		{
//			return contactPersonField;
//		}
//		set
//		{
//			contactPersonField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AdditionalMetadataLocation")]
//	public AdditionalMetadataLocationType[] AdditionalMetadataLocation
//	{
//		get
//		{
//			return additionalMetadataLocationField;
//		}
//		set
//		{
//			additionalMetadataLocationField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string entityID
//	{
//		get
//		{
//			return entityIDField;
//		}
//		set
//		{
//			entityIDField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public DateTime validUntil
//	{
//		get
//		{
//			return validUntilField;
//		}
//		set
//		{
//			validUntilField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool validUntilSpecified
//	{
//		get
//		{
//			return validUntilFieldSpecified;
//		}
//		set
//		{
//			validUntilFieldSpecified = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "duration")]
//	public string cacheDuration
//	{
//		get
//		{
//			return cacheDurationField;
//		}
//		set
//		{
//			cacheDurationField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string ID
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyAttribute()]
//	public System.Xml.XmlAttribute[] AnyAttr
//	{
//		get
//		{
//			return anyAttrField;
//		}
//		set
//		{
//			anyAttrField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
//public partial class EntitiesDescriptorType
//{

//	private SignatureType signatureField;

//	private ExtensionsType1 extensionsField;

//	private object[] itemsField;

//	private DateTime validUntilField;

//	private bool validUntilFieldSpecified;

//	private string cacheDurationField;

//	private string idField;

//	private string nameField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//	public SignatureType Signature
//	{
//		get
//		{
//			return signatureField;
//		}
//		set
//		{
//			signatureField = value;
//		}
//	}

//	/// <remarks/>
//	public ExtensionsType1 Extensions
//	{
//		get
//		{
//			return extensionsField;
//		}
//		set
//		{
//			extensionsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("EntitiesDescriptor", typeof(EntitiesDescriptorType))]
//	[System.Xml.Serialization.XmlElement("EntityDescriptor", typeof(EntityDescriptorType))]
//	public object[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public DateTime validUntil
//	{
//		get
//		{
//			return validUntilField;
//		}
//		set
//		{
//			validUntilField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool validUntilSpecified
//	{
//		get
//		{
//			return validUntilFieldSpecified;
//		}
//		set
//		{
//			validUntilFieldSpecified = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "duration")]
//	public string cacheDuration
//	{
//		get
//		{
//			return cacheDurationField;
//		}
//		set
//		{
//			cacheDurationField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string ID
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string Name
//	{
//		get
//		{
//			return nameField;
//		}
//		set
//		{
//			nameField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2001/04/xmlenc#")]
//[System.Xml.Serialization.XmlRoot("AgreementMethod", Namespace = "http://www.w3.org/2001/04/xmlenc#", IsNullable = false)]
//public partial class AgreementMethodType
//{

//	private byte[] kANonceField;

//	private System.Xml.XmlNode[] anyField;

//	private KeyInfoType originatorKeyInfoField;

//	private KeyInfoType recipientKeyInfoField;

//	private string algorithmField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("KA-Nonce", DataType = "base64Binary")]
//	public byte[] KANonce
//	{
//		get
//		{
//			return kANonceField;
//		}
//		set
//		{
//			kANonceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText()]
//	[System.Xml.Serialization.XmlAnyElement()]
//	public System.Xml.XmlNode[] Any
//	{
//		get
//		{
//			return anyField;
//		}
//		set
//		{
//			anyField = value;
//		}
//	}

//	/// <remarks/>
//	public KeyInfoType OriginatorKeyInfo
//	{
//		get
//		{
//			return originatorKeyInfoField;
//		}
//		set
//		{
//			originatorKeyInfoField = value;
//		}
//	}

//	/// <remarks/>
//	public KeyInfoType RecipientKeyInfo
//	{
//		get
//		{
//			return recipientKeyInfoField;
//		}
//		set
//		{
//			recipientKeyInfoField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Algorithm
//	{
//		get
//		{
//			return algorithmField;
//		}
//		set
//		{
//			algorithmField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class SignaturePropertyType
//{

//	private System.Xml.XmlElement[] itemsField;

//	private string[] textField;

//	private string targetField;

//	private string idField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyElement()]
//	public System.Xml.XmlElement[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText()]
//	public string[] Text
//	{
//		get
//		{
//			return textField;
//		}
//		set
//		{
//			textField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Target
//	{
//		get
//		{
//			return targetField;
//		}
//		set
//		{
//			targetField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string Id
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class SignaturePropertiesType
//{

//	private SignaturePropertyType[] signaturePropertyField;

//	private string idField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("SignatureProperty")]
//	public SignaturePropertyType[] SignatureProperty
//	{
//		get
//		{
//			return signaturePropertyField;
//		}
//		set
//		{
//			signaturePropertyField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string Id
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//public partial class ManifestType
//{

//	private ReferenceType[] referenceField;

//	private string idField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("Reference")]
//	public ReferenceType[] Reference
//	{
//		get
//		{
//			return referenceField;
//		}
//		set
//		{
//			referenceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string Id
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//public partial class EvidenceType
//{

//	private object[] itemsField;

//	private ItemsChoiceType6[] itemsElementNameField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("Assertion", typeof(AssertionType))]
//	[System.Xml.Serialization.XmlElement("AssertionIDRef", typeof(string), DataType = "NCName")]
//	[System.Xml.Serialization.XmlElement("AssertionURIRef", typeof(string), DataType = "anyURI")]
//	[System.Xml.Serialization.XmlElement("EncryptedAssertion", typeof(EncryptedElementType))]
//	[System.Xml.Serialization.XmlChoiceIdentifier("ItemsElementName")]
//	public object[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("ItemsElementName")]
//	[System.Xml.Serialization.XmlIgnore()]
//	public ItemsChoiceType6[] ItemsElementName
//	{
//		get
//		{
//			return itemsElementNameField;
//		}
//		set
//		{
//			itemsElementNameField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//[System.Xml.Serialization.XmlRoot("Assertion", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
//public partial class AssertionType
//{

//	private NameIDType issuerField;

//	private SignatureType signatureField;

//	private SubjectType subjectField;

//	private ConditionsType conditionsField;

//	private AdviceType adviceField;

//	private StatementAbstractType[] itemsField;

//	private string versionField;

//	private string idField;

//	private DateTime issueInstantField;

//	/// <remarks/>
//	public NameIDType Issuer
//	{
//		get
//		{
//			return issuerField;
//		}
//		set
//		{
//			issuerField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//	public SignatureType Signature
//	{
//		get
//		{
//			return signatureField;
//		}
//		set
//		{
//			signatureField = value;
//		}
//	}

//	/// <remarks/>
//	public SubjectType Subject
//	{
//		get
//		{
//			return subjectField;
//		}
//		set
//		{
//			subjectField = value;
//		}
//	}

//	/// <remarks/>
//	public ConditionsType Conditions
//	{
//		get
//		{
//			return conditionsField;
//		}
//		set
//		{
//			conditionsField = value;
//		}
//	}

//	/// <remarks/>
//	public AdviceType Advice
//	{
//		get
//		{
//			return adviceField;
//		}
//		set
//		{
//			adviceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AttributeStatement", typeof(AttributeStatementType))]
//	[System.Xml.Serialization.XmlElement("AuthnStatement", typeof(AuthnStatementType))]
//	[System.Xml.Serialization.XmlElement("AuthzDecisionStatement", typeof(AuthzDecisionStatementType))]
//	[System.Xml.Serialization.XmlElement("Statement", typeof(StatementAbstractType))]
//	public StatementAbstractType[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string Version
//	{
//		get
//		{
//			return versionField;
//		}
//		set
//		{
//			versionField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string ID
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public DateTime IssueInstant
//	{
//		get
//		{
//			return issueInstantField;
//		}
//		set
//		{
//			issueInstantField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//public partial class SubjectType
//{

//	private object[] itemsField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("BaseID", typeof(BaseIDAbstractType))]
//	[System.Xml.Serialization.XmlElement("EncryptedID", typeof(EncryptedElementType))]
//	[System.Xml.Serialization.XmlElement("NameID", typeof(NameIDType))]
//	[System.Xml.Serialization.XmlElement("SubjectConfirmation", typeof(SubjectConfirmationType))]
//	public object[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//[System.Xml.Serialization.XmlRoot("BaseID", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
//public abstract partial class BaseIDAbstractType
//{

//	private string nameQualifierField;

//	private string sPNameQualifierField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string NameQualifier
//	{
//		get
//		{
//			return nameQualifierField;
//		}
//		set
//		{
//			nameQualifierField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string SPNameQualifier
//	{
//		get
//		{
//			return sPNameQualifierField;
//		}
//		set
//		{
//			sPNameQualifierField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//[System.Xml.Serialization.XmlRoot("NewEncryptedID", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
//public partial class EncryptedElementType
//{

//	private EncryptedDataType encryptedDataField;

//	private EncryptedKeyType[] encryptedKeyField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "http://www.w3.org/2001/04/xmlenc#")]
//	public EncryptedDataType EncryptedData
//	{
//		get
//		{
//			return encryptedDataField;
//		}
//		set
//		{
//			encryptedDataField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("EncryptedKey", Namespace = "http://www.w3.org/2001/04/xmlenc#")]
//	public EncryptedKeyType[] EncryptedKey
//	{
//		get
//		{
//			return encryptedKeyField;
//		}
//		set
//		{
//			encryptedKeyField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2001/04/xmlenc#")]
//[System.Xml.Serialization.XmlRoot("EncryptedData", Namespace = "http://www.w3.org/2001/04/xmlenc#", IsNullable = false)]
//public partial class EncryptedDataType : EncryptedType
//{
//}

///// <remarks/>
//[System.Xml.Serialization.XmlInclude(typeof(EncryptedKeyType))]
//[System.Xml.Serialization.XmlInclude(typeof(EncryptedDataType))]
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2001/04/xmlenc#")]
//public abstract partial class EncryptedType
//{

//	private EncryptionMethodType encryptionMethodField;

//	private KeyInfoType keyInfoField;

//	private CipherDataType cipherDataField;

//	private EncryptionPropertiesType encryptionPropertiesField;

//	private string idField;

//	private string typeField;

//	private string mimeTypeField;

//	private string encodingField;

//	/// <remarks/>
//	public EncryptionMethodType EncryptionMethod
//	{
//		get
//		{
//			return encryptionMethodField;
//		}
//		set
//		{
//			encryptionMethodField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//	public KeyInfoType KeyInfo
//	{
//		get
//		{
//			return keyInfoField;
//		}
//		set
//		{
//			keyInfoField = value;
//		}
//	}

//	/// <remarks/>
//	public CipherDataType CipherData
//	{
//		get
//		{
//			return cipherDataField;
//		}
//		set
//		{
//			cipherDataField = value;
//		}
//	}

//	/// <remarks/>
//	public EncryptionPropertiesType EncryptionProperties
//	{
//		get
//		{
//			return encryptionPropertiesField;
//		}
//		set
//		{
//			encryptionPropertiesField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string Id
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Type
//	{
//		get
//		{
//			return typeField;
//		}
//		set
//		{
//			typeField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string MimeType
//	{
//		get
//		{
//			return mimeTypeField;
//		}
//		set
//		{
//			mimeTypeField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Encoding
//	{
//		get
//		{
//			return encodingField;
//		}
//		set
//		{
//			encodingField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2001/04/xmlenc#")]
//[System.Xml.Serialization.XmlRoot("CipherData", Namespace = "http://www.w3.org/2001/04/xmlenc#", IsNullable = false)]
//public partial class CipherDataType
//{

//	private object itemField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("CipherReference", typeof(CipherReferenceType))]
//	[System.Xml.Serialization.XmlElement("CipherValue", typeof(byte[]), DataType = "base64Binary")]
//	public object Item
//	{
//		get
//		{
//			return itemField;
//		}
//		set
//		{
//			itemField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2001/04/xmlenc#")]
//[System.Xml.Serialization.XmlRoot("CipherReference", Namespace = "http://www.w3.org/2001/04/xmlenc#", IsNullable = false)]
//public partial class CipherReferenceType
//{

//	private TransformsType1 itemField;

//	private string uRIField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("Transforms")]
//	public TransformsType1 Item
//	{
//		get
//		{
//			return itemField;
//		}
//		set
//		{
//			itemField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string URI
//	{
//		get
//		{
//			return uRIField;
//		}
//		set
//		{
//			uRIField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(TypeName = "TransformsType", Namespace = "http://www.w3.org/2001/04/xmlenc#")]
//public partial class TransformsType1
//{

//	private TransformType[] transformField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("Transform", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//	public TransformType[] Transform
//	{
//		get
//		{
//			return transformField;
//		}
//		set
//		{
//			transformField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2001/04/xmlenc#")]
//public partial class EncryptionPropertiesType
//{

//	private EncryptionPropertyType[] encryptionPropertyField;

//	private string idField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("EncryptionProperty")]
//	public EncryptionPropertyType[] EncryptionProperty
//	{
//		get
//		{
//			return encryptionPropertyField;
//		}
//		set
//		{
//			encryptionPropertyField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string Id
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2001/04/xmlenc#")]
//public partial class EncryptionPropertyType
//{

//	private System.Xml.XmlElement[] itemsField;

//	private string[] textField;

//	private string targetField;

//	private string idField;

//	private System.Xml.XmlAttribute[] anyAttrField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyElement()]
//	public System.Xml.XmlElement[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText()]
//	public string[] Text
//	{
//		get
//		{
//			return textField;
//		}
//		set
//		{
//			textField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Target
//	{
//		get
//		{
//			return targetField;
//		}
//		set
//		{
//			targetField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string Id
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyAttribute()]
//	public System.Xml.XmlAttribute[] AnyAttr
//	{
//		get
//		{
//			return anyAttrField;
//		}
//		set
//		{
//			anyAttrField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2001/04/xmlenc#")]
//[System.Xml.Serialization.XmlRoot("EncryptedKey", Namespace = "http://www.w3.org/2001/04/xmlenc#", IsNullable = false)]
//public partial class EncryptedKeyType : EncryptedType
//{

//	private ReferenceList referenceListField;

//	private string carriedKeyNameField;

//	private string recipientField;

//	/// <remarks/>
//	public ReferenceList ReferenceList
//	{
//		get
//		{
//			return referenceListField;
//		}
//		set
//		{
//			referenceListField = value;
//		}
//	}

//	/// <remarks/>
//	public string CarriedKeyName
//	{
//		get
//		{
//			return carriedKeyNameField;
//		}
//		set
//		{
//			carriedKeyNameField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string Recipient
//	{
//		get
//		{
//			return recipientField;
//		}
//		set
//		{
//			recipientField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2001/04/xmlenc#")]
//public partial class ReferenceList
//{

//	private ReferenceType1[] itemsField;

//	private ItemsChoiceType3[] itemsElementNameField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("DataReference", typeof(ReferenceType1))]
//	[System.Xml.Serialization.XmlElement("KeyReference", typeof(ReferenceType1))]
//	[System.Xml.Serialization.XmlChoiceIdentifier("ItemsElementName")]
//	public ReferenceType1[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("ItemsElementName")]
//	[System.Xml.Serialization.XmlIgnore()]
//	public ItemsChoiceType3[] ItemsElementName
//	{
//		get
//		{
//			return itemsElementNameField;
//		}
//		set
//		{
//			itemsElementNameField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(TypeName = "ReferenceType", Namespace = "http://www.w3.org/2001/04/xmlenc#")]
//public partial class ReferenceType1
//{

//	private System.Xml.XmlElement[] anyField;

//	private string uRIField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyElement()]
//	public System.Xml.XmlElement[] Any
//	{
//		get
//		{
//			return anyField;
//		}
//		set
//		{
//			anyField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string URI
//	{
//		get
//		{
//			return uRIField;
//		}
//		set
//		{
//			uRIField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "http://www.w3.org/2001/04/xmlenc#", IncludeInSchema = false)]
//public enum ItemsChoiceType3
//{

//	/// <remarks/>
//	DataReference,

//	/// <remarks/>
//	KeyReference,
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//public partial class SubjectConfirmationType
//{

//	private object itemField;

//	private SubjectConfirmationDataType subjectConfirmationDataField;

//	private string methodField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("BaseID", typeof(BaseIDAbstractType))]
//	[System.Xml.Serialization.XmlElement("EncryptedID", typeof(EncryptedElementType))]
//	[System.Xml.Serialization.XmlElement("NameID", typeof(NameIDType))]
//	public object Item
//	{
//		get
//		{
//			return itemField;
//		}
//		set
//		{
//			itemField = value;
//		}
//	}

//	/// <remarks/>
//	public SubjectConfirmationDataType SubjectConfirmationData
//	{
//		get
//		{
//			return subjectConfirmationDataField;
//		}
//		set
//		{
//			subjectConfirmationDataField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Method
//	{
//		get
//		{
//			return methodField;
//		}
//		set
//		{
//			methodField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//[System.Xml.Serialization.XmlRoot("Conditions", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
//public partial class ConditionsType
//{

//	private ConditionAbstractType[] itemsField;

//	private DateTime notBeforeField;

//	private bool notBeforeFieldSpecified;

//	private DateTime notOnOrAfterField;

//	private bool notOnOrAfterFieldSpecified;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AudienceRestriction", typeof(AudienceRestrictionType))]
//	[System.Xml.Serialization.XmlElement("Condition", typeof(ConditionAbstractType))]
//	[System.Xml.Serialization.XmlElement("OneTimeUse", typeof(OneTimeUseType))]
//	[System.Xml.Serialization.XmlElement("ProxyRestriction", typeof(ProxyRestrictionType))]
//	public ConditionAbstractType[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public DateTime NotBefore
//	{
//		get
//		{
//			return notBeforeField;
//		}
//		set
//		{
//			notBeforeField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool NotBeforeSpecified
//	{
//		get
//		{
//			return notBeforeFieldSpecified;
//		}
//		set
//		{
//			notBeforeFieldSpecified = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public DateTime NotOnOrAfter
//	{
//		get
//		{
//			return notOnOrAfterField;
//		}
//		set
//		{
//			notOnOrAfterField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool NotOnOrAfterSpecified
//	{
//		get
//		{
//			return notOnOrAfterFieldSpecified;
//		}
//		set
//		{
//			notOnOrAfterFieldSpecified = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//[System.Xml.Serialization.XmlRoot("AudienceRestriction", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
//public partial class AudienceRestrictionType : ConditionAbstractType
//{

//	private string[] audienceField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("Audience", DataType = "anyURI")]
//	public string[] Audience
//	{
//		get
//		{
//			return audienceField;
//		}
//		set
//		{
//			audienceField = value;
//		}
//	}
//}

///// <remarks/>
//[System.Xml.Serialization.XmlInclude(typeof(ProxyRestrictionType))]
//[System.Xml.Serialization.XmlInclude(typeof(OneTimeUseType))]
//[System.Xml.Serialization.XmlInclude(typeof(AudienceRestrictionType))]
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//[System.Xml.Serialization.XmlRoot("Condition", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
//public abstract partial class ConditionAbstractType
//{
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//public partial class ProxyRestrictionType : ConditionAbstractType
//{

//	private string[] audienceField;

//	private string countField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("Audience", DataType = "anyURI")]
//	public string[] Audience
//	{
//		get
//		{
//			return audienceField;
//		}
//		set
//		{
//			audienceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "nonNegativeInteger")]
//	public string Count
//	{
//		get
//		{
//			return countField;
//		}
//		set
//		{
//			countField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//public partial class OneTimeUseType : ConditionAbstractType
//{
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//[System.Xml.Serialization.XmlRoot("Advice", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
//public partial class AdviceType
//{

//	private object[] itemsField;

//	private ItemsChoiceType4[] itemsElementNameField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyElement()]
//	[System.Xml.Serialization.XmlElement("Assertion", typeof(AssertionType))]
//	[System.Xml.Serialization.XmlElement("AssertionIDRef", typeof(string), DataType = "NCName")]
//	[System.Xml.Serialization.XmlElement("AssertionURIRef", typeof(string), DataType = "anyURI")]
//	[System.Xml.Serialization.XmlElement("EncryptedAssertion", typeof(EncryptedElementType))]
//	[System.Xml.Serialization.XmlChoiceIdentifier("ItemsElementName")]
//	public object[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("ItemsElementName")]
//	[System.Xml.Serialization.XmlIgnore()]
//	public ItemsChoiceType4[] ItemsElementName
//	{
//		get
//		{
//			return itemsElementNameField;
//		}
//		set
//		{
//			itemsElementNameField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IncludeInSchema = false)]
//public enum ItemsChoiceType4
//{

//	/// <remarks/>
//	[System.Xml.Serialization.XmlEnum("##any:")]
//	Item,

//	/// <remarks/>
//	Assertion,

//	/// <remarks/>
//	AssertionIDRef,

//	/// <remarks/>
//	AssertionURIRef,

//	/// <remarks/>
//	EncryptedAssertion,
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//[System.Xml.Serialization.XmlRoot("AttributeStatement", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
//public partial class AttributeStatementType : StatementAbstractType
//{

//	private object[] itemsField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("Attribute", typeof(AttributeType))]
//	[System.Xml.Serialization.XmlElement("EncryptedAttribute", typeof(EncryptedElementType))]
//	public object[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}
//}

///// <remarks/>
//[System.Xml.Serialization.XmlInclude(typeof(AttributeStatementType))]
//[System.Xml.Serialization.XmlInclude(typeof(AuthzDecisionStatementType))]
//[System.Xml.Serialization.XmlInclude(typeof(AuthnStatementType))]
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//public abstract partial class StatementAbstractType
//{
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//[System.Xml.Serialization.XmlRoot("AuthzDecisionStatement", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
//public partial class AuthzDecisionStatementType : StatementAbstractType
//{

//	private ActionType[] actionField;

//	private EvidenceType evidenceField;

//	private string resourceField;

//	private DecisionType decisionField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("Action")]
//	public ActionType[] Action
//	{
//		get
//		{
//			return actionField;
//		}
//		set
//		{
//			actionField = value;
//		}
//	}

//	/// <remarks/>
//	public EvidenceType Evidence
//	{
//		get
//		{
//			return evidenceField;
//		}
//		set
//		{
//			evidenceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Resource
//	{
//		get
//		{
//			return resourceField;
//		}
//		set
//		{
//			resourceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public DecisionType Decision
//	{
//		get
//		{
//			return decisionField;
//		}
//		set
//		{
//			decisionField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//[System.Xml.Serialization.XmlRoot("Action", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
//public partial class ActionType
//{

//	private string namespaceField;

//	private string valueField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Namespace
//	{
//		get
//		{
//			return namespaceField;
//		}
//		set
//		{
//			namespaceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlText()]
//	public string Value
//	{
//		get
//		{
//			return valueField;
//		}
//		set
//		{
//			valueField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//public enum DecisionType
//{

//	/// <remarks/>
//	Permit,

//	/// <remarks/>
//	Deny,

//	/// <remarks/>
//	Indeterminate,
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//[System.Xml.Serialization.XmlRoot("AuthnStatement", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
//public partial class AuthnStatementType : StatementAbstractType
//{

//	private SubjectLocalityType subjectLocalityField;

//	private AuthnContextType authnContextField;

//	private DateTime authnInstantField;

//	private string sessionIndexField;

//	private DateTime sessionNotOnOrAfterField;

//	private bool sessionNotOnOrAfterFieldSpecified;

//	/// <remarks/>
//	public SubjectLocalityType SubjectLocality
//	{
//		get
//		{
//			return subjectLocalityField;
//		}
//		set
//		{
//			subjectLocalityField = value;
//		}
//	}

//	/// <remarks/>
//	public AuthnContextType AuthnContext
//	{
//		get
//		{
//			return authnContextField;
//		}
//		set
//		{
//			authnContextField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public DateTime AuthnInstant
//	{
//		get
//		{
//			return authnInstantField;
//		}
//		set
//		{
//			authnInstantField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string SessionIndex
//	{
//		get
//		{
//			return sessionIndexField;
//		}
//		set
//		{
//			sessionIndexField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public DateTime SessionNotOnOrAfter
//	{
//		get
//		{
//			return sessionNotOnOrAfterField;
//		}
//		set
//		{
//			sessionNotOnOrAfterField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool SessionNotOnOrAfterSpecified
//	{
//		get
//		{
//			return sessionNotOnOrAfterFieldSpecified;
//		}
//		set
//		{
//			sessionNotOnOrAfterFieldSpecified = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//public partial class SubjectLocalityType
//{

//	private string addressField;

//	private string dNSNameField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string Address
//	{
//		get
//		{
//			return addressField;
//		}
//		set
//		{
//			addressField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string DNSName
//	{
//		get
//		{
//			return dNSNameField;
//		}
//		set
//		{
//			dNSNameField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//[System.Xml.Serialization.XmlRoot("AuthnContext", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
//public partial class AuthnContextType
//{

//	private object[] itemsField;

//	private ItemsChoiceType5[] itemsElementNameField;

//	private string[] authenticatingAuthorityField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AuthnContextClassRef", typeof(string), DataType = "anyURI")]
//	[System.Xml.Serialization.XmlElement("AuthnContextDecl", typeof(object))]
//	[System.Xml.Serialization.XmlElement("AuthnContextDeclRef", typeof(string), DataType = "anyURI")]
//	[System.Xml.Serialization.XmlChoiceIdentifier("ItemsElementName")]
//	public object[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("ItemsElementName")]
//	[System.Xml.Serialization.XmlIgnore()]
//	public ItemsChoiceType5[] ItemsElementName
//	{
//		get
//		{
//			return itemsElementNameField;
//		}
//		set
//		{
//			itemsElementNameField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AuthenticatingAuthority", DataType = "anyURI")]
//	public string[] AuthenticatingAuthority
//	{
//		get
//		{
//			return authenticatingAuthorityField;
//		}
//		set
//		{
//			authenticatingAuthorityField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IncludeInSchema = false)]
//public enum ItemsChoiceType5
//{

//	/// <remarks/>
//	AuthnContextClassRef,

//	/// <remarks/>
//	AuthnContextDecl,

//	/// <remarks/>
//	AuthnContextDeclRef,
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IncludeInSchema = false)]
//public enum ItemsChoiceType6
//{

//	/// <remarks/>
//	Assertion,

//	/// <remarks/>
//	AssertionIDRef,

//	/// <remarks/>
//	AssertionURIRef,

//	/// <remarks/>
//	EncryptedAssertion,
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class ExtensionsType
//{

//	private System.Xml.XmlElement[] anyField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyElement()]
//	public System.Xml.XmlElement[] Any
//	{
//		get
//		{
//			return anyField;
//		}
//		set
//		{
//			anyField = value;
//		}
//	}
//}

///// <remarks/>
//[System.Xml.Serialization.XmlInclude(typeof(NameIDMappingResponseType))]
//[System.Xml.Serialization.XmlInclude(typeof(ArtifactResponseType))]
//[System.Xml.Serialization.XmlInclude(typeof(ResponseType))]
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class StatusResponseType
//{

//	private NameIDType issuerField;

//	private SignatureType signatureField;

//	private ExtensionsType extensionsField;

//	private StatusType statusField;

//	private string idField;

//	private string inResponseToField;

//	private string versionField;

//	private DateTime issueInstantField;

//	private string destinationField;

//	private string consentField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	public NameIDType Issuer
//	{
//		get
//		{
//			return issuerField;
//		}
//		set
//		{
//			issuerField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
//	public SignatureType Signature
//	{
//		get
//		{
//			return signatureField;
//		}
//		set
//		{
//			signatureField = value;
//		}
//	}

//	/// <remarks/>
//	public ExtensionsType Extensions
//	{
//		get
//		{
//			return extensionsField;
//		}
//		set
//		{
//			extensionsField = value;
//		}
//	}

//	/// <remarks/>
//	public StatusType Status
//	{
//		get
//		{
//			return statusField;
//		}
//		set
//		{
//			statusField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "ID")]
//	public string ID
//	{
//		get
//		{
//			return idField;
//		}
//		set
//		{
//			idField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "NCName")]
//	public string InResponseTo
//	{
//		get
//		{
//			return inResponseToField;
//		}
//		set
//		{
//			inResponseToField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string Version
//	{
//		get
//		{
//			return versionField;
//		}
//		set
//		{
//			versionField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public DateTime IssueInstant
//	{
//		get
//		{
//			return issueInstantField;
//		}
//		set
//		{
//			issueInstantField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Destination
//	{
//		get
//		{
//			return destinationField;
//		}
//		set
//		{
//			destinationField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Consent
//	{
//		get
//		{
//			return consentField;
//		}
//		set
//		{
//			consentField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class StatusType
//{

//	private StatusCodeType statusCodeField;

//	private string statusMessageField;

//	private StatusDetailType statusDetailField;

//	/// <remarks/>
//	public StatusCodeType StatusCode
//	{
//		get
//		{
//			return statusCodeField;
//		}
//		set
//		{
//			statusCodeField = value;
//		}
//	}

//	/// <remarks/>
//	public string StatusMessage
//	{
//		get
//		{
//			return statusMessageField;
//		}
//		set
//		{
//			statusMessageField = value;
//		}
//	}

//	/// <remarks/>
//	public StatusDetailType StatusDetail
//	{
//		get
//		{
//			return statusDetailField;
//		}
//		set
//		{
//			statusDetailField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class StatusCodeType
//{

//	private StatusCodeType statusCodeField;

//	private string valueField;

//	/// <remarks/>
//	public StatusCodeType StatusCode
//	{
//		get
//		{
//			return statusCodeField;
//		}
//		set
//		{
//			statusCodeField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Value
//	{
//		get
//		{
//			return valueField;
//		}
//		set
//		{
//			valueField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class StatusDetailType
//{

//	private System.Xml.XmlElement[] anyField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyElement()]
//	public System.Xml.XmlElement[] Any
//	{
//		get
//		{
//			return anyField;
//		}
//		set
//		{
//			anyField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot("AssertionIDRequest", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
//public partial class AssertionIDRequestType : RequestAbstractType
//{

//	private string[] assertionIDRefField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AssertionIDRef", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", DataType = "NCName")]
//	public string[] AssertionIDRef
//	{
//		get
//		{
//			return assertionIDRefField;
//		}
//		set
//		{
//			assertionIDRefField = value;
//		}
//	}
//}

///// <remarks/>
//[System.Xml.Serialization.XmlInclude(typeof(AuthzDecisionQueryType))]
//[System.Xml.Serialization.XmlInclude(typeof(AttributeQueryType))]
//[System.Xml.Serialization.XmlInclude(typeof(AuthnQueryType))]
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public abstract partial class SubjectQueryAbstractType : RequestAbstractType
//{

//	private SubjectType subjectField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	public SubjectType Subject
//	{
//		get
//		{
//			return subjectField;
//		}
//		set
//		{
//			subjectField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot("AuthnQuery", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
//public partial class AuthnQueryType : SubjectQueryAbstractType
//{

//	private RequestedAuthnContextType requestedAuthnContextField;

//	private string sessionIndexField;

//	/// <remarks/>
//	public RequestedAuthnContextType RequestedAuthnContext
//	{
//		get
//		{
//			return requestedAuthnContextField;
//		}
//		set
//		{
//			requestedAuthnContextField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string SessionIndex
//	{
//		get
//		{
//			return sessionIndexField;
//		}
//		set
//		{
//			sessionIndexField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class RequestedAuthnContextType
//{

//	private string[] itemsField;

//	private ItemsChoiceType7[] itemsElementNameField;

//	private AuthnContextComparisonType comparisonField;

//	private bool comparisonFieldSpecified;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("AuthnContextClassRef", typeof(string), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", DataType = "anyURI")]
//	[System.Xml.Serialization.XmlElement("AuthnContextDeclRef", typeof(string), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", DataType = "anyURI")]
//	[System.Xml.Serialization.XmlChoiceIdentifier("ItemsElementName")]
//	public string[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("ItemsElementName")]
//	[System.Xml.Serialization.XmlIgnore()]
//	public ItemsChoiceType7[] ItemsElementName
//	{
//		get
//		{
//			return itemsElementNameField;
//		}
//		set
//		{
//			itemsElementNameField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public AuthnContextComparisonType Comparison
//	{
//		get
//		{
//			return comparisonField;
//		}
//		set
//		{
//			comparisonField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool ComparisonSpecified
//	{
//		get
//		{
//			return comparisonFieldSpecified;
//		}
//		set
//		{
//			comparisonFieldSpecified = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IncludeInSchema = false)]
//public enum ItemsChoiceType7
//{

//	/// <remarks/>
//	[System.Xml.Serialization.XmlEnum("urn:oasis:names:tc:SAML:2.0:assertion:AuthnContextClassRef")]
//	AuthnContextClassRef,

//	/// <remarks/>
//	[System.Xml.Serialization.XmlEnum("urn:oasis:names:tc:SAML:2.0:assertion:AuthnContextDeclRef")]
//	AuthnContextDeclRef,
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
//public enum AuthnContextComparisonType
//{

//	/// <remarks/>
//	exact,

//	/// <remarks/>
//	minimum,

//	/// <remarks/>
//	maximum,

//	/// <remarks/>
//	better,
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot("AttributeQuery", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
//public partial class AttributeQueryType : SubjectQueryAbstractType
//{

//	private AttributeType[] attributeField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("Attribute", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	public AttributeType[] Attribute
//	{
//		get
//		{
//			return attributeField;
//		}
//		set
//		{
//			attributeField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot("AuthzDecisionQuery", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
//public partial class AuthzDecisionQueryType : SubjectQueryAbstractType
//{

//	private ActionType[] actionField;

//	private EvidenceType evidenceField;

//	private string resourceField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("Action", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	public ActionType[] Action
//	{
//		get
//		{
//			return actionField;
//		}
//		set
//		{
//			actionField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	public EvidenceType Evidence
//	{
//		get
//		{
//			return evidenceField;
//		}
//		set
//		{
//			evidenceField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Resource
//	{
//		get
//		{
//			return resourceField;
//		}
//		set
//		{
//			resourceField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot("AuthnRequest", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
//public partial class AuthnRequestType : RequestAbstractType
//{

//	private SubjectType subjectField;

//	private NameIDPolicyType nameIDPolicyField;

//	private ConditionsType conditionsField;

//	private RequestedAuthnContextType requestedAuthnContextField;

//	private ScopingType scopingField;

//	private bool forceAuthnField;

//	private bool forceAuthnFieldSpecified;

//	private bool isPassiveField;

//	private bool isPassiveFieldSpecified;

//	private string protocolBindingField;

//	private ushort assertionConsumerServiceIndexField;

//	private bool assertionConsumerServiceIndexFieldSpecified;

//	private string assertionConsumerServiceURLField;

//	private ushort attributeConsumingServiceIndexField;

//	private bool attributeConsumingServiceIndexFieldSpecified;

//	private string providerNameField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	public SubjectType Subject
//	{
//		get
//		{
//			return subjectField;
//		}
//		set
//		{
//			subjectField = value;
//		}
//	}

//	/// <remarks/>
//	public NameIDPolicyType NameIDPolicy
//	{
//		get
//		{
//			return nameIDPolicyField;
//		}
//		set
//		{
//			nameIDPolicyField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	public ConditionsType Conditions
//	{
//		get
//		{
//			return conditionsField;
//		}
//		set
//		{
//			conditionsField = value;
//		}
//	}

//	/// <remarks/>
//	public RequestedAuthnContextType RequestedAuthnContext
//	{
//		get
//		{
//			return requestedAuthnContextField;
//		}
//		set
//		{
//			requestedAuthnContextField = value;
//		}
//	}

//	/// <remarks/>
//	public ScopingType Scoping
//	{
//		get
//		{
//			return scopingField;
//		}
//		set
//		{
//			scopingField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public bool ForceAuthn
//	{
//		get
//		{
//			return forceAuthnField;
//		}
//		set
//		{
//			forceAuthnField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool ForceAuthnSpecified
//	{
//		get
//		{
//			return forceAuthnFieldSpecified;
//		}
//		set
//		{
//			forceAuthnFieldSpecified = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public bool IsPassive
//	{
//		get
//		{
//			return isPassiveField;
//		}
//		set
//		{
//			isPassiveField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool IsPassiveSpecified
//	{
//		get
//		{
//			return isPassiveFieldSpecified;
//		}
//		set
//		{
//			isPassiveFieldSpecified = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string ProtocolBinding
//	{
//		get
//		{
//			return protocolBindingField;
//		}
//		set
//		{
//			protocolBindingField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public ushort AssertionConsumerServiceIndex
//	{
//		get
//		{
//			return assertionConsumerServiceIndexField;
//		}
//		set
//		{
//			assertionConsumerServiceIndexField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool AssertionConsumerServiceIndexSpecified
//	{
//		get
//		{
//			return assertionConsumerServiceIndexFieldSpecified;
//		}
//		set
//		{
//			assertionConsumerServiceIndexFieldSpecified = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string AssertionConsumerServiceURL
//	{
//		get
//		{
//			return assertionConsumerServiceURLField;
//		}
//		set
//		{
//			assertionConsumerServiceURLField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public ushort AttributeConsumingServiceIndex
//	{
//		get
//		{
//			return attributeConsumingServiceIndexField;
//		}
//		set
//		{
//			attributeConsumingServiceIndexField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool AttributeConsumingServiceIndexSpecified
//	{
//		get
//		{
//			return attributeConsumingServiceIndexFieldSpecified;
//		}
//		set
//		{
//			attributeConsumingServiceIndexFieldSpecified = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string ProviderName
//	{
//		get
//		{
//			return providerNameField;
//		}
//		set
//		{
//			providerNameField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class NameIDPolicyType
//{

//	private string formatField;

//	private string sPNameQualifierField;

//	private bool allowCreateField;

//	private bool allowCreateFieldSpecified;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Format
//	{
//		get
//		{
//			return formatField;
//		}
//		set
//		{
//			formatField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string SPNameQualifier
//	{
//		get
//		{
//			return sPNameQualifierField;
//		}
//		set
//		{
//			sPNameQualifierField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public bool AllowCreate
//	{
//		get
//		{
//			return allowCreateField;
//		}
//		set
//		{
//			allowCreateField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool AllowCreateSpecified
//	{
//		get
//		{
//			return allowCreateFieldSpecified;
//		}
//		set
//		{
//			allowCreateFieldSpecified = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class ScopingType
//{

//	private IDPListType iDPListField;

//	private string[] requesterIDField;

//	private string proxyCountField;

//	/// <remarks/>
//	public IDPListType IDPList
//	{
//		get
//		{
//			return iDPListField;
//		}
//		set
//		{
//			iDPListField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("RequesterID", DataType = "anyURI")]
//	public string[] RequesterID
//	{
//		get
//		{
//			return requesterIDField;
//		}
//		set
//		{
//			requesterIDField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "nonNegativeInteger")]
//	public string ProxyCount
//	{
//		get
//		{
//			return proxyCountField;
//		}
//		set
//		{
//			proxyCountField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class IDPListType
//{

//	private IDPEntryType[] iDPEntryField;

//	private string getCompleteField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("IDPEntry")]
//	public IDPEntryType[] IDPEntry
//	{
//		get
//		{
//			return iDPEntryField;
//		}
//		set
//		{
//			iDPEntryField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement(DataType = "anyURI")]
//	public string GetComplete
//	{
//		get
//		{
//			return getCompleteField;
//		}
//		set
//		{
//			getCompleteField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class IDPEntryType
//{

//	private string providerIDField;

//	private string nameField;

//	private string locField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string ProviderID
//	{
//		get
//		{
//			return providerIDField;
//		}
//		set
//		{
//			providerIDField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string Name
//	{
//		get
//		{
//			return nameField;
//		}
//		set
//		{
//			nameField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute(DataType = "anyURI")]
//	public string Loc
//	{
//		get
//		{
//			return locField;
//		}
//		set
//		{
//			locField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class ResponseType : StatusResponseType
//{

//	private object[] itemsField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("Assertion", typeof(AssertionType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	[System.Xml.Serialization.XmlElement("EncryptedAssertion", typeof(EncryptedElementType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	public object[] Items
//	{
//		get
//		{
//			return itemsField;
//		}
//		set
//		{
//			itemsField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot("ArtifactResolve", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
//public partial class ArtifactResolveType : RequestAbstractType
//{

//	private string artifactField;

//	/// <remarks/>
//	public string Artifact
//	{
//		get
//		{
//			return artifactField;
//		}
//		set
//		{
//			artifactField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot("ArtifactResponse", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
//public partial class ArtifactResponseType : StatusResponseType
//{

//	private System.Xml.XmlElement anyField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAnyElement()]
//	public System.Xml.XmlElement Any
//	{
//		get
//		{
//			return anyField;
//		}
//		set
//		{
//			anyField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class ManageNameIDRequestType : RequestAbstractType
//{

//	private object itemField;

//	private object item1Field;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("EncryptedID", typeof(EncryptedElementType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	[System.Xml.Serialization.XmlElement("NameID", typeof(NameIDType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	public object Item
//	{
//		get
//		{
//			return itemField;
//		}
//		set
//		{
//			itemField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("NewEncryptedID", typeof(EncryptedElementType))]
//	[System.Xml.Serialization.XmlElement("NewID", typeof(string))]
//	[System.Xml.Serialization.XmlElement("Terminate", typeof(TerminateType))]
//	public object Item1
//	{
//		get
//		{
//			return item1Field;
//		}
//		set
//		{
//			item1Field = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class TerminateType
//{
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class LogoutRequestType : RequestAbstractType
//{

//	private object itemField;

//	private string[] sessionIndexField;

//	private string reasonField;

//	private DateTime notOnOrAfterField;

//	private bool notOnOrAfterFieldSpecified;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("BaseID", typeof(BaseIDAbstractType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	[System.Xml.Serialization.XmlElement("EncryptedID", typeof(EncryptedElementType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	[System.Xml.Serialization.XmlElement("NameID", typeof(NameIDType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	public object Item
//	{
//		get
//		{
//			return itemField;
//		}
//		set
//		{
//			itemField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("SessionIndex")]
//	public string[] SessionIndex
//	{
//		get
//		{
//			return sessionIndexField;
//		}
//		set
//		{
//			sessionIndexField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public string Reason
//	{
//		get
//		{
//			return reasonField;
//		}
//		set
//		{
//			reasonField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlAttribute()]
//	public DateTime NotOnOrAfter
//	{
//		get
//		{
//			return notOnOrAfterField;
//		}
//		set
//		{
//			notOnOrAfterField = value;
//		}
//	}

//	/// <remarks/>
//	[System.Xml.Serialization.XmlIgnore()]
//	public bool NotOnOrAfterSpecified
//	{
//		get
//		{
//			return notOnOrAfterFieldSpecified;
//		}
//		set
//		{
//			notOnOrAfterFieldSpecified = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class NameIDMappingRequestType : RequestAbstractType
//{

//	private object itemField;

//	private NameIDPolicyType nameIDPolicyField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("BaseID", typeof(BaseIDAbstractType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	[System.Xml.Serialization.XmlElement("EncryptedID", typeof(EncryptedElementType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	[System.Xml.Serialization.XmlElement("NameID", typeof(NameIDType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	public object Item
//	{
//		get
//		{
//			return itemField;
//		}
//		set
//		{
//			itemField = value;
//		}
//	}

//	/// <remarks/>
//	public NameIDPolicyType NameIDPolicy
//	{
//		get
//		{
//			return nameIDPolicyField;
//		}
//		set
//		{
//			nameIDPolicyField = value;
//		}
//	}
//}

///// <remarks/>
//[Serializable()]
//[System.Xml.Serialization.XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
//[System.Xml.Serialization.XmlRoot(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = true)]
//public partial class NameIDMappingResponseType : StatusResponseType
//{

//	private object itemField;

//	/// <remarks/>
//	[System.Xml.Serialization.XmlElement("EncryptedID", typeof(EncryptedElementType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	[System.Xml.Serialization.XmlElement("NameID", typeof(NameIDType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
//	public object Item
//	{
//		get
//		{
//			return itemField;
//		}
//		set
//		{
//			itemField = value;
//		}
//	}
//}
