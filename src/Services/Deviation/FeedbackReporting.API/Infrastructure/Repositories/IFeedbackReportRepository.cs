namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure.Repositories;

public interface IFeedbackReportRepository : IRepository<FeedbackReport>
{
    FeedbackReport Add(FeedbackReport report);

    /// <summary>
    /// Get a <see cref="FeedbackReport"/> by Id.
    /// </summary>
    /// <param name="reportId"></param>
    /// <returns></returns>
    Task<FeedbackReport> GetAsync(Guid reportId);

    /// <summary>
    /// Get a <see cref="FeedbackReport"/> by PublicId.
    /// </summary>
    /// <param name="reportId"></param>
    /// <returns></returns>
    Task<FeedbackReport> GetAsync(int publicId);

    Task<IEnumerable<FeedbackReport>> GetAsync();

    Task<IEnumerable<FeedbackReport>> GetAsync(List<Guid> ids);
}
