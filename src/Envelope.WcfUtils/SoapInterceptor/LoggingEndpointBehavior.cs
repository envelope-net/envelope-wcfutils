using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Envelope.WcfUtils;

public class LoggingEndpointBehavior : IEndpointBehavior
{
	private readonly bool _logOnlyMessageBody;
	private readonly InspectedSOAPMessages _soapMessages;

	public LoggingEndpointBehavior(InspectedSOAPMessages soapMessages, bool logOnlyMessageBody)
	{
		_soapMessages = soapMessages ?? throw new ArgumentNullException(nameof(soapMessages));
		_logOnlyMessageBody = logOnlyMessageBody;
	}

	public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
	{
	}

	public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
	{
		clientRuntime.ClientMessageInspectors.Add(new LoggingMessageInspector(_soapMessages, _logOnlyMessageBody));
	}

	public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
	{
	}

	public void Validate(ServiceEndpoint endpoint)
	{
	}
}
