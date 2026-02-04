namespace Procat.SharedKernel.Paginations;

/// <summary>
/// Request parameters for pagination.
/// </summary>
public class PageRequest
{
    private const int MaxPageSize = 100;
    private const int DefaultPageSize = 20;

    private int _pageNumber = 1;
    private int _pageSize = DefaultPageSize;

    /// <summary>
    /// Page number (1-based). Defaults to 1.
    /// </summary>
    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 1 ? 1 : value;
    }

    /// <summary>
    /// Number of items per page. Defaults to 20, max 100.
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        set =>
            _pageSize = value switch
            {
                < 1 => DefaultPageSize,
                > MaxPageSize => MaxPageSize,
                _ => value,
            };
    }

    /// <summary>
    /// Number of items to skip.
    /// </summary>
    public int Skip => (PageNumber - 1) * PageSize;

    /// <summary>
    /// Number of items to take.
    /// </summary>
    public int Take => PageSize;
}
