// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.ResponseType
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
[XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
[System.Xml.Serialization.XmlRoot("Response", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
[Serializable]
public class ResponseType : StatusResponseType
{
	private object[] itemsField;

	/// <summary>Gets or sets the assertion raw.</summary>
	/// <value>The assertion raw.</value>
	public string AssertionRaw { get; set; }

	/// <summary>Gets or sets the assertion.</summary>
	/// <value>The assertion.</value>
	public AssertionType Assertion
	{
		get => this.Items != null && this.Items.Length != 0 ? this.Items[0] as AssertionType : (AssertionType)null;
		set
		{
			if (this.Items == null || this.Items.Length != 1)
				this.Items = new object[1];
			this.Items[0] = (object)value;
		}
	}

	/// <summary>Gets or sets the encrypted assertion.</summary>
	/// <value>The encrypted assertion.</value>
	public EncryptedElementType EncryptedAssertion
	{
		get => this.Items != null && this.Items.Length != 0 ? this.Items[0] as EncryptedElementType : (EncryptedElementType)null;
		set
		{
			if (this.Items == null || this.Items.Length != 1)
				this.Items = new object[1];
			this.Items[0] = (object)value;
		}
	}

	/// <remarks />
	[XmlElement("Assertion", typeof(AssertionType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
	[XmlElement("EncryptedAssertion", typeof(EncryptedElementType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
	public object[] Items
	{
		get => this.itemsField;
		set => this.itemsField = value;
	}
}
