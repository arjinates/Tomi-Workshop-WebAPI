namespace Tomi.Domain.Entities
{
    public class Coupon : BaseEntity
    {
        public string CouponId { get; set; }
        public string DiscountType { get; set; }
        public int Value { get; set; }
    }
}
