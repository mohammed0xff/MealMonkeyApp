namespace MealMonkey.Application.Common.Pagination
{
    public class PaginatedRequest
    {
        public int CurrentPage { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}