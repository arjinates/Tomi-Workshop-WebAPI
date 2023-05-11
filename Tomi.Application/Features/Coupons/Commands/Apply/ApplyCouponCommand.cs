using MediatR;
using Tomi.Application.Models;

namespace Tomi.Application.Features.Coupons.Commands.Apply
{
    public class ApplyCouponCommand : IRequest<ApplyCouponModel>
    {
        public string UserId { get; set; }
        public string CouponId { get; set; }
    }
}
