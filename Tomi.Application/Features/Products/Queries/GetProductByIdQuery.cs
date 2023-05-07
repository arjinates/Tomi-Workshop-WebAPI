using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomi.Application.Features.Products.Queries
{
	public class GetProductByIdQuery : IRequest<ProductModel>
	{
		public string Id { get; set; }
	}
}
