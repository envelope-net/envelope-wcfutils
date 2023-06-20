// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.StatusResponseType
// Assembly: RBTeam.Saml2Lib, Version=4.7.2.1, Culture=neutral, PublicKeyToken=443400c129882e90
// MVID: 625824D1-DBAD-407F-86EE-CFDC4EF71CC8
// Assembly location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.dll
// XML documentation location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.xml

using Envelope.WcfUtils.Saml2.Helpers;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Envelope.WcfUtils.Saml2.Messages
{
	/// <summary>Base typ pre response</summary>
	/// <remarks />
	[XmlInclude(typeof(NameIDMappingResponseType))]
	[XmlInclude(typeof(ArtifactResponseType))]
	[XmlInclude(typeof(ResponseType))]
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
	[System.Xml.Serialization.XmlRoot("ManageNameIDResponse", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
	[Serializable]
	public class StatusResponseType : ISaml2ResponseMessage, ISaml2Message
	{
		private NameIDType issuerField;
		private SignatureType signatureField;
		private ExtensionsType extensionsField;
		private StatusType statusField;
		private string idField;
		private string inResponseToField;
		private string versionField;
		private DateTime issueInstantField;
		private string destinationField;
		private string consentField;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Envelope.WcfUtils.Saml2.Messages.StatusResponseType" /> class.
		/// </summary>
		public StatusResponseType() => this.Version = "2.0";

		/// <summary>Gets or sets the custom serialized issue instant.</summary>
		/// <value>The custom serialized issue instant.</value>
		[XmlAttribute("IssueInstant")]
		public string CustomSerializedIssueInstant
		{
			get => MessageHelper.DateToString(this.issueInstantField);
			set => this.issueInstantField = MessageHelper.DateFromString(value);
		}

		/// <summary>Gets or sets the status code.</summary>
		/// <value>The status code.</value>
		[XmlIgnore]
		public string StatusCode
		{
			get => MessageHelper.GetResponseStatus((ISaml2ResponseMessage)this);
			set => MessageHelper.SetResponseStatus((ISaml2ResponseMessage)this, value);
		}

		/// <summary>Gets or sets the second level status code.</summary>
		/// <value>The second level status code.</value>
		[XmlIgnore]
		public string SecondLevelStatusCode
		{
			get => MessageHelper.GetSecondLevelResponseStatus((ISaml2ResponseMessage)this);
			set => MessageHelper.SetResponseStatus((ISaml2ResponseMessage)this, value);
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
		public StatusType Status
		{
			get => this.statusField;
			set => this.statusField = value;
		}

		/// <remarks />
		[XmlAttribute(DataType = "ID")]
		public string ID
		{
			get => this.idField;
			set => this.idField = value;
		}

		/// <remarks />
		[XmlAttribute(DataType = "NCName")]
		public string InResponseTo
		{
			get => this.inResponseToField;
			set => this.inResponseToField = value;
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
	}
}
