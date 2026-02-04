namespace Procat.SharedKernel.Paginations;

/// <summary>
/// Contains pagination metadata and navigation information.
/// </summary>
public class PageMetadata
{
    /// <summary>
    /// Current page number (1-based).
    /// </summary>
    public int CurrentPage { get; }

    /// <summary>
    /// Number of items per page.
    /// </summary>
    public int PageSize { get; }

    /// <summary>
    /// Total number of items across all pages.
    /// </summary>
    public int TotalCount { get; }

    /// <summary>
    /// Total number of pages.
    /// </summary>
    public int TotalPages { get; }

    /// <summary>
    /// Whether there is a previous page.
    /// </summary>
    public bool HasPreviousPage { get; }

    /// <summary>
    /// Whether there is a next page.
    /// </summary>
    public bool HasNextPage { get; }

    /// <summary>
    /// The index of the first item on the current page (1-based).
    /// </summary>
    public int FirstItemIndex { get; }

    /// <summary>
    /// The index of the last item on the current page (1-based).
    /// </summary>
    public int LastItemIndex { get; }

    public PageMetadata(int currentPage, int pageSize, int totalCount)
    {
        if (currentPage < 1)
        {
            throw new ArgumentException("Page number must be greater than 0.", nameof(currentPage));
        }

        if (pageSize < 1)
        {
            throw new ArgumentException("Page size must be greater than 0.", nameof(pageSize));
        }

        if (totalCount < 0)
        {
            throw new ArgumentException("Total count cannot be negative.", nameof(totalCount));
        }

        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        HasPreviousPage = currentPage > 1;
        HasNextPage = currentPage < TotalPages;

        if (totalCount == 0)
        {
            FirstItemIndex = 0;
            LastItemIndex = 0;
        }
        else
        {
            FirstItemIndex = ((currentPage - 1) * pageSize) + 1;
            LastItemIndex = Math.Min(currentPage * pageSize, totalCount);
        }
    }
}
