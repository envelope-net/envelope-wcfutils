// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.RequestedAuthnContextType
// Assembly: RBTeam.Saml2Lib, Version=4.7.2.1, Culture=neutral, PublicKeyToken=443400c129882e90
// MVID: 625824D1-DBAD-407F-86EE-CFDC4EF71CC8
// Assembly location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.dll
// XML documentation location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.xml

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Envelope.WcfUtils.Saml2.Messages
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.1")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
  [System.Xml.Serialization.XmlRoot("RequestedAuthnContext", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
  [Serializable]
  public class RequestedAuthnContextType
  {
    private string[] itemsField;
    private AuthnContextRefType[] itemsElementNameField;
    private AuthnContextComparisonType comparisonField;
    private bool comparisonFieldSpecified;

    /// <remarks />
    [XmlElement("AuthnContextClassRef", typeof (string), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", DataType = "anyURI")]
    [XmlElement("AuthnContextDeclRef", typeof (string), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", DataType = "anyURI")]
    [XmlChoiceIdentifier("ItemsElementName")]
    public string[] Items
    {
      get => this.itemsField;
      set => this.itemsField = value;
    }

    /// <remarks />
    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public AuthnContextRefType[] ItemsElementName
    {
      get => this.itemsElementNameField;
      set => this.itemsElementNameField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public AuthnContextComparisonType Comparison
    {
      get => this.comparisonField;
      set => this.comparisonField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool ComparisonSpecified
    {
      get => this.comparisonFieldSpecified;
      set => this.comparisonFieldSpecified = value;
    }
  }
}
