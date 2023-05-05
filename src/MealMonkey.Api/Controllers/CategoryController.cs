using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MealMonkey.Domain.Entities.MealEntities;
using MealMonkey.Application.Common.Pagination;
using MealMonkey.Application.Common.ResponseExceptions;
using MealMonkey.Application.Features.CategoryFeatures.Queries.GetCategories;
using MealMonkey.Application.Features.CategoryFeatures.Commands.DeleteCategory;
using MealMonkey.Application.Features.CategoryFeatures.Commands.CreateCategory;

namespace MealMonkey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public IMediator _mediator { get; set; }
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<PaginatedListResponse<Category>> GetCategories(GetCategoriesQuery query)
        {
           return await _mediator.Send(query);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Category>> GetCategoryById(GetCategoryByIdQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                return result;
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CreateCategoryCommand command)
        {
           return await _mediator.Send(command);
        }

        [HttpDelete]
        public async Task<IActionResult> DeteteCategory(DeleteCategoryCommand command)
        {
            return await _mediator.Send(command) ? NoContent() : NotFound();
        }
    }
}
