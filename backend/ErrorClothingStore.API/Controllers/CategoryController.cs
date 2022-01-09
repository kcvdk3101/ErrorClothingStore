using System;
using System.Threading.Tasks;
using ErrorClothingStore.Application.Features.Categories.Commands.CreateNewCategory;
using ErrorClothingStore.Application.Features.Categories.Queries.GetCategoryByDisplayName;
using ErrorClothingStore.Application.Features.Categories.Queries.GetCategoryList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ErrorClothingStore.API.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] GetCategoryList getCategoryList)
        {
            var categoryList = await _mediator.Send(getCategoryList);
            return Ok(categoryList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew([FromBody] CreateNewCategory createNewCategory)
        {
            var category = await _mediator.Send(new GetCategoryByDisplayName
                {DisplayName = createNewCategory.DisplayName});
            if (category != null)
                return BadRequest($"Category with {createNewCategory.DisplayName} has already exist!");

            var (errors, product) = await _mediator.Send(createNewCategory);
            if (errors != null) return BadRequest(errors);
            return Ok(product);
        }
    }
}