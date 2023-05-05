using MealMonkey.Application.Common.Pagination;
using MealMonkey.Domain.Entities.MealEntities;
using MediatR;

namespace MealMonkey.Application.Features.CategoryFeatures.Queries.GetCategories
{
    public class GetCategoriesQuery : PaginatedRequest, IRequest<PaginatedListResponse<Category>>
    {
    }

}
