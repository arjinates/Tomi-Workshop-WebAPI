namespace Tomi.Application.Models
{
    public class ShoppingCartItemModel
    {
        public string UserId { get; set; }

        public string ProductId { get; set; }

        public decimal ProductTotalPrice { get; set; }

        public int ProductCount { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public double Rating { get; set; }

	}
}