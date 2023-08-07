namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Model;

public class FeedbackReportReplyMethod
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public required string Name { get; set; }
    public bool Enabled { get; set; } = true;
    public List<FeedbackReport> FeedbackReports { get; } = new();
}
