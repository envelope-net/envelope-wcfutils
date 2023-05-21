using Envelope.Trace;

namespace Envelope.WcfUtils;

public interface ISoapRequestResponseLogger
{
	public Task<Guid?> LogRequestAsync(
		SoapRequestDto requestDto,
		ITraceInfo traceInfo,
		IServiceProvider serviceProvider,
		string clientName,
		CancellationToken cancellationToken = default);

	public Task LogResponseAsync(
		Guid requestIdentifier,
		SoapResponseDto responseDto,
		ITraceInfo traceInfo,
		IServiceProvider serviceProvider,
		string clientName,
		CancellationToken cancellationToken = default);
}
