// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.SubjectConfirmationType
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
  [System.Xml.Serialization.XmlRoot("SubjectConfirmation", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
  [Serializable]
  public class SubjectConfirmationType
  {
    private object itemField;
    private SubjectConfirmationDataType subjectConfirmationDataField;
    private string methodField;

    /// <remarks />
    [XmlElement("BaseID", typeof (BaseIDAbstractType))]
    [XmlElement("EncryptedID", typeof (EncryptedElementType))]
    [XmlElement("NameID", typeof (NameIDType))]
    public object Item
    {
      get => this.itemField;
      set => this.itemField = value;
    }

    /// <remarks />
    public SubjectConfirmationDataType SubjectConfirmationData
    {
      get => this.subjectConfirmationDataField;
      set => this.subjectConfirmationDataField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string Method
    {
      get => this.methodField;
      set => this.methodField = value;
    }
  }
}
