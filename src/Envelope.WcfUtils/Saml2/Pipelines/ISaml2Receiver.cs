using Envelope.Trace;
using Envelope.WcfUtils.Saml2.Messages;

namespace Envelope.WcfUtils.Saml2.Pipelines;

public interface ISaml2Receiver
{
	ISaml2Message ReadMessage(
		ITraceInfo traceInfo,
		ISaml2ModuleContext context);
}
