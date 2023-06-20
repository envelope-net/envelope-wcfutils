// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.SignatureType
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
  [System.Xml.Serialization.XmlRoot("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
  [Serializable]
  public class SignatureType
  {
    private SignedInfoType signedInfoField;
    private SignatureValueType signatureValueField;
    private KeyInfoType keyInfoField;
    private ObjectType[] objectField;
    private string idField;

    /// <remarks />
    public SignedInfoType SignedInfo
    {
      get => this.signedInfoField;
      set => this.signedInfoField = value;
    }

    /// <remarks />
    public SignatureValueType SignatureValue
    {
      get => this.signatureValueField;
      set => this.signatureValueField = value;
    }

    /// <remarks />
    public KeyInfoType KeyInfo
    {
      get => this.keyInfoField;
      set => this.keyInfoField = value;
    }

    /// <remarks />
    [XmlElement("Object")]
    public ObjectType[] Object
    {
      get => this.objectField;
      set => this.objectField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string Id
    {
      get => this.idField;
      set => this.idField = value;
    }
  }
}
