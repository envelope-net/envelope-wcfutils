// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.EncryptedType
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
  [XmlInclude(typeof (EncryptedKeyType))]
  [XmlInclude(typeof (EncryptedDataType))]
  [GeneratedCode("xsd", "4.0.30319.1")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://www.w3.org/2001/04/xmlenc#")]
  [Serializable]
  public abstract class EncryptedType
  {
    private EncryptionMethodType encryptionMethodField;
    private KeyInfoType keyInfoField;
    private CipherDataType cipherDataField;
    private EncryptionPropertiesType encryptionPropertiesField;
    private string idField;
    private string typeField;
    private string mimeTypeField;
    private string encodingField;

    /// <remarks />
    public EncryptionMethodType EncryptionMethod
    {
      get => this.encryptionMethodField;
      set => this.encryptionMethodField = value;
    }

    /// <remarks />
    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public KeyInfoType KeyInfo
    {
      get => this.keyInfoField;
      set => this.keyInfoField = value;
    }

    /// <remarks />
    public CipherDataType CipherData
    {
      get => this.cipherDataField;
      set => this.cipherDataField = value;
    }

    /// <remarks />
    public EncryptionPropertiesType EncryptionProperties
    {
      get => this.encryptionPropertiesField;
      set => this.encryptionPropertiesField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string Id
    {
      get => this.idField;
      set => this.idField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string Type
    {
      get => this.typeField;
      set => this.typeField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string MimeType
    {
      get => this.mimeTypeField;
      set => this.mimeTypeField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string Encoding
    {
      get => this.encodingField;
      set => this.encodingField = value;
    }
  }
}
