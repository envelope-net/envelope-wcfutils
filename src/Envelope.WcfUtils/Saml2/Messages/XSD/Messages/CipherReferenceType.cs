﻿// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.CipherReferenceType
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
  [XmlType(Namespace = "http://www.w3.org/2001/04/xmlenc#")]
  [System.Xml.Serialization.XmlRoot("CipherReference", Namespace = "http://www.w3.org/2001/04/xmlenc#", IsNullable = false)]
  [Serializable]
  public class CipherReferenceType
  {
    private TransformsType1 itemField;
    private string uRIField;

    /// <remarks />
    [XmlElement("Transforms")]
    public TransformsType1 Item
    {
      get => this.itemField;
      set => this.itemField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string URI
    {
      get => this.uRIField;
      set => this.uRIField = value;
    }
  }
}
