// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.AssertionType
// Assembly: RBTeam.Saml2Lib, Version=4.7.2.1, Culture=neutral, PublicKeyToken=443400c129882e90
// MVID: 625824D1-DBAD-407F-86EE-CFDC4EF71CC8
// Assembly location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.dll
// XML documentation location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.xml

using Envelope.WcfUtils.Saml2.Helpers;
using Envelope.WcfUtils.Saml2.Model;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Envelope.WcfUtils.Saml2.Messages;

/// <summary>The assertion type</summary>
/// <remarks />
[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
[System.Xml.Serialization.XmlRoot("Assertion", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
[Serializable]
public class AssertionType
{
	private AssertionAttributes attributes;
	private NameIDType issuerField;
	private SignatureType signatureField;
	private SubjectType subjectField;
	private ConditionsType conditionsField;
	private AdviceType adviceField;
	private StatementAbstractType[] itemsField;
	private string versionField;
	private string idField;
	private DateTime issueInstantField;

	/// <summary>
	/// zvlast serizalizacia pre datumy, OIF vyzaduje v datumoch milisekundy
	/// </summary>
	/// <value>The custom issue instant.</value>
	[XmlAttribute("IssueInstant")]
	public string CustomIssueInstant
	{
		get => MessageHelper.DateToString(this.issueInstantField);
		set => this.issueInstantField = MessageHelper.DateFromString(value);
	}

	/// <summary>Gets the authn statement.</summary>
	/// <value>The authn statement.</value>
	public AuthnStatementType AuthnStatement => this.Items == null || this.Items.Length == 0 ? (AuthnStatementType)null : (AuthnStatementType)((IEnumerable<StatementAbstractType>)this.Items).FirstOrDefault<StatementAbstractType>((Func<StatementAbstractType, bool>)(item => item is AuthnStatementType));

	/// <summary>Gets the authn context class reference.</summary>
	/// <value>The authn context class reference.</value>
	public string AuthnContextClassRef => this.AuthnStatement?.AuthnContext?.Items == null || this.AuthnStatement.AuthnContext.Items.Length == 0 ? (string)null : this.AuthnStatement.AuthnContext.Items[0] as string;

	internal AssertionAttributes Attributes => this.attributes ?? (this.attributes = new AssertionAttributes((IEnumerable<StatementAbstractType>)this.Items));

	/// <remarks />
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
	public SubjectType Subject
	{
		get => this.subjectField;
		set => this.subjectField = value;
	}

	/// <remarks />
	public ConditionsType Conditions
	{
		get => this.conditionsField;
		set => this.conditionsField = value;
	}

	/// <remarks />
	public AdviceType Advice
	{
		get => this.adviceField;
		set => this.adviceField = value;
	}

	/// <remarks />
	[XmlElement("AttributeStatement", typeof(AttributeStatementType))]
	[XmlElement("AuthnStatement", typeof(AuthnStatementType))]
	[XmlElement("AuthzDecisionStatement", typeof(AuthzDecisionStatementType))]
	[XmlElement("Statement", typeof(StatementAbstractType))]
	public StatementAbstractType[] Items
	{
		get => this.itemsField;
		set => this.itemsField = value;
	}

	/// <remarks />
	[XmlAttribute]
	public string Version
	{
		get => this.versionField;
		set => this.versionField = value;
	}

	/// <remarks />
	[XmlAttribute(DataType = "ID")]
	public string ID
	{
		get => this.idField;
		set => this.idField = value;
	}

	/// <remarks />
	[XmlIgnore]
	public DateTime IssueInstant
	{
		get => this.issueInstantField;
		set => this.issueInstantField = value;
	}
}
