using MealMonkey.Application.Features.CategoryFeatures.Queries.GetCategories;
using MealMonkey.Domain.Entities.MealEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MealMonkey.Application.Features.CategoryFeatures.GetCategories
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCategoryByIdQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = _dbContext.Categories.Where(x => x.Id == request.Id);

            return await category.FirstOrDefaultAsync();
        }
    }
}
