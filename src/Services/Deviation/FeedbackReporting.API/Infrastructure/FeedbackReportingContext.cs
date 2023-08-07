using Microsoft.EntityFrameworkCore.Design;
using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.EntityConfigurations;
using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Model;

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure;

public class FeedbackReportingContext : DbContext
{
    public FeedbackReportingContext(DbContextOptions<FeedbackReportingContext> options) : base(options)
    {
    }
    public DbSet<FeedbackReport> FeedbackReports { get; set; }
    public DbSet<FeedbackReportReplyMethod> FeedbackReportReplyMethods { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new FeedbackReportConfiguration());
        builder.ApplyConfiguration(new FeedbackReportReplyMethodConfiguration());
    }
}


public class FeedbackReportingContextDesignFactory : IDesignTimeDbContextFactory<FeedbackReportingContext>
{
    public FeedbackReportingContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FeedbackReportingContext>()
            .UseSqlServer("Server=.;Initial Catalog=Microsoft.eShopOnContainers.Services.Deviation.FeedbackReportingDb;Integrated Security=true");

        return new FeedbackReportingContext(optionsBuilder.Options);
    }
}
