using API.Contexts;
using API.Models;

namespace API.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(StoreContext context) : base(context)
        {
        }
    }

}
