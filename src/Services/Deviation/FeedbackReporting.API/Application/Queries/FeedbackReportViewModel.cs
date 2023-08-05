namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Application.Queries;

public record FeedbackReport
{
    public Guid Id { get; init; }
    public int PublicId { get; init; }
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public virtual List<ReplyMethod> ReplyMethods { get; set; }
    public string? POBox { get; init; }
    public string? Street { get; init; }
    public string? PostalCode { get; init; }
    public string? City { get; init; }
    public string? Country { get; init; }
    public string? Phone { get; init; }
    public string? WorkPhone { get; init; }
    public string? Email { get; init; }
    public required string Description { get; init; }

    // IMetadata members
    public DateTimeOffset Created { get; init; }
    public Guid CreatedBy { get; init; } = Guid.Parse("{00000000-0000-0000-0000-000000000000}");
    public bool IsReadOnly { get; init; } = false;
    public DateTimeOffset? Updated { get; init; }
    public Guid? UpdatedBy { get; init; } = default;
    public Guid? InvestigationId { get; init; }
}

public record ReplyMethod
{
    public int Id { get; init; }
    public string Name { get; init; }
    public bool Enabled { get; init; } = true;
}
