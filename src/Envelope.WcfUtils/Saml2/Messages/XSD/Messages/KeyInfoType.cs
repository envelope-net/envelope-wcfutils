// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.KeyInfoType
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
  /// <summary>
  /// 
  /// </summary>
  [GeneratedCode("xsd", "4.0.30319.1")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
  [System.Xml.Serialization.XmlRoot("KeyInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
  [Serializable]
  public class KeyInfoType
  {
    private object[] itemsField;
    private ItemsChoiceType2[] itemsElementNameField;
    private string[] textField;
    private string idField;

    /// <summary>Gets or sets the items.</summary>
    /// <value>The items.</value>
    [XmlAnyElement]
    [XmlElement("KeyName", typeof (string))]
    [XmlElement("KeyValue", typeof (KeyValueType))]
    [XmlElement("MgmtData", typeof (string))]
    [XmlElement("PGPData", typeof (PGPDataType))]
    [XmlElement("RetrievalMethod", typeof (RetrievalMethodType))]
    [XmlElement("SPKIData", typeof (SPKIDataType))]
    [XmlElement("X509Data", typeof (X509DataType))]
    [XmlChoiceIdentifier("ItemsElementName")]
    public object[] Items
    {
      get => this.itemsField;
      set => this.itemsField = value;
    }

    /// <summary>Gets or sets the name of the items element.</summary>
    /// <value>The name of the items element.</value>
    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType2[] ItemsElementName
    {
      get => this.itemsElementNameField;
      set => this.itemsElementNameField = value;
    }

    /// <summary>Gets or sets the text.</summary>
    /// <value>The text.</value>
    [XmlText]
    public string[] Text
    {
      get => this.textField;
      set => this.textField = value;
    }

    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    [XmlAttribute(DataType = "ID")]
    public string Id
    {
      get => this.idField;
      set => this.idField = value;
    }
  }
}
