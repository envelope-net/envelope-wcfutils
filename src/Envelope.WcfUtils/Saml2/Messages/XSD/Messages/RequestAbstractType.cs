// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.RequestAbstractType
// Assembly: RBTeam.Saml2Lib, Version=4.7.2.1, Culture=neutral, PublicKeyToken=443400c129882e90
// MVID: 625824D1-DBAD-407F-86EE-CFDC4EF71CC8
// Assembly location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.dll
// XML documentation location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.xml

using Envelope.WcfUtils.Saml2.Helpers;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Envelope.WcfUtils.Saml2.Messages;

/// <summary>Base typ pre saml requesty</summary>
/// <remarks />
[XmlInclude(typeof(NameIDMappingRequestType))]
[XmlInclude(typeof(LogoutRequestType))]
[XmlInclude(typeof(ManageNameIDRequestType))]
[XmlInclude(typeof(ArtifactResolveType))]
[XmlInclude(typeof(AuthnRequestType))]
[XmlInclude(typeof(SubjectQueryAbstractType))]
[XmlInclude(typeof(AuthzDecisionQueryType))]
[XmlInclude(typeof(AttributeQueryType))]
[XmlInclude(typeof(AuthnQueryType))]
[XmlInclude(typeof(AssertionIDRequestType))]
[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
[Serializable]
public abstract class RequestAbstractType : ISaml2Message
{
	private NameIDType issuerField;
	private SignatureType signatureField;
	private ExtensionsType extensionsField;
	private string idField;
	private string versionField;
	private DateTime issueInstantField;
	private string destinationField;
	private string consentField;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Envelope.WcfUtils.Saml2.Messages.RequestAbstractType" /> class.
	/// </summary>
	protected RequestAbstractType() => this.Version = "2.0";

	/// <summary>Gets or sets the custom issue instant.</summary>
	/// <remarks>zvlast serizalizacia pre datumy, OIF vyzaduje v datumoch milisekundy</remarks>
	/// <value>The custom issue instant.</value>
	[XmlAttribute("IssueInstant")]
	public string CustomIssueInstant
	{
		get => MessageHelper.DateToString(this.issueInstantField);
		set => this.issueInstantField = MessageHelper.DateFromString(value);
	}

	/// <remarks />
	[XmlElement(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
	public NameIDType Issuer
	{
		get => this.issuerField;
		set => this.issuerField = value;
	}

	/// <remarks />
	[XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
	public SignatureType Signature
	{
		get => this.signatureField;
		set => this.signatureField = value;
	}

	/// <remarks />
	public ExtensionsType Extensions
	{
		get => this.extensionsField;
		set => this.extensionsField = value;
	}

	/// <remarks />
	[XmlAttribute(DataType = "ID")]
	public string ID
	{
		get => this.idField;
		set => this.idField = value;
	}

	/// <remarks />
	[XmlAttribute]
	public string Version
	{
		get => this.versionField;
		set => this.versionField = value;
	}

	/// <remarks />
	[XmlIgnore]
	public DateTime IssueInstant
	{
		get => this.issueInstantField;
		set => this.issueInstantField = value;
	}

	/// <remarks />
	[XmlAttribute(DataType = "anyURI")]
	public string Destination
	{
		get => this.destinationField;
		set => this.destinationField = value;
	}

	/// <remarks />
	[XmlAttribute(DataType = "anyURI")]
	public string Consent
	{
		get => this.consentField;
		set => this.consentField = value;
	}

	[XmlIgnore]
	public string? ReturnUrl { get; set; }
}
