// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.DSAKeyValueType
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
  [System.Xml.Serialization.XmlRoot("DSAKeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
  [Serializable]
  public class DSAKeyValueType
  {
    private byte[] pField;
    private byte[] qField;
    private byte[] gField;
    private byte[] yField;
    private byte[] jField;
    private byte[] seedField;
    private byte[] pgenCounterField;

    /// <remarks />
    [XmlElement(DataType = "base64Binary")]
    public byte[] P
    {
      get => this.pField;
      set => this.pField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "base64Binary")]
    public byte[] Q
    {
      get => this.qField;
      set => this.qField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "base64Binary")]
    public byte[] G
    {
      get => this.gField;
      set => this.gField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "base64Binary")]
    public byte[] Y
    {
      get => this.yField;
      set => this.yField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "base64Binary")]
    public byte[] J
    {
      get => this.jField;
      set => this.jField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "base64Binary")]
    public byte[] Seed
    {
      get => this.seedField;
      set => this.seedField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "base64Binary")]
    public byte[] PgenCounter
    {
      get => this.pgenCounterField;
      set => this.pgenCounterField = value;
    }
  }
}
