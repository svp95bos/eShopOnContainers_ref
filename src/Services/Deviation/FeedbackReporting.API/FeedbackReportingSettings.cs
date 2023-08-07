namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API;

public class FeedbackReportingSettings
{
    public string EventBusConnection { get; set; }

    public bool UseCustomizationData { get; set; }

    public bool AzureStorageEnabled { get; set; }
}
