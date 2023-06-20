// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.EndpointType
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
  [XmlInclude(typeof (IndexedEndpointType))]
  [GeneratedCode("xsd", "4.0.30319.1")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:metadata")]
  [System.Xml.Serialization.XmlRoot("SingleLogoutService", Namespace = "urn:oasis:names:tc:SAML:2.0:metadata", IsNullable = false)]
  [Serializable]
  public class EndpointType
  {
    private XmlElement[] anyField;
    private string bindingField;
    private string locationField;
    private string responseLocationField;
    private XmlAttribute[] anyAttrField;

    /// <remarks />
    [XmlAnyElement]
    public XmlElement[] Any
    {
      get => this.anyField;
      set => this.anyField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string Binding
    {
      get => this.bindingField;
      set => this.bindingField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string Location
    {
      get => this.locationField;
      set => this.locationField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string ResponseLocation
    {
      get => this.responseLocationField;
      set => this.responseLocationField = value;
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
