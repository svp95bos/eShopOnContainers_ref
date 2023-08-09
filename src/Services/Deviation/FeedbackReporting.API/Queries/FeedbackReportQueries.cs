namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Queries;

public class FeedbackReportQueries : IFeedbackReportQueries
{
    private string _connectionString = string.Empty;

    public FeedbackReportQueries(string constr)
    {
        _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
    }

    public Task<FeedbackReport> GetFeedbackReportAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<FeedbackReportReplyMethod>> GetFeedbackReportReplyMethodsAsync()
    {
        throw new NotImplementedException();
    }
}
