using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomi.Application.Features.Products.Queries;
using Tomi.Domain.Entities;

namespace Tomi.WebAPI.Controllers
{
	[ApiController]
	public class ProductController : BaseController
	{

		[HttpGet("get-all-products")]
		public async Task<IActionResult> GetAllProducts()
		{
			return Ok(await Mediator.Send(new GetAllProductsQuery()));
		}

		[HttpGet("get-product-by-id")]
		public async Task<IActionResult> GetProductsById([FromQuery] GetProductByIdQuery command)
		{
			return Ok(await Mediator.Send(command));
		}
	}
}
