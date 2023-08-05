namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API;

public class FeedbackReportingSettings
{
    public bool UseCustomizationData { get; set; }

    public string ConnectionString { get; set; }

    public string EventBusConnection { get; set; }

    public int GracePeriodTime { get; set; }

    public int CheckUpdateTime { get; set; }
}
