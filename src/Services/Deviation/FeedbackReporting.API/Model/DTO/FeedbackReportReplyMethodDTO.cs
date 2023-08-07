namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Model.DTO;

public class FeedbackReportReplyMethodDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Enabled { get; set; } = true;
}
