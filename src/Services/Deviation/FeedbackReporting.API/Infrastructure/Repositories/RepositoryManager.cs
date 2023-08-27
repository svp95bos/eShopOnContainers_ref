namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
    readonly Lazy<IFeedbackReportRepository> _feedbackReportRepository;
    readonly Lazy<IFeedbackReportReplyMethodRepository> _feedbackReportReplyMethodRepository;

    public RepositoryManager(FeedbackReportingContext context)
    {
        _feedbackReportRepository =new Lazy<IFeedbackReportRepository>(() => new FeedbackReportRepository(context));
        _feedbackReportReplyMethodRepository = new Lazy<IFeedbackReportReplyMethodRepository>(() => new FeedbackReportReplyMethodRepository(context));

    }
    public IFeedbackReportRepository FeedbackReportRepository => _feedbackReportRepository.Value;

    public IFeedbackReportReplyMethodRepository FeedbackReportReplyMethodRepository => _feedbackReportReplyMethodRepository.Value;
}
