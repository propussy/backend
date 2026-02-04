using Microsoft.EntityFrameworkCore;

namespace Procat.SharedKernel.Paginations;

/// <summary>
/// Extension methods for pagination.
/// </summary>
public static class PaginationExtensions
{
    /// <summary>
    /// Applies pagination to an IQueryable.
    /// </summary>
    /// <typeparam name="T">The type of elements in the query.</typeparam>
    /// <param name="query">The queryable to paginate.</param>
    /// <param name="pageRequest">The pagination parameters.</param>
    /// <returns>A queryable with pagination applied.</returns>
    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, PageRequest pageRequest)
    {
        return query.Skip(pageRequest.Skip).Take(pageRequest.Take);
    }

    /// <summary>
    /// Creates a paged response from an IQueryable.
    /// </summary>
    /// <typeparam name="T">The type of elements in the query.</typeparam>
    /// <param name="query">The queryable to paginate.</param>
    /// <param name="pageRequest">The pagination parameters.</param>
    /// <param name="cancellationToken">Cancellation token for async operations.</param>
    /// <returns>A task representing the asynchronous operation, containing the paged response.</returns>
    public static async Task<PagedResponse<T>> ToPagedResponseAsync<T>(
        this IQueryable<T> query,
        PageRequest pageRequest,
        CancellationToken cancellationToken = default
    )
    {
        var totalCount = query.Count();
        var items = await query
            .Skip(pageRequest.Skip)
            .Take(pageRequest.Take)
            .ToListAsync(cancellationToken);

        return PagedResponse<T>.Create(
            items,
            pageRequest.PageNumber,
            pageRequest.PageSize,
            totalCount
        );
    }
}
