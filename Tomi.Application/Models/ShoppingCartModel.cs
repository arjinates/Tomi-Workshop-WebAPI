using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomi.Application.Models
{
	public class ShoppingCartModel
	{
		public List<ShoppingCartItemModel> Items { get; set; }
		public decimal TotalShoppingCart { get; set; }
	}
}
