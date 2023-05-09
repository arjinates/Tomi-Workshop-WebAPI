using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomi.Application.Models;

namespace Tomi.Application.Features.Coupons.Queries
{
	public class GetAllCouponsQuery : IRequest<IEnumerable<CouponModel>>
	{
	}
}
