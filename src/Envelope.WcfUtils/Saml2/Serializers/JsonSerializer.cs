namespace Envelope.WcfUtils.Saml2.Serializers;

internal class JsonSerializer : ISerializer
{
	public string Serialize(object obj)
#if NETSTANDARD2_0 || NETSTANDARD2_1
		=> Newtonsoft.Json.JsonConvert.SerializeObject(obj);
#elif NET6_0_OR_GREATER
		=> System.Text.Json.JsonSerializer.Serialize(obj);
#endif

	public T? Deserialize<T>(string json)
#if NETSTANDARD2_0 || NETSTANDARD2_1
		=> Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
#elif NET6_0_OR_GREATER
		=> System.Text.Json.JsonSerializer.Deserialize<T>(json);
#endif
}
