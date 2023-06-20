// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.X509DataType
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
  [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
  [System.Xml.Serialization.XmlRoot("X509Data", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
  [Serializable]
  public class X509DataType
  {
    private object[] itemsField;
    private ItemsChoiceType[] itemsElementNameField;

    /// <remarks />
    [XmlAnyElement]
    [XmlElement("X509CRL", typeof (byte[]), DataType = "base64Binary")]
    [XmlElement("X509Certificate", typeof (byte[]), DataType = "base64Binary")]
    [XmlElement("X509IssuerSerial", typeof (X509IssuerSerialType))]
    [XmlElement("X509SKI", typeof (byte[]), DataType = "base64Binary")]
    [XmlElement("X509SubjectName", typeof (string))]
    [XmlChoiceIdentifier("ItemsElementName")]
    public object[] Items
    {
      get => this.itemsField;
      set => this.itemsField = value;
    }

    /// <remarks />
    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType[] ItemsElementName
    {
      get => this.itemsElementNameField;
      set => this.itemsElementNameField = value;
    }
  }
}
