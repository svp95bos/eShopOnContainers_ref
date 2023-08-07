

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.EntityConfigurations;

internal class FeedbackReportConfiguration : IEntityTypeConfiguration<FeedbackReport>
{
    public void Configure(EntityTypeBuilder<FeedbackReport> builder)
    {
        builder.ToTable("FeedbackReports", t => t.IsTemporal(
            tt =>
            {
                tt.HasPeriodStart("DataValidFrom");
                tt.HasPeriodEnd("DataValidTo");
            }
            ));
    }
}
