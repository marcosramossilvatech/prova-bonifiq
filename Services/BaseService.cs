using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class BaseService
    {
        private TestDbContext _ctx;

        public BaseService(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public BaseList<T> ListBase<T>(int page) where T : class
        {
            int totalItemsPerPage = 10;
            int skip = (page - 1) * totalItemsPerPage;
            var retorno = _ctx.Set<T>().Skip(skip).Take(totalItemsPerPage).ToList();
            var totalCount = _ctx.Set<T>().Count();

            var hasNext = (skip + retorno.Count) < totalCount;

            return new BaseList<T> { HasNext = hasNext, TotalCount = totalCount, Lista = retorno };
        }
    }
}
