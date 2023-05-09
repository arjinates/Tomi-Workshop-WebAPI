using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tomi.Application.Features.Coupons.Commands;
using Tomi.Application.Features.Coupons.Queries;

namespace Tomi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponContoller : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

		[HttpGet("get-all-coupons")]
		public async Task<IActionResult> GetAllCoupons()
		{
			return Ok(await Mediator.Send(new GetAllCouponsQuery()));
		}

		[HttpPost("apply-coupon")]
        public async Task<IActionResult> ApplyCouponToShoppingCart(ApplyCouponCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
