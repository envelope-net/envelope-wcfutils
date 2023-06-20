// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.ContactType
// Assembly: RBTeam.Saml2Lib, Version=4.7.2.1, Culture=neutral, PublicKeyToken=443400c129882e90
// MVID: 625824D1-DBAD-407F-86EE-CFDC4EF71CC8
// Assembly location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.dll
// XML documentation location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.xml

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace Envelope.WcfUtils.Saml2.Messages
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.1")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
  [System.Xml.Serialization.XmlRoot("ContactPerson", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
  [Serializable]
  public class ContactType
  {
    private ExtensionsType1 extensionsField;
    private string companyField;
    private string givenNameField;
    private string surNameField;
    private string[] emailAddressField;
    private string[] telephoneNumberField;
    private ContactTypeType contactTypeField;
    private XmlAttribute[] anyAttrField;

    /// <remarks />
    public ExtensionsType1 Extensions
    {
      get => this.extensionsField;
      set => this.extensionsField = value;
    }

    /// <remarks />
    public string Company
    {
      get => this.companyField;
      set => this.companyField = value;
    }

    /// <remarks />
    public string GivenName
    {
      get => this.givenNameField;
      set => this.givenNameField = value;
    }

    /// <remarks />
    public string SurName
    {
      get => this.surNameField;
      set => this.surNameField = value;
    }

    /// <remarks />
    [XmlElement("EmailAddress", DataType = "anyURI")]
    public string[] EmailAddress
    {
      get => this.emailAddressField;
      set => this.emailAddressField = value;
    }

    /// <remarks />
    [XmlElement("TelephoneNumber")]
    public string[] TelephoneNumber
    {
      get => this.telephoneNumberField;
      set => this.telephoneNumberField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public ContactTypeType contactType
    {
      get => this.contactTypeField;
      set => this.contactTypeField = value;
    }

    /// <remarks />
    [XmlAnyAttribute]
    public XmlAttribute[] AnyAttr
    {
      get => this.anyAttrField;
      set => this.anyAttrField = value;
    }
  }
}
