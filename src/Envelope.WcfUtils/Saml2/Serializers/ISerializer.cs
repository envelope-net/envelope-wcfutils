namespace Envelope.WcfUtils.Saml2.Serializers;

public interface ISerializer
{
	/// <summary>
	/// Serializes the specified object.
	/// </summary>
	string Serialize(object obj);

	/// <summary>
	/// Deserializes the specified string.
	/// </summary>
	T? Deserialize<T>(string str);
}
