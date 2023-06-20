// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.NameIDType
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
  [XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
  [System.Xml.Serialization.XmlRoot("NameID", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
  [Serializable]
  public class NameIDType
  {
    private string nameQualifierField;
    private string sPNameQualifierField;
    private string formatField;
    private string sPProvidedIDField;
    private string valueField;

    /// <remarks />
    [XmlAttribute]
    public string NameQualifier
    {
      get => this.nameQualifierField;
      set => this.nameQualifierField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string SPNameQualifier
    {
      get => this.sPNameQualifierField;
      set => this.sPNameQualifierField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string Format
    {
      get => this.formatField;
      set => this.formatField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string SPProvidedID
    {
      get => this.sPProvidedIDField;
      set => this.sPProvidedIDField = value;
    }

    /// <remarks />
    [XmlText]
    public string Value
    {
      get => this.valueField;
      set => this.valueField = value;
    }
  }
}
