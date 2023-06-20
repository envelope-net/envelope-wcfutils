// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.ConditionsType
// Assembly: RBTeam.Saml2Lib, Version=4.7.2.1, Culture=neutral, PublicKeyToken=443400c129882e90
// MVID: 625824D1-DBAD-407F-86EE-CFDC4EF71CC8
// Assembly location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.dll
// XML documentation location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.xml

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Envelope.WcfUtils.Saml2.Messages;

/// <remarks />
[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
[System.Xml.Serialization.XmlRoot("Conditions", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
[Serializable]
public class ConditionsType
{
	private ConditionAbstractType[] itemsField;
	private DateTime notBeforeField;
	private bool notBeforeFieldSpecified;
	private DateTime notOnOrAfterField;
	private bool notOnOrAfterFieldSpecified;

	/// <summary>Gets the audience restriction.</summary>
	/// <value>The audience restriction.</value>
	public AudienceRestrictionType AudienceRestriction => this.Items == null || this.Items.Length == 0 ? (AudienceRestrictionType)null : (AudienceRestrictionType)((IEnumerable<ConditionAbstractType>)this.Items).FirstOrDefault<ConditionAbstractType>((Func<ConditionAbstractType, bool>)(item => item is AudienceRestrictionType));

	/// <remarks />
	[XmlElement("AudienceRestriction", typeof(AudienceRestrictionType))]
	[XmlElement("Condition", typeof(ConditionAbstractType))]
	[XmlElement("OneTimeUse", typeof(OneTimeUseType))]
	[XmlElement("ProxyRestriction", typeof(ProxyRestrictionType))]
	public ConditionAbstractType[] Items
	{
		get => this.itemsField;
		set => this.itemsField = value;
	}

	/// <remarks />
	[XmlAttribute]
	public DateTime NotBefore
	{
		get => this.notBeforeField;
		set => this.notBeforeField = value;
	}

	/// <remarks />
	[XmlIgnore]
	public bool NotBeforeSpecified
	{
		get => this.notBeforeFieldSpecified;
		set => this.notBeforeFieldSpecified = value;
	}

	/// <remarks />
	[XmlAttribute]
	public DateTime NotOnOrAfter
	{
		get => this.notOnOrAfterField;
		set => this.notOnOrAfterField = value;
	}

	/// <remarks />
	[XmlIgnore]
	public bool NotOnOrAfterSpecified
	{
		get => this.notOnOrAfterFieldSpecified;
		set => this.notOnOrAfterFieldSpecified = value;
	}
}
