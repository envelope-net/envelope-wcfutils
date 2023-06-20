// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.PGPDataType
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
  [System.Xml.Serialization.XmlRoot("PGPData", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
  [Serializable]
  public class PGPDataType
  {
    private object[] itemsField;
    private ItemsChoiceType1[] itemsElementNameField;

    /// <remarks />
    [XmlAnyElement]
    [XmlElement("PGPKeyID", typeof (byte[]), DataType = "base64Binary")]
    [XmlElement("PGPKeyPacket", typeof (byte[]), DataType = "base64Binary")]
    [XmlChoiceIdentifier("ItemsElementName")]
    public object[] Items
    {
      get => this.itemsField;
      set => this.itemsField = value;
    }

    /// <remarks />
    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType1[] ItemsElementName
    {
      get => this.itemsElementNameField;
      set => this.itemsElementNameField = value;
    }
  }
}
