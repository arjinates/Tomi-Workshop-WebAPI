using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomi.Domain.Entities;

namespace Tomi.Application.Features.Products.Queries
{
	public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
	{
		
	}
}
