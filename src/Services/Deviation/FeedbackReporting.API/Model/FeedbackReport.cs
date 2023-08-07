

using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure.Repositories;

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Model;

public class FeedbackReport 
    : Entity, IAggregateRoot
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PublicId { get; set; }
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public List<FeedbackReportReplyMethod> ReplyMethods { get; set; }
    public string? POBox { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? WorkPhone { get; set; }
    public string? Email { get; set; }
    public required string Description { get; set; }

    // IMetadata members
    public DateTimeOffset Created { get; set; }
    public Guid CreatedBy { get; set; } = Guid.Parse("{00000000-0000-0000-0000-000000000000}");
    public bool IsReadOnly { get; set; } = false;
    public DateTimeOffset? Updated { get; set; }
    public Guid? UpdatedBy { get; set; } = default;
}
