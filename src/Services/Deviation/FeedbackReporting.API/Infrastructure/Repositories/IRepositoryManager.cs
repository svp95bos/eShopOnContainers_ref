namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure.Repositories;

public interface IRepositoryManager
{
    public IFeedbackReportRepository FeedbackReportRepository { get; }
    public IFeedbackReportReplyMethodRepository FeedbackReportReplyMethodRepository { get; }
}
