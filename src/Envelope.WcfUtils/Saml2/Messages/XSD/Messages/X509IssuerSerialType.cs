// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.X509IssuerSerialType
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
  [Serializable]
  public class X509IssuerSerialType
  {
    private string x509IssuerNameField;
    private string x509SerialNumberField;

    /// <remarks />
    public string X509IssuerName
    {
      get => this.x509IssuerNameField;
      set => this.x509IssuerNameField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string X509SerialNumber
    {
      get => this.x509SerialNumberField;
      set => this.x509SerialNumberField = value;
    }
  }
}
