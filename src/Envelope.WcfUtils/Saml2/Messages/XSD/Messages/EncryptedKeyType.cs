﻿// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.EncryptedKeyType
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
  [System.Xml.Serialization.XmlRoot("EncryptedKey", Namespace = "http://www.w3.org/2001/04/xmlenc#", IsNullable = false)]
  [Serializable]
  public class EncryptedKeyType : EncryptedType
  {
    private ReferenceList referenceListField;
    private string carriedKeyNameField;
    private string recipientField;

    /// <remarks />
    public ReferenceList ReferenceList
    {
      get => this.referenceListField;
      set => this.referenceListField = value;
    }

    /// <remarks />
    public string CarriedKeyName
    {
      get => this.carriedKeyNameField;
      set => this.carriedKeyNameField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string Recipient
    {
      get => this.recipientField;
      set => this.recipientField = value;
    }
  }
}
