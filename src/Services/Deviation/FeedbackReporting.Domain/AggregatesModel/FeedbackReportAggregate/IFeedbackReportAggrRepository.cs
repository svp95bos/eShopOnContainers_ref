
namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.Domain.AggregatesModel.FeedbackReportAggregate;

// This is just the RepositoryContracts or Interface defined at the Domain Layer
// as requisite for the Order Aggregate

public interface IFeedbackReportAggrRepository : IRepository<FeedbackReportAggr>
{
    FeedbackReportAggr Add(FeedbackReportAggr report);

    void Update(FeedbackReportAggr report);

    Task<FeedbackReportAggr> GetAsync(Guid reportId);
}
