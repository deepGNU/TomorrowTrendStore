using API.Contexts;
using API.Models;

namespace API.Repositories
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(StoreContext context) : base(context)
        {
        }
    }

}
