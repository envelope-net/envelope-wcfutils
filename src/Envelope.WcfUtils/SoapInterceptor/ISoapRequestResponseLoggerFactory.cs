namespace Envelope.WcfUtils;

public interface ISoapRequestResponseLoggerFactory
{
	ISoapRequestResponseLogger? GetLogger(string clientName);
}
