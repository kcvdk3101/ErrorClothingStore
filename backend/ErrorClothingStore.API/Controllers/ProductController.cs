using System;
using System.Threading.Tasks;
using ErrorClothingStore.Application.Features.Products.Commands.CreateNewProduct;
using ErrorClothingStore.Application.Features.Products.Queries.GetProductDetails;
using ErrorClothingStore.Application.Features.Products.Queries.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ErrorClothingStore.API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] GetProductList getProductList)
        {
            var productList = await _mediator.Send(getProductList);
            return Ok(productList);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Details([FromRoute] GetProductDetails getProductDetails)
        {
            var product = await _mediator.Send(getProductDetails);
            if (product == null) return NotFound($"Product with id {getProductDetails.Id} cannot be found");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew([FromBody] CreateNewProduct createNewProduct)
        {
            var (errors, product) = await _mediator.Send(createNewProduct);
            if (errors != null) return BadRequest(errors);
            return Ok(product);
        }
    }
}