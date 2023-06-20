// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.SPSSODescriptorType
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
  [System.Xml.Serialization.XmlRoot("SPSSODescriptor", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
  [Serializable]
  public class SPSSODescriptorType : SSODescriptorType
  {
    private IndexedEndpointType[] assertionConsumerServiceField;
    private AttributeConsumingServiceType[] attributeConsumingServiceField;
    private bool authnRequestsSignedField;
    private bool authnRequestsSignedFieldSpecified;
    private bool wantAssertionsSignedField;
    private bool wantAssertionsSignedFieldSpecified;

    /// <remarks />
    [XmlElement("AssertionConsumerService")]
    public IndexedEndpointType[] AssertionConsumerService
    {
      get => this.assertionConsumerServiceField;
      set => this.assertionConsumerServiceField = value;
    }

    /// <remarks />
    [XmlElement("AttributeConsumingService")]
    public AttributeConsumingServiceType[] AttributeConsumingService
    {
      get => this.attributeConsumingServiceField;
      set => this.attributeConsumingServiceField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public bool AuthnRequestsSigned
    {
      get => this.authnRequestsSignedField;
      set => this.authnRequestsSignedField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool AuthnRequestsSignedSpecified
    {
      get => this.authnRequestsSignedFieldSpecified;
      set => this.authnRequestsSignedFieldSpecified = value;
    }

    /// <remarks />
    [XmlAttribute]
    public bool WantAssertionsSigned
    {
      get => this.wantAssertionsSignedField;
      set => this.wantAssertionsSignedField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool WantAssertionsSignedSpecified
    {
      get => this.wantAssertionsSignedFieldSpecified;
      set => this.wantAssertionsSignedFieldSpecified = value;
    }
  }
}
