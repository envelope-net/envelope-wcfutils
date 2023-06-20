using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.Pipelines;
internal abstract class MessageProcessingService
{
	internal abstract void ValidateModel(Saml2MessageModel model);

	internal abstract void Process(Saml2MessageModel model);

	internal event Action<ISaml2Message> BeforeProcess;

	internal event Action<ISaml2Message> AfterProcessed;

	internal void FireAfterProcessed(ISaml2Message message)
	{
		var afterProcessed = AfterProcessed;
		if (afterProcessed == null)
			return;

		afterProcessed(message);
	}

	internal void FireBeforeProcess(ISaml2Message message)
	{
		var beforeProcess = BeforeProcess;
		if (beforeProcess == null)
			return;

		beforeProcess(message);
	}
}
