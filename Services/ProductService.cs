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

		public BaseList<Product>  ListProducts(int page)
		{
            var skip = (page - 1) * totalItemPagina;
            var products = _ctx.Products.Skip(skip).Take(totalItemPagina).ToList();
            var totalCount = _ctx.Products.Count(); 

            var hasNext = (skip + products.Count) < totalCount;

            return new BaseList<Product> { HasNext = hasNext, TotalCount = totalCount, Lista = products };
        }

	}
}
