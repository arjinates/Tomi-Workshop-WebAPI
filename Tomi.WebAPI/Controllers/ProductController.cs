using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomi.Application.Features.Products.Queries;
using Tomi.Domain.Entities;

namespace Tomi.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private IMediator _mediator;
		protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

		[HttpGet("get-all_products")]
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
