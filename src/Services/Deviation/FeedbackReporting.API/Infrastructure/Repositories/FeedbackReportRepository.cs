namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure.Repositories;

public class FeedbackReportRepository : IFeedbackReportRepository
{
    private readonly FeedbackReportingContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public FeedbackReportRepository(FeedbackReportingContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public FeedbackReport Add(FeedbackReport report)
    {
        return _context.FeedbackReports.Add(report).Entity;
    }

    //<inheritdoc/>
    public async Task<FeedbackReport> GetAsync(Guid reportId)
    {
        var report = await _context
                            .FeedbackReports
                            //.Include(x => x.Address)
                            .FirstOrDefaultAsync(o => o.Id == reportId);
        if (report == null)
        {
            report = _context
                        .FeedbackReports
                        .Local
                        .FirstOrDefault(o => o.Id == reportId);
        }
        if (report != null)
        {
            await _context.Entry(report)
                .Collection(i => i.ReplyMethods).LoadAsync();
        }

        return report;
    }

    //<inheritdoc/>
    public async Task<FeedbackReport> GetAsync(int publicId)
    {
        var report = await _context
                            .FeedbackReports
                            //.Include(x => x.Address)
                            .FirstOrDefaultAsync(o => o.PublicId == publicId);
        if (report == null)
        {
            report = _context
                        .FeedbackReports
                        .Local
                        .FirstOrDefault(o => o.PublicId == publicId);
        }
        if (report != null)
        {
            await _context.Entry(report)
                .Collection(i => i.ReplyMethods).LoadAsync();
        }

        return report;
    }
}
