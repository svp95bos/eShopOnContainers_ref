
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

        var result = await connection.QueryAsync<dynamic>(
            @"SELECT feedbackreporting.FeedbackReports.Id AS ReportId, 
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
              FROM   feedbackreporting.FeedbackReplyMethods 
              INNER JOIN
                     feedbackreporting.FeedbackReportFeedbackReportReplyMethod ON 
                        feedbackreporting.FeedbackReplyMethods.Id = feedbackreporting.FeedbackReportFeedbackReportReplyMethod.ReplyMethodsId INNER JOIN
                     feedbackreporting.FeedbackReports ON 
                        feedbackreporting.FeedbackReportFeedbackReportReplyMethod.FeedbackReportsId = feedbackreporting.FeedbackReports.Id
              WHERE  (feedbackreporting.FeedbackReports.Id = @id)
              ORDER BY feedbackreporting.FeedbackReports.Created"
                , new { id }
            );


    }

    public Task<IEnumerable<FeedbackReportReplyMethod>> GetFeedbackReportReplyMethodsAsync()
    {
        throw new NotImplementedException();
    }
}
