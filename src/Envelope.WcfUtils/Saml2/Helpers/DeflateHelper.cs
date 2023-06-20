using System.IO.Compression;
using System.Text;

namespace Envelope.WcfUtils.Saml2.Helpers;

/// <summary>Compression helper</summary>
internal static class DeflateHelper
{
	internal static byte[] Zip(byte[] data)
	{
		using var memoryStream = new MemoryStream();
		using (var deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress))
		{
			deflateStream.Write(data, 0, data.Length);
		}

		return memoryStream.ToArray();
	}

	internal static string UnZip(byte[] data)
	{
		using var memoryStream = new MemoryStream(data);
		using var deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress);
		using var streamReader = new StreamReader(deflateStream, Encoding.UTF8);
		return streamReader.ReadToEnd();
	}
}
