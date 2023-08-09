﻿namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Model.DTO;

public record FeedbackReportDTO
{
    public Guid Id { get; init; }
    public int PublicId { get; init; }
    public string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public string LastName { get; init; }
    public IReadOnlyCollection<FeedbackReportReplyMethod> ReplyMethods { get; init; }
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
