// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.EncryptionMethodType
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
  [XmlType(Namespace = "http://www.w3.org/2001/04/xmlenc#")]
  [System.Xml.Serialization.XmlRoot("EncryptionMethod", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
  [Serializable]
  public class EncryptionMethodType
  {
    private string keySizeField;
    private byte[] oAEPparamsField;
    private XmlNode[] anyField;
    private string algorithmField;

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string KeySize
    {
      get => this.keySizeField;
      set => this.keySizeField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "base64Binary")]
    public byte[] OAEPparams
    {
      get => this.oAEPparamsField;
      set => this.oAEPparamsField = value;
    }

    /// <remarks />
    [XmlText]
    [XmlAnyElement]
    public XmlNode[] Any
    {
      get => this.anyField;
      set => this.anyField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string Algorithm
    {
      get => this.algorithmField;
      set => this.algorithmField = value;
    }
  }
}
