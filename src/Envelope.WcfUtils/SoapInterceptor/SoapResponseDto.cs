namespace Envelope.WcfUtils;

public class SoapResponseDto
{
	public string? Headers { get; set; }

	public string? Payload { get; set; }

	public string? Error { get; set; }

	public int? StatusCode { get; set; }

	public decimal? ElapsedMilliseconds { get; set; }
}
