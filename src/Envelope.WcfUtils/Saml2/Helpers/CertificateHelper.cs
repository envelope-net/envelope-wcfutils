using System.Security.Cryptography.X509Certificates;
using Envelope.WcfUtils.Saml2.Config;
using Envelope.WcfUtils.Saml2.Messages;

namespace Envelope.WcfUtils.Saml2.Helpers;

/// <summary>
/// Dodava objekty certifikatov, bud z metadat alebo z cert storu
/// </summary>
internal static class CertificateHelper
{
	internal static X509Certificate2 GetMetadataCertificate(
		ISaml2Config config,
		EntityDescriptorType entity,
		KeyTypes keyType,
		bool privateKey)
	{
		X509Certificate2 x509Certificate2;
		try
		{
			x509Certificate2 = new X509Certificate2(GetMetadataCertificateBytes(entity, KeyTypes.signing));
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException($"Unable to parse {keyType} certificate from metatada {entity.entityID}", ex);
		}

		return privateKey
			? FindCert(
				config.CertificateStore.CertificateFileFullPath,
				config.CertificateStore.CertificatePassword,
				config.CertificateStore.StoreLocationEnum,
				config.CertificateStore.StoreNameEnum,
				config.CertificateStore.FindTypeEnum,
				x509Certificate2.GetCertHashString())
			: x509Certificate2;
	}

	internal static byte[]? GetMetadataCertificateBytes(
		EntityDescriptorType entity,
		KeyTypes keyType)
	{
		try
		{
			return (((RoleDescriptorType)entity.Items[0]).KeyDescriptor.First(keyDesc => keyDesc.useSpecified && keyDesc.use == keyType).KeyInfo.Items[0] is X509DataType x509DataType
				? x509DataType.Items[0]
				: null)
			as byte[];
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException($"Cannot read {keyType} certificate content from metadata {entity.entityID}", ex);
		}
	}

	private static X509Certificate2 FindCert(
		string? certificateFileFullPath,
		string? certificatePassword,
		StoreLocation location,
		StoreName storeName,
		X509FindType findType,
		string findValue)
	{
		if (!string.IsNullOrWhiteSpace(certificateFileFullPath)
			&& !string.IsNullOrWhiteSpace(certificatePassword))
		{
			if (string.IsNullOrWhiteSpace(certificatePassword))
			{
				var cert = new X509Certificate2(certificateFileFullPath);
				return cert;
			}
			else
			{
				var cert = new X509Certificate2(certificateFileFullPath, certificatePassword);
				return cert;
			}
		}
		else
		{
			var x509Store = new X509Store(storeName, location);
			x509Store.Open(OpenFlags.ReadOnly);
			var certificate2Collection = x509Store.Certificates.Find(findType, (object)findValue, false);
			x509Store.Close();

			if (certificate2Collection.Count == 0)
				throw new InvalidOperationException($"Certificate '{findValue}' not found in store: {location}, {storeName}, {findType}");

			return certificate2Collection.Count <= 1
				? certificate2Collection[0]
				: throw new InvalidOperationException($"Multiple certificates matching '{findValue}' were found in store: {location}, {storeName}, {findType}");
		}
	}

	internal static bool ValidateCertificate(X509Certificate2 cert)
	{
		try
		{
			return new X509Chain(true)
			{
				ChainPolicy = {
					RevocationMode = X509RevocationMode.NoCheck,
					RevocationFlag = X509RevocationFlag.EndCertificateOnly
				}
			}.Build(cert);
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException($"Certificate validation error for cert: subject {cert.Subject}, thumb {cert.GetCertHashString()}", ex);
		}
	}
}
