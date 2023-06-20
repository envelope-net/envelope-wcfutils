// Decompiled with JetBrains decompiler
// Type: Envelope.WcfUtils.Saml2.Messages.SubjectConfirmationDataType
// Assembly: RBTeam.Saml2Lib, Version=4.7.2.1, Culture=neutral, PublicKeyToken=443400c129882e90
// MVID: 625824D1-DBAD-407F-86EE-CFDC4EF71CC8
// Assembly location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.dll
// XML documentation location: C:\Code\Disig\Saml2Module\bin\RBTeam.Saml2Lib.xml

using Envelope.WcfUtils.Saml2.Helpers;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Envelope.WcfUtils.Saml2.Messages
{
	/// <summary>
	/// 
	/// </summary>
	[XmlInclude(typeof(KeyInfoConfirmationDataType))]
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "urn:oasis:names:tc:SAML:2.0:assertion")]
	[System.Xml.Serialization.XmlRoot("SubjectConfirmationData", Namespace = "urn:oasis:names:tc:SAML:2.0:assertion", IsNullable = false)]
	[Serializable]
	public class SubjectConfirmationDataType
	{
		private DateTime notBeforeField;
		private bool notBeforeFieldSpecified;
		private DateTime notOnOrAfterField;
		private bool notOnOrAfterFieldSpecified;
		private string recipientField;
		private string[] textField;

		/// <summary>Gets or sets the not before.</summary>
		/// <value>The not before.</value>
		[XmlIgnore]
		public DateTime NotBefore
		{
			get => this.notBeforeField;
			set => this.notBeforeField = value;
		}

		/// <summary>The Custom Not Before</summary>
		/// <value>The custom not before.</value>
		/// <remarks>
		/// zvlast serizalizacia pre datumy, OIF vyzaduje v datumoch milisekundy
		/// </remarks>
		[XmlAttribute("NotBefore")]
		public string CustomNotBefore
		{
			get => MessageHelper.DateToString(notBeforeField);
			set => notBeforeField = MessageHelper.DateFromString(value);
		}

		/// <summary>
		/// Gets or sets a value indicating whether [not before specified].
		/// </summary>
		/// <value>
		///   <c>true</c> if [not before specified]; otherwise, <c>false</c>.
		/// </value>
		[XmlIgnore]
		public bool NotBeforeSpecified
		{
			get => this.notBeforeFieldSpecified;
			set => this.notBeforeFieldSpecified = value;
		}

		/// <summary>Gets or sets the not on or after.</summary>
		/// <value>The not on or after.</value>
		[XmlIgnore]
		public DateTime NotOnOrAfter
		{
			get => this.notOnOrAfterField;
			set => this.notOnOrAfterField = value;
		}

		/// <summary>Gets or sets the custom not on or after.</summary>
		/// <value>The custom not on or after.</value>
		[XmlAttribute("NotOnOrAfter")]
		public string CustomNotOnOrAfter
		{
			get => MessageHelper.DateToString(notOnOrAfterField);
			set => notOnOrAfterField = MessageHelper.DateFromString(value);
		}

		/// <summary>
		/// Gets or sets a value indicating whether [not on or after specified].
		/// </summary>
		/// <value>
		/// <c>true</c> if [not on or after specified]; otherwise, <c>false</c>.
		/// </value>
		[XmlIgnore]
		public bool NotOnOrAfterSpecified
		{
			get => this.notOnOrAfterFieldSpecified;
			set => this.notOnOrAfterFieldSpecified = value;
		}

		/// <summary>Gets or sets the recipient.</summary>
		/// <value>The recipient.</value>
		[XmlAttribute]
		public string Recipient
		{
			get => this.recipientField;
			set => this.recipientField = value;
		}

		/// <summary>Gets or sets the text.</summary>
		/// <value>The text.</value>
		[XmlText]
		public string[] Text
		{
			get => this.textField;
			set => this.textField = value;
		}
	}
}
