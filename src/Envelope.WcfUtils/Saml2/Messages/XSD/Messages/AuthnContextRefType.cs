// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.AuthnContextRefType
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
  [XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IncludeInSchema = false)]
  [Serializable]
  public enum AuthnContextRefType
  {
    /// <remarks />
    [XmlEnum("urn:oasis:names:tc:SAML:2.0:assertion:AuthnContextClassRef")] AuthnContextClassRef,
    /// <remarks />
    [XmlEnum("urn:oasis:names:tc:SAML:2.0:assertion:AuthnContextDeclRef")] AuthnContextDeclRef,
  }
}
