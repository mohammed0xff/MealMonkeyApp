using Microsoft.EntityFrameworkCore;

namespace MealMonkey.Application.Common.Pagination
{
    public class PaginatedListResponse<T>
    {
        public int CurrentPage { get; init; }
        public int TotalPages { get; init; }
        public int TotalItems { get; init; }

        public List<T> Result { get; init; } = new List<T>();

        public PaginatedListResponse(List<T> items, int count, int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalItems = count;
            Result.AddRange(items);
        }

        public PaginatedListResponse()
        {

        }
    }

    public static class PaginatedListHelper
    {

        public const int DefaultPageSize = 15;
        public const int DefaultCurrentPage = 1;

        public static async Task<PaginatedListResponse<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int currentPage, int pageSize)
        {
            currentPage = currentPage > 0 ? currentPage : DefaultCurrentPage;
            pageSize = pageSize > 0 ? pageSize : DefaultPageSize;
            var count = await source.CountAsync();
            var items = await source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedListResponse<T>(items, count, currentPage, pageSize);
        }
    }
}
