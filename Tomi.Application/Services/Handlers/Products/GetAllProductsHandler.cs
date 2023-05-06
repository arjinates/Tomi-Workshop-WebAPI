using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomi.Application.Features.Products.Queries;
using Tomi.Domain.Entities;
using Tomi.Domain.IRepositories;

namespace Tomi.Application.Services.Handlers.Products
{
	public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery,IEnumerable<GetAllProductsViewModel>>
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public GetAllProductsHandler (IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<GetAllProductsViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
		{
			var products = await _productRepository.GetAllAsync();
			var productViewModel = _mapper.Map<IEnumerable<GetAllProductsViewModel>>(products);
			return productViewModel;
		}
	}
}
