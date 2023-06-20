// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.StatusType
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
  [System.Xml.Serialization.XmlRoot("Status", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
  [Serializable]
  public class StatusType
  {
    private StatusCodeType statusCodeField;
    private string statusMessageField;
    private StatusDetailType statusDetailField;

    /// <remarks />
    public StatusCodeType StatusCode
    {
      get => this.statusCodeField;
      set => this.statusCodeField = value;
    }

    /// <remarks />
    public string StatusMessage
    {
      get => this.statusMessageField;
      set => this.statusMessageField = value;
    }

    /// <remarks />
    public StatusDetailType StatusDetail
    {
      get => this.statusDetailField;
      set => this.statusDetailField = value;
    }
  }
}
