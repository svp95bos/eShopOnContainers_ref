
namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.IntegrationEvents;

public interface IFeedbackReportingIntegrationEventService
{
    Task SaveEventAndFeedbackReportingContextChangesAsync(IntegrationEvent evt);
    Task PublishThroughEventBusAsync(IntegrationEvent evt);
}
