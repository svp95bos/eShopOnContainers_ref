namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure.Repositories;

public interface IFeedbackReportReplyMethodRepository
{
    Task<FeedbackReportReplyMethod> GetAsync(int id);
    Task<IEnumerable<FeedbackReportReplyMethod>> GetAsync();
}
