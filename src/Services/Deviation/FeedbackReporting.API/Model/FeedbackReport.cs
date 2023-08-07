

using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure.Repositories;

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Model;

public class FeedbackReport 
    : Entity, IAggregateRoot
{
    public FeedbackReport(string firstName, string? middleName, string lastName, string? pOBox, string? street, string? postalCode, string? city, string? country, string? phone, string? workPhone, string? email, string description, Guid createdBy, Guid? updatedBy)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        POBox = pOBox;
        Street = street;
        PostalCode = postalCode;
        City = city;
        Country = country;
        Phone = phone;
        WorkPhone = workPhone;
        Email = email;
        Description = description;
        CreatedBy = createdBy;
        UpdatedBy = updatedBy;
    }

    // DDD Patterns comment
    // Using a private collection field, better for DDD Aggregate's encapsulation
    // so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
    // but only through the method OrderAggrergateRoot.AddOrderItem() which includes behaviour.
    private readonly List<FeedbackReportReplyMethod> _replyMethods;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PublicId { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public IReadOnlyCollection<FeedbackReportReplyMethod> ReplyMethods => _replyMethods;
    public string? POBox { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? WorkPhone { get; set; }
    public string? Email { get; set; }
    public string Description { get; set; }

    // IMetadata members
    public DateTimeOffset Created { get; set; }
    public Guid CreatedBy { get; set; } = Guid.Parse("{00000000-0000-0000-0000-000000000000}");
    public bool IsReadOnly { get; set; } = false;
    public DateTimeOffset? Updated { get; set; }
    public Guid? UpdatedBy { get; set; } = default;

    public void AddReplyMethod(FeedbackReportReplyMethod rm)
    {
        var existingReplyMethod = _replyMethods.Where(rm => rm.Id == rm.Id)
            .SingleOrDefault();

        if (existingReplyMethod is null) {
            _replyMethods.Add(rm);
        }
    }
}
