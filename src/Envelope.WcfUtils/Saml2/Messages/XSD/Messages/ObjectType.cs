// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.ObjectType
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
  [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
  [System.Xml.Serialization.XmlRoot("Object", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
  [Serializable]
  public class ObjectType
  {
    private XmlNode[] anyField;
    private string idField;
    private string mimeTypeField;
    private string encodingField;

    /// <remarks />
    [XmlText]
    [XmlAnyElement]
    public XmlNode[] Any
    {
      get => this.anyField;
      set => this.anyField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string Id
    {
      get => this.idField;
      set => this.idField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string MimeType
    {
      get => this.mimeTypeField;
      set => this.mimeTypeField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string Encoding
    {
      get => this.encodingField;
      set => this.encodingField = value;
    }
  }
}
