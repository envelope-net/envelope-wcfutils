// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.SSODescriptorType
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
  [XmlInclude(typeof (SPSSODescriptorType))]
  [XmlInclude(typeof (IDPSSODescriptorType))]
  [GeneratedCode("xsd", "4.0.30319.1")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
  [Serializable]
  public abstract class SSODescriptorType : RoleDescriptorType
  {
    private IndexedEndpointType[] artifactResolutionServiceField;
    private EndpointType[] singleLogoutServiceField;
    private EndpointType[] manageNameIDServiceField;
    private string[] nameIDFormatField;

    /// <remarks />
    [XmlElement("ArtifactResolutionService")]
    public IndexedEndpointType[] ArtifactResolutionService
    {
      get => this.artifactResolutionServiceField;
      set => this.artifactResolutionServiceField = value;
    }

    /// <remarks />
    [XmlElement("SingleLogoutService")]
    public EndpointType[] SingleLogoutService
    {
      get => this.singleLogoutServiceField;
      set => this.singleLogoutServiceField = value;
    }

    /// <remarks />
    [XmlElement("ManageNameIDService")]
    public EndpointType[] ManageNameIDService
    {
      get => this.manageNameIDServiceField;
      set => this.manageNameIDServiceField = value;
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
