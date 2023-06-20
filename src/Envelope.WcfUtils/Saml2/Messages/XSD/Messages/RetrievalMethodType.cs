// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.RetrievalMethodType
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
  [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
  [System.Xml.Serialization.XmlRoot("RetrievalMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
  [Serializable]
  public class RetrievalMethodType
  {
    private TransformType[] transformsField;
    private string uRIField;
    private string typeField;

    /// <remarks />
    [XmlArrayItem("Transform", IsNullable = false)]
    public TransformType[] Transforms
    {
      get => this.transformsField;
      set => this.transformsField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string URI
    {
      get => this.uRIField;
      set => this.uRIField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string Type
    {
      get => this.typeField;
      set => this.typeField = value;
    }
  }
}
