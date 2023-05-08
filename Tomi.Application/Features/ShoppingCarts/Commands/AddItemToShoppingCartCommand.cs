using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomi.Application.ApiResponse;
using Tomi.Domain.Entities;

namespace Tomi.Application.Features.ShoppingCarts.Commands
{
	public class AddItemToShoppingCartCommand : IRequest<ShoppingCartItemModel>
	{
		public string UserId { get; set; }
		public string ProductId { get; set; }
	}
}
