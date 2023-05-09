using MediatR;
using Tomi.Application.Models;

namespace Tomi.Application.Features.Products.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductModel>>
	{
		//open for extension
	}
}
