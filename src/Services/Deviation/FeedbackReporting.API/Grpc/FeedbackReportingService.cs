

using static FeedbackReportingGrpcApi.FeedbackReportingGrpc;

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Grpc;

public class FeedbackReportingService : FeedbackReportingGrpcBase
{
    private readonly FeedbackReportingContext _feedbackReportingContext;
    private readonly FeedbackReportingSettings _settings;
    private readonly ILogger<FeedbackReportingService> _logger;

    public FeedbackReportingService(FeedbackReportingContext dbContext, IOptions<FeedbackReportingSettings> settings, ILogger<FeedbackReportingService> logger)
    {
        _settings = settings.Value;
        _feedbackReportingContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _logger = logger;
    }

    
}
