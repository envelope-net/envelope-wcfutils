namespace Envelope.WcfUtils;

public class InspectedSOAPMessages
{
	public SoapRequestDto? Request { get; set; }
	public SoapResponseDto? Response { get; set; }
}

public class Headers
{
	public System.Net.WebHeaderCollection? WebHeaderCollection { get; set; }
	public System.ServiceModel.Channels.MessageHeaders? MessageHeaders { get; set; }

	public string? ToJson()
	{
		var result = new List<KeyValuePair<string, List<string>>>();

		if (0 < WebHeaderCollection?.Count)
			foreach (string key in WebHeaderCollection.Keys)
				result.Add(new KeyValuePair<string, List<string>>(key, new List<string> { WebHeaderCollection[key]! }));

		if (0 < MessageHeaders?.Count)
		{
			foreach (var messageHeader in MessageHeaders)
			{
				result.Add(new KeyValuePair<string, List<string>>(nameof(messageHeader.Actor), new List<string> { messageHeader.Actor }));
				result.Add(new KeyValuePair<string, List<string>>(nameof(messageHeader.IsReferenceParameter), new List<string> { messageHeader.IsReferenceParameter.ToString() }));
				result.Add(new KeyValuePair<string, List<string>>(nameof(messageHeader.Name), new List<string> { messageHeader.Name }));
				result.Add(new KeyValuePair<string, List<string>>(nameof(messageHeader.Namespace), new List<string> { messageHeader.Namespace }));
				result.Add(new KeyValuePair<string, List<string>>(nameof(messageHeader.MustUnderstand), new List<string> { messageHeader.MustUnderstand.ToString() }));
				result.Add(new KeyValuePair<string, List<string>>(nameof(messageHeader.Relay), new List<string> { messageHeader.Relay.ToString() }));
			}
		}

#if NETSTANDARD2_0 || NETSTANDARD2_1
		return Newtonsoft.Json.JsonConvert.SerializeObject(result);
#elif NET6_0_OR_GREATER
		return System.Text.Json.JsonSerializer.Serialize(result);
#endif
	}
}
