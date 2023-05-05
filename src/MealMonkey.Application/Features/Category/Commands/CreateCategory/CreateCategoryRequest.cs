using MealMonkey.Domain.Entities.MealEntities;
using MediatR;

namespace MealMonkey.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public string Name { get; set; }
    }
}
