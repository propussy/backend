namespace Procat.SharedKernel.Paginations;

/// <summary>
/// Represents a paginated response with metadata and navigation links.
/// </summary>
/// <typeparam name="T">The type of items in the response.</typeparam>
public class PagedResponse<T>
{
    /// <summary>
    /// The items in the current page.
    /// </summary>
    public IReadOnlyList<T> Items { get; }

    /// <summary>
    /// Pagination metadata.
    /// </summary>
    public PageMetadata Metadata { get; }

    public PagedResponse(IReadOnlyList<T> items, PageMetadata metadata)
    {
        Items = items ?? throw new ArgumentNullException(nameof(items));
        Metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
    }

    /// <summary>
    /// Creates a paged response from a full collection.
    /// </summary>
    /// <param name="allItems">The complete collection of items to paginate.</param>
    /// <param name="pageNumber">The page number to retrieve (1-based).</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>A paged response containing the requested page of items.</returns>
    public static PagedResponse<T> Create(IEnumerable<T> allItems, int pageNumber, int pageSize)
    {
        var itemsList = allItems.ToList();
        var totalCount = itemsList.Count;

        var items = itemsList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        var metadata = new PageMetadata(
            currentPage: pageNumber,
            pageSize: pageSize,
            totalCount: totalCount
        );

        return new PagedResponse<T>(items, metadata);
    }

    /// <summary>
    /// Creates a paged response when total count is known separately (for database queries).
    /// </summary>
    /// <param name="items">The items for the current page.</param>
    /// <param name="pageNumber">The current page number (1-based).</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="totalCount">The total count of items across all pages.</param>
    /// <returns>A paged response containing the items and pagination metadata.</returns>
    public static PagedResponse<T> Create(
        IReadOnlyList<T> items,
        int pageNumber,
        int pageSize,
        int totalCount
    )
    {
        var metadata = new PageMetadata(
            currentPage: pageNumber,
            pageSize: pageSize,
            totalCount: totalCount
        );

        return new PagedResponse<T>(items, metadata);
    }
}
