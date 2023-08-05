namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Application.Queries;

public interface IFeedbackReportQueries
{
    Task<FeedbackReportViewModel> GetFeedbackReportAsync(Guid id);
    Task<FeedbackReportViewModel> GetFeedbackReportAsync(int id);
}
