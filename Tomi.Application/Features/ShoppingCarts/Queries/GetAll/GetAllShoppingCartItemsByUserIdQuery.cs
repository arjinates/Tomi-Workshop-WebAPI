using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomi.Application.Models;

namespace Tomi.Application.Features.ShoppingCarts.Queries.GetAll
{
    public class GetAllShoppingCartItemsByUserIdQuery : IRequest<ShoppingCartModel>
    {
        public string UserId { get; set; }
    }
}

