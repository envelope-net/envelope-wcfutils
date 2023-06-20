// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.SubjectType
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
[System.Xml.Serialization.XmlRoot("Subject", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
[Serializable]
public class SubjectType
{
	private object[] itemsField;

	/// <summary>Gets the name identifier.</summary>
	/// <value>The name identifier.</value>
	public NameIDType NameID => this.Items == null || this.Items.Length == 0 ? (NameIDType)null : (NameIDType)((IEnumerable<object>)this.Items).FirstOrDefault<object>((Func<object, bool>)(item => item is NameIDType));

	/// <summary>Gets the subject confirmation.</summary>
	/// <value>The subject confirmation.</value>
	public SubjectConfirmationType SubjectConfirmation => this.Items == null || this.Items.Length == 0 ? (SubjectConfirmationType)null : (SubjectConfirmationType)((IEnumerable<object>)this.Items).FirstOrDefault<object>((Func<object, bool>)(item => item is SubjectConfirmationType));

	/// <remarks />
	[XmlElement("BaseID", typeof(BaseIDAbstractType))]
	[XmlElement("EncryptedID", typeof(EncryptedElementType))]
	[XmlElement("NameID", typeof(NameIDType))]
	[XmlElement("SubjectConfirmation", typeof(SubjectConfirmationType))]
	public object[] Items
	{
		get => this.itemsField;
		set => this.itemsField = value;
	}
}
