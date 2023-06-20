// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.ReferenceList
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
  [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2001/04/xmlenc#")]
  [System.Xml.Serialization.XmlRoot(Namespace = "http://www.w3.org/2001/04/xmlenc#", IsNullable = false)]
  [Serializable]
  public class ReferenceList
  {
    private ReferenceType1[] itemsField;
    private ItemsChoiceType3[] itemsElementNameField;

    /// <remarks />
    [XmlElement("DataReference", typeof (ReferenceType1))]
    [XmlElement("KeyReference", typeof (ReferenceType1))]
    [XmlChoiceIdentifier("ItemsElementName")]
    public ReferenceType1[] Items
    {
      get => this.itemsField;
      set => this.itemsField = value;
    }

    /// <remarks />
    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType3[] ItemsElementName
    {
      get => this.itemsElementNameField;
      set => this.itemsElementNameField = value;
    }
  }
}
