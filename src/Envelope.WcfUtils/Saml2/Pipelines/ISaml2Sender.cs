using Envelope.Trace;
using Envelope.WcfUtils.Saml2.Messages;
using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.Pipelines;

public interface ISaml2Sender
{
	Saml2MessageModel SendMessage(
		ITraceInfo traceInfo,
		Saml2MessageTypeEnum messageType,
		string binding,
		ISaml2ModuleContext context);

	/// <summary>
	/// Occurs when [message created].
	/// </summary>
	event Action<ISaml2Message> MessageCreated;

	/// <summary>
	/// Occurs when [before response write].
	/// </summary>
	event Action<ISaml2Message> BeforeResponseWrite;
}
