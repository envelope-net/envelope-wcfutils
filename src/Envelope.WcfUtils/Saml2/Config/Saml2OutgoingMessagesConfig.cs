namespace Envelope.WcfUtils.Saml2.Config;

public class Saml2OutgoingMessagesConfig
{
	public bool SignRequest { get; set; } = true;
	public bool SignResponse { get; set; } = true;
	public string? RequestedAuthnContext { get; set; }

	/// <summary>
	/// Gets or sets using ForceAuthn parameter for token renew
	/// </summary>
	public bool? RenewUseForceAuthn { get; set; }
}
