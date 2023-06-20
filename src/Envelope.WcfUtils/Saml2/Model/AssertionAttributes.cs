using System.Text.RegularExpressions;
using Envelope.WcfUtils.Saml2.Config;
using Envelope.WcfUtils.Saml2.Messages;

namespace Envelope.WcfUtils.Saml2.Model;

[Serializable]
internal class AssertionAttributes
{
	private Dictionary<string, List<string>> _attributeDict;

	internal AssertionAttributes(IEnumerable<StatementAbstractType> items)
	{
		_attributeDict = new();
		LoadAttributes(items);
	}

	private void LoadAttributes(IEnumerable<StatementAbstractType> items)
	{
		var attributeStatementType = items != null
			? (items.FirstOrDefault(item => item is AttributeStatementType) as AttributeStatementType)
			: null;

		if (attributeStatementType?.Items == null)
			return;

		foreach (var obj in attributeStatementType.Items)
		{
			if (obj is AttributeType attributeType)
			{
				var stringList = new List<string>();

				if (attributeType.AttributeValue != null)
					stringList.AddRange(attributeType.AttributeValue.OfType<string>());

				if (0 < stringList.Count)
					_attributeDict.Add(attributeType.Name, stringList);
			}
		}
	}

	internal void MapAttributeValues(AssertionAttributeConfig attrConfig)
	{
		if (attrConfig?.RolesAttribute == null || attrConfig?.RoleMappingRecords == null)
			return;

		var dictionary = new Dictionary<string, List<string>>();

		foreach (var key in _attributeDict.Keys)
		{
			var loadedAttributes = _attributeDict[key];
			var newList = new List<string>();

			if (key == attrConfig.RolesAttribute)
			{
				foreach (var loadedAttribute in loadedAttributes)
				{
					foreach (var roleMappingRecord in attrConfig.RoleMappingRecords)
					{
						if (string.IsNullOrEmpty(roleMappingRecord.Regex))
						{
							newList.Add(loadedAttribute);
						}
						else
						{
							var match = new Regex(roleMappingRecord.Regex.Replace("{role}", "<role>").ToLower()).Match(loadedAttribute.ToLower());
							if (match.Success)
							{
								string role = match.Groups["role"].Value;

								if (!string.IsNullOrEmpty(roleMappingRecord.Prefix))
									role = $"{roleMappingRecord.Prefix.Trim()}.{role}";

								newList.Add(role.ToUpper());
							}
							else
								newList.Add(loadedAttribute);
						}
					}
				}
			}
			else
			{
				newList = loadedAttributes;
			}

			dictionary[key] = newList;
		}

		_attributeDict = dictionary;
	}

	internal IEnumerable<string> GetAttributeNames()
		=> _attributeDict.Keys.ToList();

	internal string? GetValue(string name)
		=> !_attributeDict.ContainsKey(name)
			? null
			: _attributeDict[name][0];

	internal List<string> GetMultiValue(string name)
		=> !_attributeDict.ContainsKey(name)
			? new List<string>()
			: _attributeDict[name];
}
