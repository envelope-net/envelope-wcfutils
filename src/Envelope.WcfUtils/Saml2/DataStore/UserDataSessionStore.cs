using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.DataStore;

internal class UserDataSessionStore : UserDataStore
{
	public const string USER_DATA_SESSION_STORE = "Saml2Handler.UserDataSessionStore";

	protected internal override void StoreCache(
		Dictionary<string, UserData> cache,
		ISaml2ModuleContext context)
	{
		string str = context.Config.Serializer.Serialize(cache);
		context.SessionSet(USER_DATA_SESSION_STORE, str);
	}

	protected internal override Dictionary<string, UserData> LoadCache(ISaml2ModuleContext context)
	{
		return (context.SessionGet(USER_DATA_SESSION_STORE) is not string json)
			? new Dictionary<string, UserData>()
			: (context.Config.Serializer.Deserialize<Dictionary<string, UserData>>(json) ?? throw new InvalidOperationException());
	}
}
