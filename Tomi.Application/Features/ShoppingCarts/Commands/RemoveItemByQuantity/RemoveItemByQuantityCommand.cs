using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomi.Application.ApiResponse;
using Tomi.Application.Models;

namespace Tomi.Application.Features.ShoppingCarts.Commands.RemoveItemByQuantity
{
	public class RemoveItemByQuantityCommand : IRequest<Response<string>>
	{
		public string UserId { get; set; }
		public string ProductId { get; set; }
		public int Quantity { get; set; }
	}
}
