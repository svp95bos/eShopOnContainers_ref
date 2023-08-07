
namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.IntegrationEvents;

public class FeedbackReportingIntegrationEventService : IFeedbackReportingIntegrationEventService, IDisposable
{
    private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
    private readonly IEventBus _eventBus;
    private readonly FeedbackReportingContext _reportingContext;
    private readonly IIntegrationEventLogService _eventLogService;
    private readonly ILogger<FeedbackReportingIntegrationEventService> _logger;
    private volatile bool disposedValue;

    public FeedbackReportingIntegrationEventService(
        ILogger<FeedbackReportingIntegrationEventService> logger,
        IEventBus eventBus,
        FeedbackReportingContext reportingContext,
        Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _reportingContext = reportingContext ?? throw new ArgumentNullException(nameof(reportingContext));
        _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
        _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        _eventLogService = _integrationEventLogServiceFactory(_reportingContext.Database.GetDbConnection());
    }

    public async Task PublishThroughEventBusAsync(IntegrationEvent evt)
    {
        try
        {
            _logger.LogInformation("Publishing integration event: {IntegrationEventId_published} - ({@IntegrationEvent})", evt.Id, evt);

            await _eventLogService.MarkEventAsInProgressAsync(evt.Id);
            _eventBus.Publish(evt);
            await _eventLogService.MarkEventAsPublishedAsync(evt.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error Publishing integration event: {IntegrationEventId} - ({@IntegrationEvent})", evt.Id, evt);
            await _eventLogService.MarkEventAsFailedAsync(evt.Id);
        }
    }

    public async Task SaveEventAndFeedbackReportingContextChangesAsync(IntegrationEvent evt)
    {
        _logger.LogInformation("ReportingIntegrationEventService - Saving changes and integrationEvent: {IntegrationEventId}", evt.Id);

        //Use of an EF Core resiliency strategy when using multiple DbContexts within an explicit BeginTransaction():
        //See: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency            
        await ResilientTransaction.New(_reportingContext).ExecuteAsync(async () =>
        {
            // Achieving atomicity between original catalog database operation and the IntegrationEventLog thanks to a local transaction
            await _reportingContext.SaveChangesAsync();
            await _eventLogService.SaveEventAsync(evt, _reportingContext.Database.CurrentTransaction);
        });
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                (_eventLogService as IDisposable)?.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
