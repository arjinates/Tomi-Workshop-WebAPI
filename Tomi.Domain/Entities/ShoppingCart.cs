using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tomi.Domain.Entities
{
	public class ShoppingCart : BaseEntity
	{
		public string UserId { get; set; }

		public string CouponId { get; set; }

		public List <ShoppingCartItem> ShoppingCartItemList { get; set; }

	}
}

