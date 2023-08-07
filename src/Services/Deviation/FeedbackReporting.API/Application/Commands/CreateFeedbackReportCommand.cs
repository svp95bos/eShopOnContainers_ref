
using FeedbackReportReplyMethodDTO = Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Model.DTO.FeedbackReportReplyMethodDTO;

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Application.Commands;

[DataContract]
public record CreateFeedbackReportCommand : IRequest<bool>
{
    [DataMember]
    private readonly List<FeedbackReportReplyMethodDTO> _replyMethods;

    [DataMember]
    public int PublicId { get; init; }

    [DataMember]
    public string FirstName { get; init; }

    [DataMember]
    public string MiddleName { get; init; }

    [DataMember]
    public string LastName { get; init; }

    [DataMember]
    public string POBox { get; init; }

    [DataMember]
    public string Street { get; init; }

    [DataMember]
    public string PostalCode { get; init; }

    [DataMember]
    public string City { get; init; }

    [DataMember]
    public string Country { get; init; }

    [DataMember]
    public string Phone { get; init; }

    [DataMember]
    public string WorkPhone { get; init; }

    [DataMember]
    public string Email { get; init; }

    [DataMember]
    public string Description { get; init; }

    [DataMember]
    public Guid CreatedBy { get; init; } = Guid.Parse("{00000000-0000-0000-0000-000000000000}");

    [DataMember]
    public bool IsReadOnly { get; init; } = false;

    [DataMember]
    public Guid UpdatedBy { get; init; } = default;

    [DataMember]
    public IEnumerable<FeedbackReportReplyMethodDTO> ReplyMethods => _replyMethods;

    public CreateFeedbackReportCommand()
    {
        _replyMethods = new List<FeedbackReportReplyMethodDTO>();
    }

    public CreateFeedbackReportCommand(List<FeedbackReportReplyMethodDTO> replyMethods, int publicId, string firstName, string middleName, string lastName, string pOBox, string street, string postalCode, string city, string country, string phone, string workPhone, string email, string description, Guid createdBy, bool isReadOnly, Guid updatedBy)
    {
        _replyMethods = replyMethods;
        PublicId = publicId;
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
        IsReadOnly = isReadOnly;
        UpdatedBy = updatedBy;
    }
}
