using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace Envelope.WcfUtils;

internal class LoggingMessageInspector : IClientMessageInspector
{
	private readonly bool _logOnlyMessageBody;
	private readonly InspectedSOAPMessages _soapMessages;

	public LoggingMessageInspector(InspectedSOAPMessages soapMessages, bool logOnlyMessageBody)
	{
		_soapMessages = soapMessages ?? throw new ArgumentNullException(nameof(soapMessages));
		_logOnlyMessageBody = logOnlyMessageBody;
	}

	public object BeforeSendRequest(ref Message request, IClientChannel channel)
	{
		_soapMessages.Request = new SoapRequestDto { Payload = MessageToString(ref request) };

		try
		{
			_soapMessages.Request.Url = request.Headers?.To?.ToString();
		}
		catch
		{
		}

		var headers = new Headers();

		try
		{
			headers.MessageHeaders = request.Headers;
		}
		catch
		{
		}

		try
		{
			if (request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
			{
				var httpRequestProperty = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
				headers.WebHeaderCollection = httpRequestProperty.Headers;
			}
		}
		catch
		{
		}

		try
		{
			_soapMessages.Request.Headers = headers.ToJson();
		}
		catch
		{
		}

		_soapMessages.Request.CorrelationId = Guid.NewGuid();
		_soapMessages.Request.SendingUtc = DateTime.UtcNow;
		return _soapMessages.Request.CorrelationId;
	}

	public void AfterReceiveReply(ref Message reply, object correlationState)
	{
		_soapMessages.Response = new SoapResponseDto
		{
			ElapsedMilliseconds = _soapMessages.Request?.SendingUtc.HasValue == true
				? Convert.ToDecimal(DateTime.UtcNow.Subtract(_soapMessages.Request.SendingUtc.Value).TotalMilliseconds)
				: null,
			Payload = MessageToString(ref reply)
		};

		var headers = new Headers();

		try
		{
			headers.MessageHeaders = reply.Headers;
		}
		catch
		{
		}

		try
		{
			if (reply.Properties.ContainsKey(HttpResponseMessageProperty.Name))
			{
				var httpResponseProperty = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
				headers.WebHeaderCollection = httpResponseProperty.Headers;
			}
		}
		catch
		{
		}

		try
		{
			_soapMessages.Response.Headers = headers.ToJson();
		}
		catch
		{
		}

		try
		{
			if (reply.Properties.ContainsKey(HttpResponseMessageProperty.Name))
			{
				var httpResponseProperty = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
				_soapMessages.Response.StatusCode = (int)httpResponseProperty.StatusCode;
			}
		}
		catch
		{
		}

		if (reply.IsFault)
			_soapMessages.Response.Error = nameof(reply.IsFault);

		//if (correlationState is Guid responseCorrelationId)
		//	_soapMessages.Response.CorrelationId = responseCorrelationId;
	}

	private string? MessageToString(ref Message message)
	{
		if (message == null)
			return null;

		if (_logOnlyMessageBody)
		{
			var buffer = message.CreateBufferedCopy(int.MaxValue);
			message = buffer.CreateMessage();

			using var newMessage = buffer.CreateMessage();
			using XmlDictionaryReader reader = newMessage.GetReaderAtBodyContents();
			string content = reader.ReadOuterXml();
			buffer.Close();

			return content;
		}
		else
		{
			return message.ToString();
		}
	}
}
