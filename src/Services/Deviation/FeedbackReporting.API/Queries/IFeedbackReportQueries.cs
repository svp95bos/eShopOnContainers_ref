using Microsoft.VisualBasic;
using StackExchange.Redis;

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Queries;

public interface IFeedbackReportQueries
{
    Task<FeedbackReport> GetFeedbackReportAsync(Guid id);
    Task<IEnumerable<FeedbackReportReplyMethod>> GetFeedbackReportReplyMethodsAsync();
}
