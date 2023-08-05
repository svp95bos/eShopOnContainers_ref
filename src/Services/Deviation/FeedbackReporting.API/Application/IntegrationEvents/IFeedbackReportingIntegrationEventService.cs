namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Application.IntegrationEvents;

public interface IFeedbackReportingIntegrationEventService
{
    Task PublishEventsThroughEventBusAsync(Guid transactionId);
    Task AddAndSaveEventAsync(IntegrationEvent evt);
}
