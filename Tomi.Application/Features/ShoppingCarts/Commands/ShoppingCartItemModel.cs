namespace Tomi.Application.Features.ShoppingCarts.Commands
{
    public class ShoppingCartItemModel
	{
		public string UserId { get; set; }

		public string ProductId { get; set; }

		public decimal TotalPrice { get; set; }

		public int TotalCount { get; set; }

	}
}