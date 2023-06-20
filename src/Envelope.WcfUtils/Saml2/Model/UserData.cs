namespace Envelope.WcfUtils.Saml2.Model;

[Serializable]
public class UserData
{
	public DateTime CreationTime { get; set; }
	public bool Expires { get; set; }
	public string Data { get; set; }
	public Dictionary<string, UserData> Dict { get; set; }

	public UserData()
	{
	}

	internal UserData(Dictionary<string, UserData> dictionary)
	{
		Expires = false;
		Dict = dictionary;
	}

	internal UserData(string value)
	{
		Expires = false;
		Data = value;
	}

	internal UserData(Dictionary<string, UserData> value, DateTime creationTime)
		: this(value)
	{
		CreationTime = creationTime;
		Expires = true;
	}

	internal UserData(string value, DateTime creationTime)
		: this(value)
	{
		CreationTime = creationTime;
		Expires = true;
	}
}
