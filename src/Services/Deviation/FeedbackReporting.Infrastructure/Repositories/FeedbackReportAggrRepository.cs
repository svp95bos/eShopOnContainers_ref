


namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.Infrastructure.Repositories;
public class FeedbackReportAggrRepository : IFeedbackReportAggrRepository
{
    private readonly FeedbackReportingContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public FeedbackReportAggrRepository(FeedbackReportingContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public FeedbackReportAggr Add(FeedbackReportAggr report)
    {
        return _context.FeedbackReports.Add(report).Entity;
    }

    public async Task<FeedbackReportAggr> GetAsync(Guid reportId)
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
                .Collection(i => i.OrderItems).LoadAsync();
            await _context.Entry(report)
                .Reference(i => i.OrderStatus).LoadAsync();
        }

        return report;
    }

    public void Update(FeedbackReportAggr report)
    {
        throw new NotImplementedException();
    }
}
