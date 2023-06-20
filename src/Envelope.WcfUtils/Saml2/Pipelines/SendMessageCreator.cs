using Envelope;
using Envelope.WcfUtils.Saml2.Helpers;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.Pipelines;

/// <summary>
/// Vytvori novy objekt saml spravy, a nastavy zakladne fieldy
/// V model.Info sa ulozi typ vytvorenej spravy, a typ sluzby
/// </summary>
internal class SendMessageCreator : MessageProcessingService
{
	internal override void ValidateModel(Saml2MessageModel model)
	{
		if (model == null)
			throw new ArgumentNullException(nameof(model));

		if (model.Info == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Info)}");

		if (string.IsNullOrWhiteSpace(model.Info.Binding))
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Info)}.{nameof(model.Info.Binding)}");

		if (model.Sender == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Sender)}");

		if (model.Receiver == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Receiver)}");
	}

	internal override void Process(Saml2MessageModel model)
	{
		switch (model.Info.MessageType)
		{
			case Saml2MessageTypeEnum.AuthnRequest:
				model.Message = new AuthnRequestType();
				model.Info.ServiceType = Saml2ServiceTypeEnum.SingleSignOnService;
				if (!string.IsNullOrEmpty(model.Config.OutgoingMessages?.RequestedAuthnContext))
				{
					var authnContextType = new RequestedAuthnContextType()
					{
						Comparison = AuthnContextComparisonType.minimum,
						ComparisonSpecified = true,
						ItemsElementName = new AuthnContextRefType[1],
						Items = new string[1] { model.Config.OutgoingMessages.RequestedAuthnContext }
					};

					((AuthnRequestType)model.Message).RequestedAuthnContext = authnContextType;
					break;
				}
				break;
			case Saml2MessageTypeEnum.LogoutRequest:
				model.Message = new LogoutRequestType();
				model.Info.ServiceType = Saml2ServiceTypeEnum.SingleLogoutService;
				break;
			case Saml2MessageTypeEnum.Response:
				model.Message = new ResponseType();
				model.Info.ServiceType = Saml2ServiceTypeEnum.AssertionConsumerService;
				model.Info.IsResponse = true;
				break;
			case Saml2MessageTypeEnum.LogoutResponse:
				model.Message = new LogoutResponseType();
				model.Info.ServiceType = Saml2ServiceTypeEnum.SingleLogoutService;
				model.Info.IsResponse = true;
				break;
			default:
				throw new InvalidOperationException($"Unsupported message type: {model.Info.MessageType}");
		}
		model.Message.ID = "_" + GlobalContext.Instance.NewGuid();
		model.Message.IssueInstant = GlobalContext.Instance.Now;
		model.Message.Issuer = new NameIDType()
		{
			Value = model.Sender.entityID
		};

		model.Message.Destination = MetadataHelper.GetReceiverDestinationByServiceType(model.Receiver, model.Info.ServiceType, model.Info.Binding, model.Info.IsResponse);
	}
}