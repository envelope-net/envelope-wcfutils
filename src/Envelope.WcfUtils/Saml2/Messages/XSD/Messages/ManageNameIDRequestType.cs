// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.ManageNameIDRequestType
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
  [System.Xml.Serialization.XmlRoot("ManageNameIDRequest", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
  [Serializable]
  public class ManageNameIDRequestType : RequestAbstractType
  {
    private object itemField;
    private object item1Field;

    /// <remarks />
    [XmlElement("EncryptedID", typeof (EncryptedElementType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
    [XmlElement("NameID", typeof (NameIDType), Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
    public object Item
    {
      get => this.itemField;
      set => this.itemField = value;
    }

    /// <remarks />
    [XmlElement("NewEncryptedID", typeof (EncryptedElementType))]
    [XmlElement("NewID", typeof (string))]
    [XmlElement("Terminate", typeof (TerminateType))]
    public object Item1
    {
      get => this.item1Field;
      set => this.item1Field = value;
    }
  }
}
