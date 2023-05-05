using MealMonkey.Domain.Entities.MealEntities;
using MediatR;

namespace MealMonkey.Application.Features.CategoryFeatures.Queries.GetCategories
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public Guid Id { get; set; }
    }
}
