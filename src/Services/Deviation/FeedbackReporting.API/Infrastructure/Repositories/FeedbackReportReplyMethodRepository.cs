namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure.Repositories;

public class FeedbackReportReplyMethodRepository : IFeedbackReportReplyMethodRepository
{
    private readonly FeedbackReportingContext _context;
    public FeedbackReportReplyMethodRepository(FeedbackReportingContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<FeedbackReportReplyMethod> GetAsync(int id)
    {
        var report = await _context
                            .FeedbackReportReplyMethods
                            .FirstOrDefaultAsync(o => o.Id == id);
        if (report == null)
        {
            report = _context
                        .FeedbackReportReplyMethods
                        .Local
                        .FirstOrDefault(o => o.Id == id);
        }

        return report;
    }

    public async Task<IEnumerable<FeedbackReportReplyMethod>> GetAsync()
    {
        return await _context.FeedbackReportReplyMethods.ToListAsync();
    }
}
