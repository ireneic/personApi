namespace Person_Api.Moduls;

public static class PaginationExtension
{
    public static Pagination<T> ToPagedResponse<T>(this IEnumerable<T> source, int page, int pageSize)
    {
     

        var totalRecords = source.Count();
        var data = source
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new Pagination<T>
        {
            Page = page,
            PageSize = pageSize,
            Data = data
        };
    }
} 
