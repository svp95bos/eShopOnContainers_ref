namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Model;

/// <summary>
/// Helper class for creating Paginated result sets.
/// </summary>
/// <typeparam name="TEntity">Either <see cref="FeedbackReport"/> or <see cref="FeedbackReportReplyMethod"/></typeparam>
public class PaginatedItemsViewModel<TEntity> where TEntity : class
{
    /// <summary>
    /// Current page
    /// </summary>
    public int PageIndex { get; private set; }

    /// <summary>
    /// Number of items per page.
    /// </summary>
    public int PageSize { get; private set; }

    /// <summary>
    /// Total number of items.
    /// </summary>
    public long Count { get; private set; }

    /// <summary>
    /// The dataset to be paginated.
    /// </summary>
    public IEnumerable<TEntity> Data { get; private set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="pageIndex">See <seealso cref="PageIndex"/></param>
    /// <param name="pageSize">See <seealso cref="PageSize"/></param>
    /// <param name="count">See <seealso cref="Count"/></param>
    /// <param name="data">See <seealso cref="Data"/></param>
    public PaginatedItemsViewModel(int pageIndex, int pageSize, long count, IEnumerable<TEntity> data)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Count = count;
        Data = data;
    }
}
