// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.AttributeType
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
  [XmlInclude(typeof (RequestedAttributeType))]
  [GeneratedCode("xsd", "4.0.30319.1")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
  [System.Xml.Serialization.XmlRoot("Attribute", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
  [Serializable]
  public class AttributeType
  {
    private object[] attributeValueField;
    private string nameField;
    private string nameFormatField;
    private string friendlyNameField;
    private XmlAttribute[] anyAttrField;

    /// <remarks />
    [XmlElement("AttributeValue", IsNullable = true)]
    public object[] AttributeValue
    {
      get => this.attributeValueField;
      set => this.attributeValueField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string Name
    {
      get => this.nameField;
      set => this.nameField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string NameFormat
    {
      get => this.nameFormatField;
      set => this.nameFormatField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string FriendlyName
    {
      get => this.friendlyNameField;
      set => this.friendlyNameField = value;
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
