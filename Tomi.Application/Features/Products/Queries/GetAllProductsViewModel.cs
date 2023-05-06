﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomi.Application.Features.Products.Queries
{
	//Response model
	public class GetAllProductsViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
	}
}