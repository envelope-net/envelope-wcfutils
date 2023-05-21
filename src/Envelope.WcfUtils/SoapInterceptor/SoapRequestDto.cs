namespace Envelope.WcfUtils;

public class SoapRequestDto
{
	public Guid? CorrelationId { get; set; }

	public string? Url { get; set; }

	public string? Headers { get; set; }

	public string? Payload { get; set; }

	public DateTime? SendingUtc { get; set; }

}
