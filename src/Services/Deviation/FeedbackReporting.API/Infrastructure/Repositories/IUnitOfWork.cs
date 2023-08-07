namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
}
