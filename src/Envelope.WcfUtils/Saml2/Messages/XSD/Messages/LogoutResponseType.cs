// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.LogoutResponseType
// Assembly: RBTeam.Saml2Lib, Version=4.7.2.1, Culture=neutral, PublicKeyToken=443400c129882e90
// MVID: 625824D1-DBAD-407F-86EE-CFDC4EF71CC8
// Assembly location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.dll
// XML documentation location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.xml

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Envelope.WcfUtils.Saml2.Messages
{
  /// <summary>
  /// element LogoutResponse sa nevygeneroval cez xsd.exe(ale jeho complexType StatusResponse tam je), takze rucne strucne:
  /// </summary>
  /// <seealso cref="T:Envelope.WcfUtils.Saml2.Messages.StatusResponseType" />
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:protocol")]
  [System.Xml.Serialization.XmlRoot("LogoutResponse", Namespace = "urn:oasis:names:tc:SAML:2.0:protocol", IsNullable = false)]
  [Serializable]
  public class LogoutResponseType : StatusResponseType
  {
  }
}
