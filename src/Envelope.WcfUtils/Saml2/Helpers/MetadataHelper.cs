using Envelope.WcfUtils.Saml2.Messages;

namespace Envelope.WcfUtils.Saml2.Helpers;

/// <summary>Hlada url v metadatach, podla typu pozadovanej sluzby</summary>
internal static class MetadataHelper
{
	internal static string GetReceiverDestinationByServiceType(
		EntityDescriptorType receiver,
		Saml2ServiceTypeEnum serviceType,
		string binding,
		bool isResponse)
	{
		var endpointsByServiceType = GetReceiverEndpointsByServiceType(receiver, serviceType)
			?? throw new InvalidOperationException($"check {receiver.entityID} metadata:{Environment.NewLine}service {serviceType} is not supported with binding {binding}");

		var destinationsByBinding = GetEndpointDestinationsByBinding(endpointsByServiceType, binding, isResponse);

		if (destinationsByBinding.Count == 0)
			throw new InvalidOperationException($"check {receiver.entityID} metadata:{Environment.NewLine}service {serviceType} is not supported with binding {binding}");

		return destinationsByBinding[0];
	}

	internal static EndpointType[]? GetReceiverEndpointsByServiceType(
		EntityDescriptorType receiver,
		Saml2ServiceTypeEnum serviceType)
	{
		var idpEntity = receiver.Entity as IDPSSODescriptorType;
		var spEntity = receiver.Entity as SPSSODescriptorType;
		var entity = receiver.Entity;

		return serviceType switch
		{
			Saml2ServiceTypeEnum.SingleSignOnService => idpEntity?.SingleSignOnService,
			Saml2ServiceTypeEnum.SingleLogoutService => entity?.SingleLogoutService,
			Saml2ServiceTypeEnum.AssertionConsumerService => spEntity?.AssertionConsumerService,
			_ => throw new InvalidOperationException($"saml2 service type not supported: {serviceType}"),
		};
	}

	internal static IList<string> GetEndpointDestinationsByBinding(
		EndpointType[] endpoints,
		string binding,
		bool isResponse)
	{
		var destinationsByBinding = new List<string>();
		if (endpoints != null && endpoints.Length != 0)
			destinationsByBinding.AddRange(
				endpoints
					.Where(endpoint => endpoint.Binding == binding)
					.Select(endpoint => !isResponse || string.IsNullOrEmpty(endpoint.ResponseLocation)
						? endpoint.Location
						: endpoint.ResponseLocation));
		
		return destinationsByBinding;
	}
}
