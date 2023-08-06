
namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.Domain.SeedWork;

public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}
