using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tomi.Application.Features.Coupons.Queries;
using Tomi.Application.Features.Products.Queries;
using Tomi.Application.Features.ShoppingCarts.Queries;
using Tomi.Application.Models;
using Tomi.Application.Services.Handlers.Products;
using Tomi.Domain.Entities;

namespace Tomi.Application.Mappings
{
	public class GeneralProfile : Profile
	{
		public GeneralProfile()
		{

			CreateMap<Product, ProductModel>().ReverseMap();
			CreateMap<Product, GetAllProductsQuery>().ReverseMap();
			CreateMap<Product, GetProductByIdQuery>().ReverseMap();

			CreateMap<Coupon, CouponModel>().ReverseMap();
			CreateMap<Coupon, GetAllCouponsQuery>().ReverseMap();
			CreateMap<Coupon, ApplyCouponModel>().ReverseMap();

			CreateMap<ShoppingCart, ShoppingCartItemModel>().ReverseMap();
			CreateMap<ShoppingCart, GetAllShoppingCartItemsByUserIdQuery>().ReverseMap();

		}
	}
}