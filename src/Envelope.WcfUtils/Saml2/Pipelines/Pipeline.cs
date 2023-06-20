using Envelope.Exceptions;
using Microsoft.Extensions.Logging;
using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.Pipelines;

internal class Pipeline
{
	protected ILogger Logger { get; }
	protected List<MessageProcessingService> ServicesStack { get; }

	internal Pipeline(ILogger logger)
	{
		ServicesStack = new List<MessageProcessingService>();
		Logger = logger ?? throw new ArgumentNullException(nameof(logger));
	}

	internal Saml2MessageModel Process(Saml2MessageModel model)
	{
		Throw.IfNull(model.Config);
		Throw.IfNull(model.Context);

		model.Config.Validate();
		model.Config.Initialize();
		model.Config.ValidateInitialization();

		foreach (var processingService in ServicesStack)
		{
			processingService.ValidateModel(model);
			processingService.FireBeforeProcess(model.Message);
			processingService.Process(model);
			processingService.FireAfterProcessed(model.Message);
		}
		return model;
	}

	protected void AddService(MessageProcessingService service)
		=> ServicesStack.Add(service);
}
