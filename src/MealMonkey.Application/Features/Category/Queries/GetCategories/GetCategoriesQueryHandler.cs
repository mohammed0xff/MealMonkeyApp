using MealMonkey.Application.Features.CategoryFeatures.Queries.GetCategories;
using MealMonkey.Application.Common.Pagination;
using MealMonkey.Domain.Entities.MealEntities;
using MediatR;

namespace MealMonkey.Application.Features.CategoryFeatures.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, PaginatedListResponse<Category>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCategoriesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginatedListResponse<Category>> Handle(
            GetCategoriesQuery request, CancellationToken cancellationToken
            )
        {
            var categoriesQuery = _dbContext.Categories.AsQueryable();

            return await categoriesQuery
                .ToPaginatedListAsync(request.CurrentPage, request.PageSize);
        }
    }
}
