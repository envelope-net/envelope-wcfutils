using Envelope.Logging.Extensions;
using Envelope.Trace;
using Microsoft.Extensions.Logging;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.Pipelines;

internal class ReceivePipeline : Pipeline, ISaml2Receiver
{
	internal ReceivePipeline(ILogger log)
		: base(log)
	{
		AddService(new ReceiveReader());
		AddService(new ReceiveDeserializer());
		AddService(new ReceiveSignature());
		AddService(new ReceiveValidator());
	}

	public ISaml2Message ReadMessage(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context)
	{
		traceInfo = TraceInfo.Create(traceInfo);

		var model = new Saml2MessageModel()
		{
			Context = context,
			Sender = context.Config.IdpMetadata,
			Receiver = context.Config.SpMetadata,
			Config = context.Config
		};

		Process(model);

		Logger.LogTraceMessage(traceInfo, x => x.Detail(model.MessageRaw));
		return model.Message;
	}
}
