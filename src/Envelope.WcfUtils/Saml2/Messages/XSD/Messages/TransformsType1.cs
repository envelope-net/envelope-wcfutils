// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.TransformsType1
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
  [XmlType(TypeName = "TransformsType", Namespace = "http://www.w3.org/2001/04/xmlenc#")]
  [Serializable]
  public class TransformsType1
  {
    private TransformType[] transformField;

    /// <remarks />
    [XmlElement("Transform", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public TransformType[] Transform
    {
      get => this.transformField;
      set => this.transformField = value;
    }
  }
}
