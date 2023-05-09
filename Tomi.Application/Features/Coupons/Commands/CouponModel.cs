namespace Tomi.Application.Features.Coupons.Commands
{
    public class CouponModel
    {

        public decimal BasketTotalPrice { get; set; }

        public string CouponId { get; set; }

        public decimal BasketFinalValue { get; set; }
    }
}
