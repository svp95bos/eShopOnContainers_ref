namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.EntityConfigurations;

internal class FeedbackReportReplyMethodConfiguration : IEntityTypeConfiguration<FeedbackReportReplyMethod>
{
    public void Configure(EntityTypeBuilder<FeedbackReportReplyMethod> builder)
    {
        builder.ToTable("FeedbackReplyMethods");
    }
}
