// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.AuthnStatementType
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
  [XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
  [System.Xml.Serialization.XmlRoot("AuthnStatement", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
  [Serializable]
  public class AuthnStatementType : StatementAbstractType
  {
    private SubjectLocalityType subjectLocalityField;
    private AuthnContextType authnContextField;
    private DateTime authnInstantField;
    private string sessionIndexField;
    private DateTime sessionNotOnOrAfterField;
    private bool sessionNotOnOrAfterFieldSpecified;

    /// <remarks />
    public SubjectLocalityType SubjectLocality
    {
      get => this.subjectLocalityField;
      set => this.subjectLocalityField = value;
    }

    /// <remarks />
    public AuthnContextType AuthnContext
    {
      get => this.authnContextField;
      set => this.authnContextField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public DateTime AuthnInstant
    {
      get => this.authnInstantField;
      set => this.authnInstantField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string SessionIndex
    {
      get => this.sessionIndexField;
      set => this.sessionIndexField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public DateTime SessionNotOnOrAfter
    {
      get => this.sessionNotOnOrAfterField;
      set => this.sessionNotOnOrAfterField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool SessionNotOnOrAfterSpecified
    {
      get => this.sessionNotOnOrAfterFieldSpecified;
      set => this.sessionNotOnOrAfterFieldSpecified = value;
    }
  }
}
