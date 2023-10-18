using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class ProductService
	{
		TestDbContext _ctx;
        private int totalItemPagina = 10;
        public ProductService(TestDbContext ctx)
		{
			_ctx = ctx;
		}

		public ProductList  ListProducts(int page)
		{
            var skip = (page - 1) * totalItemPagina;
            var products = _ctx.Products.Skip(skip).Take(totalItemPagina).ToList();
            var totalCount = _ctx.Products.Count(); // Consider caching this value if it doesn't change often.

            var hasNext = (skip + products.Count) < totalCount;

            return new ProductList { HasNext = hasNext, TotalCount = totalCount, Products = products };
        }

	}
}
