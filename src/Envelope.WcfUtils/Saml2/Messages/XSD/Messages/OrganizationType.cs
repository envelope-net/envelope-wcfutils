// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.OrganizationType
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
  [System.Xml.Serialization.XmlRoot("Organization", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
  [Serializable]
  public class OrganizationType
  {
    private ExtensionsType1 extensionsField;
    private localizedNameType[] organizationNameField;
    private localizedNameType[] organizationDisplayNameField;
    private localizedURIType[] organizationURLField;
    private XmlAttribute[] anyAttrField;

    /// <remarks />
    public ExtensionsType1 Extensions
    {
      get => this.extensionsField;
      set => this.extensionsField = value;
    }

    /// <remarks />
    [XmlElement("OrganizationName")]
    public localizedNameType[] OrganizationName
    {
      get => this.organizationNameField;
      set => this.organizationNameField = value;
    }

    /// <remarks />
    [XmlElement("OrganizationDisplayName")]
    public localizedNameType[] OrganizationDisplayName
    {
      get => this.organizationDisplayNameField;
      set => this.organizationDisplayNameField = value;
    }

    /// <remarks />
    [XmlElement("OrganizationURL")]
    public localizedURIType[] OrganizationURL
    {
      get => this.organizationURLField;
      set => this.organizationURLField = value;
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
