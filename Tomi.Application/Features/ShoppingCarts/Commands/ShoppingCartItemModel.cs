using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomi.Domain.Entities;

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