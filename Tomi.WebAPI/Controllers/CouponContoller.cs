using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tomi.Application.Features.Coupons.Commands;
using Tomi.Application.Features.Coupons.Queries;
using Tomi.Application.Features.ShoppingCarts.Commands;

namespace Tomi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
    public class CouponContoller : BaseController
    {

		[HttpGet("get-all-coupons")]
		public async Task<IActionResult> GetAllCoupons()
		{
			return Ok(await Mediator.Send(new GetAllCouponsQuery()));
		}

		[HttpPost("apply-coupon")]
        public async Task<IActionResult> ApplyCouponToShoppingCart(string couponId)
        {
			var command = new ApplyCouponCommand();
			command.UserId = UserId;
			command.CouponId = couponId;
			return Ok(await Mediator.Send(command));
		}
    }
}
