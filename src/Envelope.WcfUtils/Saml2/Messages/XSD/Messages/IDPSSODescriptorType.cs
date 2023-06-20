// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.IDPSSODescriptorType
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
  [System.Xml.Serialization.XmlRoot("IDPSSODescriptor", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
  [Serializable]
  public class IDPSSODescriptorType : SSODescriptorType
  {
    private EndpointType[] singleSignOnServiceField;
    private EndpointType[] nameIDMappingServiceField;
    private EndpointType[] assertionIDRequestServiceField;
    private string[] attributeProfileField;
    private AttributeType[] attributeField;
    private bool wantAuthnRequestsSignedField;
    private bool wantAuthnRequestsSignedFieldSpecified;

    /// <remarks />
    [XmlElement("SingleSignOnService")]
    public EndpointType[] SingleSignOnService
    {
      get => this.singleSignOnServiceField;
      set => this.singleSignOnServiceField = value;
    }

    /// <remarks />
    [XmlElement("NameIDMappingService")]
    public EndpointType[] NameIDMappingService
    {
      get => this.nameIDMappingServiceField;
      set => this.nameIDMappingServiceField = value;
    }

    /// <remarks />
    [XmlElement("AssertionIDRequestService")]
    public EndpointType[] AssertionIDRequestService
    {
      get => this.assertionIDRequestServiceField;
      set => this.assertionIDRequestServiceField = value;
    }

    /// <remarks />
    [XmlElement("AttributeProfile", DataType = "anyURI")]
    public string[] AttributeProfile
    {
      get => this.attributeProfileField;
      set => this.attributeProfileField = value;
    }

    /// <remarks />
    [XmlElement("Attribute", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
    public AttributeType[] Attribute
    {
      get => this.attributeField;
      set => this.attributeField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public bool WantAuthnRequestsSigned
    {
      get => this.wantAuthnRequestsSignedField;
      set => this.wantAuthnRequestsSignedField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool WantAuthnRequestsSignedSpecified
    {
      get => this.wantAuthnRequestsSignedFieldSpecified;
      set => this.wantAuthnRequestsSignedFieldSpecified = value;
    }
  }
}
