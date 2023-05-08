using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomi.Domain.Entities;

namespace Tomi.Domain.IRepositories
{
	public interface IShoppingCartRepository :IBaseRepository<ShoppingCart>
	{
		Task<ShoppingCart> GetByUserIdAsync(string id);

	}
}
