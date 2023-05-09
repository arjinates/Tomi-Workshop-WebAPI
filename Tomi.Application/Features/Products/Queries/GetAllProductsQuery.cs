using MediatR;

namespace Tomi.Application.Features.Products.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductModel>>
	{
		//open for extension
	}
}
