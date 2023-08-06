using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.Domain.SeedWork;

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.Domain.AggregatesModel.FeedbackReportAggregate;
public class FeedbackReportAggr : Entity, IAggregateRoot
{
    // DDD Patterns comment
    // Using private fields, allowed since EF Core 1.1, is a much better encapsulation
    // aligned with DDD Aggregates and Domain Entities (Instead of properties and property collections)
    private readonly List<FeedbackReportReplyMethod> _replyMethods;

    public IReadOnlyCollection<FeedbackReportReplyMethod> ReplyMethods => _replyMethods;

    protected FeedbackReportAggr() { }

    public FeedbackReportAggr(
        string firstName, 
        string lastName, 
        string pOBox,
        string street,
        string postalCode,
        string city,
        string country,
        string phone,
        string workPhone,
        string email,
        string description,
        string createdBy,
        string updatedBy,
        bool isReadOnly,
        string? middleName = default ) : this()
    {

    }
}
