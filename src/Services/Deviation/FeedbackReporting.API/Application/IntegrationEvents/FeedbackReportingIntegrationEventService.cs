namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Application.IntegrationEvents;

public class FeedbackReportingIntegrationEventService : IFeedbackReportingIntegrationEventService
{
    private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
    private readonly IEventBus _eventBus;
    private readonly FeedbackReportingContext _feedbackReportingContext;
    private readonly IIntegrationEventLogService _eventLogService;
    private readonly ILogger<FeedbackReportingIntegrationEventService> _logger;

    public FeedbackReportingIntegrationEventService(IEventBus eventBus,
        FeedbackReportingContext feedbackReportingContext,
        IntegrationEventLogContext eventLogContext,
        Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory,
        ILogger<FeedbackReportingIntegrationEventService> logger)
    {
        _feedbackReportingContext = feedbackReportingContext ?? throw new ArgumentNullException(nameof(feedbackReportingContext));
        _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
        _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        _eventLogService = _integrationEventLogServiceFactory(_feedbackReportingContext.Database.GetDbConnection());
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task PublishEventsThroughEventBusAsync(Guid transactionId)
    {
        var pendingLogEvents = await _eventLogService.RetrieveEventLogsPendingToPublishAsync(transactionId);

        foreach (var logEvt in pendingLogEvents)
        {
            _logger.LogInformation("Publishing integration event: {IntegrationEventId} - ({@IntegrationEvent})", logEvt.EventId, logEvt.IntegrationEvent);

            try
            {
                await _eventLogService.MarkEventAsInProgressAsync(logEvt.EventId);
                _eventBus.Publish(logEvt.IntegrationEvent);
                await _eventLogService.MarkEventAsPublishedAsync(logEvt.EventId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error publishing integration event: {IntegrationEventId}", logEvt.EventId);

                await _eventLogService.MarkEventAsFailedAsync(logEvt.EventId);
            }
        }
    }

    public async Task AddAndSaveEventAsync(IntegrationEvent evt)
    {
        _logger.LogInformation("Enqueuing integration event {IntegrationEventId} to repository ({@IntegrationEvent})", evt.Id, evt);

        await _eventLogService.SaveEventAsync(evt, _feedbackReportingContext.GetCurrentTransaction());
    }
}
