using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.Pipelines;

/// <summary>Serializuje objekt spravy do xml</summary>
internal class SendSerializer : MessageProcessingService
{
	internal override void ValidateModel(Saml2MessageModel model)
	{
		if (model == null)
			throw new ArgumentNullException(nameof(model));

		if (model.Info == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Info)}");

		if (model.Message == null)
			throw new InvalidOperationException($"{nameof(model)}.{nameof(model.Message)}");
	}

	internal override void Process(Saml2MessageModel model)
	{
		switch (model.Info.MessageType)
		{
			case Saml2MessageTypeEnum.AuthnRequest:
				model.MessageRaw = Envelope.Serializer.XmlSerializerHelper.SerializeToString<AuthnRequestType>(model.Message, omitXmlDeclaration: true);
				break;
			case Saml2MessageTypeEnum.LogoutRequest:
				model.MessageRaw = Envelope.Serializer.XmlSerializerHelper.SerializeToString<LogoutRequestType>(model.Message, omitXmlDeclaration: true);
				break;
			case Saml2MessageTypeEnum.Response:
				model.MessageRaw = Envelope.Serializer.XmlSerializerHelper.SerializeToString<ResponseType>(model.Message, omitXmlDeclaration: true);
				break;
			case Saml2MessageTypeEnum.LogoutResponse:
				model.MessageRaw = Envelope.Serializer.XmlSerializerHelper.SerializeToString<LogoutResponseType>(model.Message, omitXmlDeclaration: true);
				break;
			default:
				throw new InvalidOperationException($"Message type not supported: {model.Info.MessageType}");
		}
	}
}
