

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.EntityConfigurations;

internal class FeedbackReportConfiguration : IEntityTypeConfiguration<FeedbackReport>
{
    public void Configure(EntityTypeBuilder<FeedbackReport> builder)
    {
        builder.ToTable("FeedbackReports", 
            FeedbackReportingContext.DEFAULT_SCHEMA, 
            t => t.IsTemporal(
            tt =>
            {
                tt.HasPeriodStart("DataValidFrom");
                tt.HasPeriodEnd("DataValidTo");
            }
            ));

        builder.Ignore(b => b.DomainEvents);
    }
}
