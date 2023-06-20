// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.LogoutRequestType
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
  [XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
  [System.Xml.Serialization.XmlRoot("LogoutRequest", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
  [Serializable]
  public class LogoutRequestType : RequestAbstractType
  {
    private object itemField;
    private string[] sessionIndexField;
    private string reasonField;
    private DateTime notOnOrAfterField;
    private bool notOnOrAfterFieldSpecified;

    /// <remarks />
    [XmlElement("BaseID", typeof (BaseIDAbstractType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
    [XmlElement("EncryptedID", typeof (EncryptedElementType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
    [XmlElement("NameID", typeof (NameIDType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
    public object Item
    {
      get => this.itemField;
      set => this.itemField = value;
    }

    /// <remarks />
    [XmlElement("SessionIndex")]
    public string[] SessionIndex
    {
      get => this.sessionIndexField;
      set => this.sessionIndexField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string Reason
    {
      get => this.reasonField;
      set => this.reasonField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public DateTime NotOnOrAfter
    {
      get => this.notOnOrAfterField;
      set => this.notOnOrAfterField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool NotOnOrAfterSpecified
    {
      get => this.notOnOrAfterFieldSpecified;
      set => this.notOnOrAfterFieldSpecified = value;
    }
  }
}
