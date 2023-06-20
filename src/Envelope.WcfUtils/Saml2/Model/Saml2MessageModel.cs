using Envelope.WcfUtils.Saml2.Config;
using Envelope.WcfUtils.Saml2.Messages;

namespace Envelope.WcfUtils.Saml2.Model;

/// <summary>Vseobecny model pre saml request/response</summary>
[Serializable]
public class Saml2MessageModel
{
	internal ISaml2ModuleContext Context { get; set; }
	/// <summary>Podpsi spravy</summary>
	internal byte[] UrlSignature;

	/// <summary>Konfiguracia</summary>
	internal ISaml2Config Config { get; set; }

	/// <summary>Pomocne infnormacie</summary>
	internal Saml2MessageInfo Info { get; set; }

	/// <summary>Odosielatel spravy</summary>
	internal EntityDescriptorType Sender { get; set; }

	/// <summary>Prijimatel spravy</summary>
	internal EntityDescriptorType Receiver { get; set; }

	/// <summary>Sprava pre adresata</summary>
	public ISaml2Message Message { get; internal set; }

	/// <summary>Surova sprava</summary>
	internal string MessageRaw { get; set; }
	public string IAMSignInUrl { get; internal  set; }
}
