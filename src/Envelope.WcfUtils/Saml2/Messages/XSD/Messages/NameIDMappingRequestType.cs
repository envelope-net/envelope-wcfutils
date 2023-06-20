// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.NameIDMappingRequestType
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
  [System.Xml.Serialization.XmlRoot("NameIDMappingRequest", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
  [Serializable]
  public class NameIDMappingRequestType : RequestAbstractType
  {
    private object itemField;
    private NameIDPolicyType nameIDPolicyField;

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
    public NameIDPolicyType NameIDPolicy
    {
      get => this.nameIDPolicyField;
      set => this.nameIDPolicyField = value;
    }
  }
}
