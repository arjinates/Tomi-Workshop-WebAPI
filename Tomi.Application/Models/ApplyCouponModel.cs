namespace Tomi.Application.Models
{
    public class ApplyCouponModel
    {

        public decimal BasketTotalPrice { get; set; }

        public string CouponId { get; set; }

        public decimal BasketFinalValue { get; set; }
    }
}
