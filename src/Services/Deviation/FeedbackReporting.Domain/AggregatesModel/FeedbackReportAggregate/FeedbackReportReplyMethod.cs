using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.Domain.AggregatesModel.FeedbackReportAggregate;
/// <remarks> 
/// Card type class should be marked as abstract with protected constructor to encapsulate known enum types
/// this is currently not possible as OrderingContextSeed uses this constructor to load cardTypes from csv file
/// </remarks>
public class FeedbackReportReplyMethod
    : Enumeration
{
    public static FeedbackReportReplyMethod None = new(1, "Jag vill inte bli kontaktad");
    public static FeedbackReportReplyMethod Email = new(2, "E-post");
    public static FeedbackReportReplyMethod Phone = new(3, "Telefon");
    public static FeedbackReportReplyMethod Letter = new(4, "Brev");

    public FeedbackReportReplyMethod(int id, string name)
        : base(id, name)
    {
    }
}
