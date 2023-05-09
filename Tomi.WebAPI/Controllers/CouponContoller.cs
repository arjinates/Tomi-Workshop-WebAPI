using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tomi.Application.Features.Coupons.Commands;

namespace Tomi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponContoller : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost("apply-coupon")]
        public async Task<IActionResult> ApplyCouponToShoppingCart(ApplyCouponCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
