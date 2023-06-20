// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.AuthnAuthorityDescriptorType
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
  [XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
  [System.Xml.Serialization.XmlRoot("AuthnAuthorityDescriptor", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
  [Serializable]
  public class AuthnAuthorityDescriptorType : RoleDescriptorType
  {
    private EndpointType[] authnQueryServiceField;
    private EndpointType[] assertionIDRequestServiceField;
    private string[] nameIDFormatField;

    /// <remarks />
    [XmlElement("AuthnQueryService")]
    public EndpointType[] AuthnQueryService
    {
      get => this.authnQueryServiceField;
      set => this.authnQueryServiceField = value;
    }

    /// <remarks />
    [XmlElement("AssertionIDRequestService")]
    public EndpointType[] AssertionIDRequestService
    {
      get => this.assertionIDRequestServiceField;
      set => this.assertionIDRequestServiceField = value;
    }

    /// <remarks />
    [XmlElement("NameIDFormat", DataType = "anyURI")]
    public string[] NameIDFormat
    {
      get => this.nameIDFormatField;
      set => this.nameIDFormatField = value;
    }
  }
}
