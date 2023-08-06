

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Application.Commands;

// DDD and CQRS patterns comment: Note that it is recommended to implement immutable Commands
// In this case, its immutability is achieved by having all the setters as private
// plus only being able to update the data just once, when creating the object through its constructor.
// References on Immutable Commands:  
// http://cqrs.nu/Faq
// https://docs.spine3.org/motivation/immutability.html 
// http://blog.gauffin.org/2012/06/griffin-container-introducing-command-support/
// https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/how-to-implement-a-lightweight-class-with-auto-implemented-properties



[DataContract]
public class CreateFeedbackReportCommand : IRequest<bool>
{
    private List<ReplyMethodDTO> _replyMethods { get; set; }

    [DataMember]
    public string FirstName { get; set; }

    [DataMember]
    public string? MiddleName { get; set; }

    [DataMember]
    public string LastName { get; set; }
    

    [DataMember]
    public string? POBox { get; set; }

    [DataMember]
    public string? Street { get; set; }

    [DataMember]
    public string? PostalCode { get; set; }

    [DataMember]
    public string? City { get; set; }

    [DataMember]
    public string? Country { get; set; }

    [DataMember]
    public string? Phone { get; set; }

    [DataMember]
    public string? WorkPhone { get; set; }

    [DataMember]
    public string? Email { get; set; }

    [DataMember]
    public string Description { get; set; }

    [DataMember]
    public string CreatedBy { get; set; }

    [DataMember]
    public bool IsReadOnly { get; set; } = false;

    [DataMember]
    public string? UpdatedBy { get; set; }
}
/*
string first_name = 1;
optional string middle_name = 2;
string last_name = 3;
repeated int32 reply_methods = 4;
    optional string po_box = 5;
optional string street = 6;
optional string postal_code = 7;
optional string city = 8;
optional string country = 9;
optional string phone = 10;
optional string work_phone = 11;
optional string email = 12;
string description = 13;
string created_by = 14;
optional string updated_by = 15;
optional bool is_read_only = 16;
*/
