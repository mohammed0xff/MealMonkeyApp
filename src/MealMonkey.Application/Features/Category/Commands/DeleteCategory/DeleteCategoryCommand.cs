using MediatR;

namespace MealMonkey.Application.Features.CategoryFeatures.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
