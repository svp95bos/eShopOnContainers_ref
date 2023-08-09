namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Queries;

public record FeedbackReport
{
    public Guid ReportId { get; init; }
    public int PublicId { get; init; }
    public string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public string LastName { get; init; }
    public List<FeedbackReportReplyMethod> ReplyMethods {get; init; }
    public string? POBox { get; init; }
    public string? Street { get; init; }
    public string? PostalCode { get; init; }
    public string? City { get; init; }
    public string? Country { get; init; }
    public string? Phone { get; init; }
    public string? WorkPhone { get; init; }
    public string? Email { get; init; }
    public string Description { get; init; }
    public DateTimeOffset Created { get; init; }
    public Guid CreatedBy { get; init; } = Guid.Parse("{00000000-0000-0000-0000-000000000000}");
    public bool IsReadOnly { get; init; } = false;
    public DateTimeOffset? Updated { get; init; }
    public Guid? UpdatedBy { get; init; } = default;
}

public record FeedbackReportReplyMethod
{
    public int ReplyMethodId { get; init; }
    public string ReplyMethodName { get; init; }
    public bool ReplyMethodEnabled { get; init; } = true;
}
