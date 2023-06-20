// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.AffiliationDescriptorType
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
  [GeneratedCode("xsd", "4.0.30319.1")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
  [System.Xml.Serialization.XmlRoot("AffiliationDescriptor", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
  [Serializable]
  public class AffiliationDescriptorType
  {
    private SignatureType signatureField;
    private ExtensionsType1 extensionsField;
    private string[] affiliateMemberField;
    private KeyDescriptorType[] keyDescriptorField;
    private string affiliationOwnerIDField;
    private DateTime validUntilField;
    private bool validUntilFieldSpecified;
    private string cacheDurationField;
    private string idField;
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
    [XmlElement("AffiliateMember", DataType = "anyURI")]
    public string[] AffiliateMember
    {
      get => this.affiliateMemberField;
      set => this.affiliateMemberField = value;
    }

    /// <remarks />
    [XmlElement("KeyDescriptor")]
    public KeyDescriptorType[] KeyDescriptor
    {
      get => this.keyDescriptorField;
      set => this.keyDescriptorField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string affiliationOwnerID
    {
      get => this.affiliationOwnerIDField;
      set => this.affiliationOwnerIDField = value;
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
    [XmlAttribute(DataType = "ID")]
    public string ID
    {
      get => this.idField;
      set => this.idField = value;
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
