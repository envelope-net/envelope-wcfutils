// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.AuthnRequestType
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
  /// <summary>The Authn Request Type class</summary>
  /// <seealso cref="T:Envelope.WcfUtils.Saml2.Messages.RequestAbstractType" />
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.1")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
  [System.Xml.Serialization.XmlRoot("AuthnRequest", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
  [Serializable]
  public class AuthnRequestType : RequestAbstractType
  {
    private SubjectType subjectField;
    private NameIDPolicyType nameIDPolicyField;
    private ConditionsType conditionsField;
    private RequestedAuthnContextType requestedAuthnContextField;
    private ScopingType scopingField;
    private bool forceAuthnField;
    private bool forceAuthnFieldSpecified;
    private bool isPassiveField;
    private bool isPassiveFieldSpecified;
    private string protocolBindingField;
    private ushort assertionConsumerServiceIndexField;
    private bool assertionConsumerServiceIndexFieldSpecified;
    private string assertionConsumerServiceURLField;
    private ushort attributeConsumingServiceIndexField;
    private bool attributeConsumingServiceIndexFieldSpecified;
    private string providerNameField;

    /// <remarks />
    [XmlElement(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
    public SubjectType Subject
    {
      get => this.subjectField;
      set => this.subjectField = value;
    }

    /// <remarks />
    public NameIDPolicyType NameIDPolicy
    {
      get => this.nameIDPolicyField;
      set => this.nameIDPolicyField = value;
    }

    /// <remarks />
    [XmlElement(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
    public ConditionsType Conditions
    {
      get => this.conditionsField;
      set => this.conditionsField = value;
    }

    /// <remarks />
    public RequestedAuthnContextType RequestedAuthnContext
    {
      get => this.requestedAuthnContextField;
      set => this.requestedAuthnContextField = value;
    }

    /// <remarks />
    public ScopingType Scoping
    {
      get => this.scopingField;
      set => this.scopingField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public bool ForceAuthn
    {
      get => this.forceAuthnField;
      set => this.forceAuthnField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool ForceAuthnSpecified
    {
      get => this.forceAuthnFieldSpecified;
      set => this.forceAuthnFieldSpecified = value;
    }

    /// <remarks />
    [XmlAttribute]
    public bool IsPassive
    {
      get => this.isPassiveField;
      set => this.isPassiveField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool IsPassiveSpecified
    {
      get => this.isPassiveFieldSpecified;
      set => this.isPassiveFieldSpecified = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string ProtocolBinding
    {
      get => this.protocolBindingField;
      set => this.protocolBindingField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public ushort AssertionConsumerServiceIndex
    {
      get => this.assertionConsumerServiceIndexField;
      set => this.assertionConsumerServiceIndexField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool AssertionConsumerServiceIndexSpecified
    {
      get => this.assertionConsumerServiceIndexFieldSpecified;
      set => this.assertionConsumerServiceIndexFieldSpecified = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string AssertionConsumerServiceURL
    {
      get => this.assertionConsumerServiceURLField;
      set => this.assertionConsumerServiceURLField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public ushort AttributeConsumingServiceIndex
    {
      get => this.attributeConsumingServiceIndexField;
      set => this.attributeConsumingServiceIndexField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool AttributeConsumingServiceIndexSpecified
    {
      get => this.attributeConsumingServiceIndexFieldSpecified;
      set => this.attributeConsumingServiceIndexFieldSpecified = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string ProviderName
    {
      get => this.providerNameField;
      set => this.providerNameField = value;
    }
  }
}
