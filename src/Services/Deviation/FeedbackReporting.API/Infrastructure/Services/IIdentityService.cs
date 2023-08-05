namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure.Services;

public interface IIdentityService
{
    string GetUserIdentity();

    string GetUserName();
}
