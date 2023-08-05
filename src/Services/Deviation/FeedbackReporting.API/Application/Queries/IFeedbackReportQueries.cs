namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Application.Queries;

public interface IFeedbackReportQueries
{
    Task<FeedbackReport> GetFeedbackReportAsync(Guid id);
    Task<FeedbackReport> GetFeedbackReportAsync(int id);
}
