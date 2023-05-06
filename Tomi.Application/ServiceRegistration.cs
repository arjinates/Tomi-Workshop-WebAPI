using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tomi.Application.Mappings;
using Tomi.Application.Services.Handlers.Products;

namespace Tomi.Application
{
	public static class ServiceRegistration
	{
		public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAutoMapper(typeof(GeneralProfile).Assembly);
			services.AddMediatR(typeof(GetAllProductsHandler).GetTypeInfo().Assembly);
			#region Repositories

			#endregion
		}
	}
}
