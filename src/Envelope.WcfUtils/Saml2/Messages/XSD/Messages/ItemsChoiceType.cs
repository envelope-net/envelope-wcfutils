// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.ItemsChoiceType
// Assembly: RBTeam.Saml2Lib, Version=4.7.2.1, Culture=neutral, PublicKeyToken=443400c129882e90
// MVID: 625824D1-DBAD-407F-86EE-CFDC4EF71CC8
// Assembly location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.dll
// XML documentation location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.xml

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Envelope.WcfUtils.Saml2.Messages
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.1")]
  [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
  [Serializable]
  public enum ItemsChoiceType
  {
    /// <remarks />
    [XmlEnum("##any:")] Item,
    /// <remarks />
    X509CRL,
    /// <remarks />
    X509Certificate,
    /// <remarks />
    X509IssuerSerial,
    /// <remarks />
    X509SKI,
    /// <remarks />
    X509SubjectName,
  }
}
