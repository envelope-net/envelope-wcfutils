// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.RoleDescriptorType
// Assembly: RBTeam.Saml2Lib, Version=4.7.2.1, Culture=neutral, PublicKeyToken=443400c129882e90
// MVID: 625824D1-DBAD-407F-86EE-CFDC4EF71CC8
// Assembly location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.dll
// XML documentation location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.xml

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace Envelope.WcfUtils.Saml2.Messages
{
  /// <remarks />
  [XmlInclude(typeof (AttributeAuthorityDescriptorType))]
  [XmlInclude(typeof (PDPDescriptorType))]
  [XmlInclude(typeof (AuthnAuthorityDescriptorType))]
  [XmlInclude(typeof (SSODescriptorType))]
  [XmlInclude(typeof (SPSSODescriptorType))]
  [XmlInclude(typeof (IDPSSODescriptorType))]
  [GeneratedCode("xsd", "4.0.30319.1")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
  [System.Xml.Serialization.XmlRoot("RoleDescriptor", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
  [Serializable]
  public abstract class RoleDescriptorType
  {
    private SignatureType signatureField;
    private ExtensionsType1 extensionsField;
    private KeyDescriptorType[] keyDescriptorField;
    private OrganizationType organizationField;
    private ContactType[] contactPersonField;
    private string idField;
    private DateTime validUntilField;
    private bool validUntilFieldSpecified;
    private string cacheDurationField;
    private string[] protocolSupportEnumerationField;
    private string errorURLField;
    private XmlAttribute[] anyAttrField;

    /// <remarks />
    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
      get => this.signatureField;
      set => this.signatureField = value;
    }

    /// <remarks />
    public ExtensionsType1 Extensions
    {
      get => this.extensionsField;
      set => this.extensionsField = value;
    }

    /// <remarks />
    [XmlElement("KeyDescriptor")]
    public KeyDescriptorType[] KeyDescriptor
    {
      get => this.keyDescriptorField;
      set => this.keyDescriptorField = value;
    }

    /// <remarks />
    public OrganizationType Organization
    {
      get => this.organizationField;
      set => this.organizationField = value;
    }

    /// <remarks />
    [XmlElement("ContactPerson")]
    public ContactType[] ContactPerson
    {
      get => this.contactPersonField;
      set => this.contactPersonField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string ID
    {
      get => this.idField;
      set => this.idField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public DateTime validUntil
    {
      get => this.validUntilField;
      set => this.validUntilField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool validUntilSpecified
    {
      get => this.validUntilFieldSpecified;
      set => this.validUntilFieldSpecified = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "duration")]
    public string cacheDuration
    {
      get => this.cacheDurationField;
      set => this.cacheDurationField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string[] protocolSupportEnumeration
    {
      get => this.protocolSupportEnumerationField;
      set => this.protocolSupportEnumerationField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string errorURL
    {
      get => this.errorURLField;
      set => this.errorURLField = value;
    }

    /// <remarks />
    [XmlAnyAttribute]
    public XmlAttribute[] AnyAttr
    {
      get => this.anyAttrField;
      set => this.anyAttrField = value;
    }
  }
}
