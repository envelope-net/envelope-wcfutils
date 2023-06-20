namespace Envelope.WcfUtils.Saml2.Messages;

public enum Saml2MessageTypeEnum
{
	/// <summary>
	/// Auth. request
	/// </summary>
	AuthnRequest,

	/// <summary>
	/// Logout request
	/// </summary>
	LogoutRequest,

	/// <summary>
	/// Auth. response
	/// </summary>
	Response,

	/// <summary>
	/// Logout response
	/// </summary>
	LogoutResponse,
}
