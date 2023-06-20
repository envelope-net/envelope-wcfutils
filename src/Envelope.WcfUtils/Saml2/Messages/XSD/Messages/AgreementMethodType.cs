// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.AgreementMethodType
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
  [System.Xml.Serialization.XmlRoot("AgreementMethod", Namespace = "http://www.w3.org/2001/04/xmlenc#", IsNullable = false)]
  [Serializable]
  public class AgreementMethodType
  {
    private byte[] kANonceField;
    private XmlNode[] anyField;
    private KeyInfoType originatorKeyInfoField;
    private KeyInfoType recipientKeyInfoField;
    private string algorithmField;

    /// <summary>Gets or sets the ka nonce.</summary>
    /// <value>The ka nonce.</value>
    [XmlElement("KA-Nonce", DataType = "base64Binary")]
    public byte[] KANonce
    {
      get => this.kANonceField;
      set => this.kANonceField = value;
    }

    /// <summary>Gets or sets any.</summary>
    /// <value>Any.</value>
    [XmlText]
    [XmlAnyElement]
    public XmlNode[] Any
    {
      get => this.anyField;
      set => this.anyField = value;
    }

    /// <remarks />
    public KeyInfoType OriginatorKeyInfo
    {
      get => this.originatorKeyInfoField;
      set => this.originatorKeyInfoField = value;
    }

    /// <summary>Gets or sets the recipient key information.</summary>
    /// <value>The recipient key information.</value>
    public KeyInfoType RecipientKeyInfo
    {
      get => this.recipientKeyInfoField;
      set => this.recipientKeyInfoField = value;
    }

    /// <summary>Gets or sets the algorithm.</summary>
    /// <value>The algorithm.</value>
    [XmlAttribute(DataType = "anyURI")]
    public string Algorithm
    {
      get => this.algorithmField;
      set => this.algorithmField = value;
    }
  }
}
