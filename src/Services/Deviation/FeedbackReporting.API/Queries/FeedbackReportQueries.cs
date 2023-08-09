
namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Queries;

public class FeedbackReportQueries : IFeedbackReportQueries
{
    private string _connectionString = string.Empty;

    public FeedbackReportQueries(string constr)
    {
        _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
    }

    public async Task<FeedbackReport> GetFeedbackReportAsync(Guid id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var sql = @$"SELECT feedbackreporting.FeedbackReports.Id AS ReportId, 
                            feedbackreporting.FeedbackReports.PublicId, 
                            feedbackreporting.FeedbackReports.FirstName, 
                            feedbackreporting.FeedbackReports.MiddleName,
                            feedbackreporting.FeedbackReports.LastName,
                            feedbackreporting.FeedbackReports.POBox,
                            feedbackreporting.FeedbackReports.Street,
                            feedbackreporting.FeedbackReports.PostalCode, 
                            feedbackreporting.FeedbackReports.City,
                            feedbackreporting.FeedbackReports.Country,
                            feedbackreporting.FeedbackReports.Phone,
                            feedbackreporting.FeedbackReports.WorkPhone,
                            feedbackreporting.FeedbackReports.Email,
                            feedbackreporting.FeedbackReports.Description,
                            feedbackreporting.FeedbackReports.Created,
                            feedbackreporting.FeedbackReports.CreatedBy,
                            feedbackreporting.FeedbackReports.Updated, 
                            feedbackreporting.FeedbackReports.IsReadOnly,
                            feedbackreporting.FeedbackReports.UpdatedBy, 
                            feedbackreporting.FeedbackReplyMethods.Id AS ReplyMethodId, 
                            feedbackreporting.FeedbackReplyMethods.Name AS ReplyMethodName, 
                            feedbackreporting.FeedbackReplyMethods.Enabled AS ReplyMethodEnabled
                     FROM   feedbackreporting.FeedbackReports 
                     INNER JOIN
                            feedbackreporting.FeedbackReportFeedbackReportReplyMethod ON 
                            feedbackreporting.FeedbackReports.Id = feedbackreporting.FeedbackReportFeedbackReportReplyMethod.FeedbackReportsId 
                     INNER JOIN
                            feedbackreporting.FeedbackReplyMethods ON 
                            feedbackreporting.FeedbackReportFeedbackReportReplyMethod.ReplyMethodsId = feedbackreporting.FeedbackReplyMethods.Id
                     WHERE  (feedbackreporting.FeedbackReports.Id = {id})
                     ORDER BY feedbackreporting.FeedbackReports.Created";

        var reports = await connection.QueryAsync<FeedbackReport, FeedbackReportReplyMethod, FeedbackReport>(sql, (feedbackReport, feedbackReportReplyMethod) =>
        {
            feedbackReport.ReplyMethods.Add(feedbackReportReplyMethod);
            return feedbackReport;
        }, splitOn: "ReplyMethodId");

        var result = reports.GroupBy(r => r.ReportId).Select(g =>
        {
            var groupedReport = reports.First();
            groupedReport.ReplyMethods.AddRange(reports.Select(rm => rm.ReplyMethods.Single()).ToList());
            return groupedReport;
        });

        return result.FirstOrDefault();

    }

    public async Task<IEnumerable<FeedbackReportReplyMethod>> GetFeedbackReportReplyMethodsAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var sql = @"SELECT  Id AS ReplyMethodId, 
                            Name AS ReplyMethodName, 
                            Enabled AS ReplyMethodEnabled
                    FROM    feedbackreporting.FeedbackReplyMethods
                    ORDER BY ReplyMethodName";

        return await connection.QueryAsync<FeedbackReportReplyMethod>(sql);
    }
}
