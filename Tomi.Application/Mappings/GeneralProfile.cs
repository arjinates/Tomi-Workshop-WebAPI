using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tomi.Application.Features.Products.Queries;
using Tomi.Domain.Entities;

namespace Tomi.Application.Mappings
{
	public class GeneralProfile : Profile
	{
		public GeneralProfile()
		{
			CreateMap<GetAllProductsQuery, Product>();
			CreateMap<Product, GetAllProductsQuery>();
			CreateMap<Product, ProductModel>().ReverseMap();
		}
	}
}
