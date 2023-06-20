using Envelope.WcfUtils.Saml2.Model;

namespace Envelope.WcfUtils.Saml2.DataStore;

internal abstract class UserDataStore
{
	public const string REQUESTED_URL = "RequestedUrl";
	public const string AUTH_RETRIED = "AuthRetried";
	public const string PRINCIPAL_SESSION_INFO = "PrincipalSessionInfo";
	public const string SESSION_INDEX = "SessionIndex";
	public const string AUTHENTICATION_CONTROLLER_SESSION_INDEX = "AuthenticationControllerSessionIndex";

	private Dictionary<string, UserData> _cache;

	public UserDataStore()
	{
		_cache = new();
	}

	internal void Set(ISaml2ModuleContext context, string key, string? value)
	{
		var cfg = context;
		var cache = _cache;
		var keys = new List<string>
		{
			key
		};

		var obj = value;
		SetInternal(cfg, cache, keys, obj, false);
	}

	internal void Set(ISaml2ModuleContext context, string sessionIndex, string key, string value)
	{
		var cfg = context;
		var cache = _cache;
		var keys = new List<string>
		{
			sessionIndex,
			key
		};

		var obj = value;
		SetInternal(cfg, cache, keys, obj, false);
	}

	internal void SetExpirable(ISaml2ModuleContext context, string key, string value)
	{
		var cfg = context;
		var cache = _cache;

		var keys = new List<string>
		{
			key
		};

		var obj = value;
		SetInternal(cfg, cache, keys, obj, true);
	}

	internal void SetExpirable(ISaml2ModuleContext context, string sessionIndex, string key, string value)
	{
		var cfg = context;
		var cache = _cache;

		var keys = new List<string>
		{
			sessionIndex,
			key
		};

		var obj = value;
		SetInternal(cfg, cache, keys, obj, true);
	}

	internal T? Get<T>(ISaml2ModuleContext context, string key)
		where T : class
	{
		RemoveOldData(context, _cache);
		return GetInternal(_cache, new List<string>() { key })?.Data as T;
	}

	internal T? Get<T>(ISaml2ModuleContext context, string sessionIndex, string key)
		where T : class
	{
		RemoveOldData(context, _cache);
		return GetInternal(_cache, new List<string>() { sessionIndex, key })?.Data as T;
	}

	internal void Clear(string key)
	{
		if (key == null)
			return;

		SetInternal(null, _cache, new List<string>() { key }, null, false);
	}

	internal void Clear(string sessionIndex, string key)
		=> SetInternal(null, _cache, new List<string>()
		{
			sessionIndex,
			key
		}, null, false);

	private void SetInternal(
		ISaml2ModuleContext? context,
		IDictionary<string, UserData> cache,
		IList<string> keys,
		string? value,
		bool expires)
	{
		if (keys.Count > 1)
		{
			if (cache.ContainsKey(keys[0]))
			{
				var key = keys[0];
				var dict = cache[key].Dict;
				keys.RemoveAt(0);
				SetInternal(context, dict, keys, value, expires);
				if (dict.Count != 0)
					return;
				cache.Remove(key);
			}
			else
			{
				var newCache = new Dictionary<string, UserData>();
				cache[keys[0]] = new UserData(newCache);
				keys.RemoveAt(0);
				SetInternal(context, newCache, keys, value, expires);
			}
		}
		else if (value != null)
		{
			UserData userData;

			if (cache.ContainsKey(keys[0]))
			{
				userData = cache[keys[0]];
			}
			else
			{
				userData = new UserData();
				cache[keys[0]] = userData;
			}

			userData.Data = value;
			userData.Expires = expires;
			userData.CreationTime = GlobalContext.Instance.Now;
		}
		else
		{
			if (!cache.ContainsKey(keys[0]))
				return;

			cache.Remove(keys[0]);
		}
	}

	private UserData? GetInternal(IDictionary<string, UserData> cache, IList<string> keys)
	{
		if (keys.Count <= 1)
			return !cache.ContainsKey(keys[0])
				? null
				: cache[keys[0]];

		if (!cache.ContainsKey(keys[0]))
			return null;

		var key = keys[0];
		var dict = cache[key].Dict;
		keys.RemoveAt(0);

		return GetInternal(dict, keys);
	}

	private void RemoveOldData(ISaml2ModuleContext context, Dictionary<string, UserData> cache)
	{
		foreach (var key in cache.Keys.Where<string>(key => cache[key].Dict != null))
			RemoveOldData(context, cache[key].Dict);

		var stringList = new List<string>();

		foreach (var key in cache.Keys)
		{
			UserData userData = cache[key];

			if (userData.Expires && GlobalContext.Instance.Now.ToUniversalTime() > userData.CreationTime + TimeSpan.FromSeconds(context.Config.DataCache?.SamlRequestLifespanSeconds ?? 1200))
				stringList.Add(key);
			else if (cache[key].Dict != null && cache[key].Dict.Count == 0)
				stringList.Add(key);
		}

		foreach (var key in stringList)
			cache.Remove(key);
	}

	internal void Store(ISaml2ModuleContext context)
		=> StoreCache(_cache, context);

	internal void Load(ISaml2ModuleContext context)
		=> _cache = LoadCache(context);

	protected internal abstract void StoreCache(
		Dictionary<string, UserData> cache,
		ISaml2ModuleContext context);

	protected internal abstract Dictionary<string, UserData> LoadCache(ISaml2ModuleContext context);
}
