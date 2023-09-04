using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Envelope.WcfUtils;

public class LoggingEndpointBehavior : IEndpointBehavior
{
	private readonly InspectedSOAPMessages _soapMessages;

	public LoggingEndpointBehavior(InspectedSOAPMessages soapMessages)
	{
		_soapMessages = soapMessages ?? throw new ArgumentNullException(nameof(soapMessages));
	}

	public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
	{
	}

	public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
	{
		clientRuntime.ClientMessageInspectors.Add(new LoggingMessageInspector(_soapMessages));
	}

	public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
	{
	}

	public void Validate(ServiceEndpoint endpoint)
	{
	}
}
