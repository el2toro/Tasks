namespace Task4.Extensions;

public static class IQueryableExtensions
{
    public static async Task<(int pageNumber, int pageSize, int totalCount, IEnumerable<T>)>
        ToPagedListAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        int totalCount = await query.CountAsync();
        IEnumerable<T> items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (pageNumber, pageSize, totalCount, items);
    }
}
