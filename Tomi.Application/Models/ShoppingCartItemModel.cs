namespace Tomi.Application.Models
{
    public class ShoppingCartItemModel
    {
        public string UserId { get; set; }

        public string ProductId { get; set; }

        public decimal ProductTotalPrice { get; set; }

        public int ProductCount { get; set; }

    }
}