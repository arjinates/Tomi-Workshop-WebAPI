using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomi.Application.Models
{
	public class CouponModel
	{
		public string CouponId { get; set; }
		public string DiscountType { get; set; }
		public int Value { get; set; }
	}
}
