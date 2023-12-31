using API.Contexts;
using API.Models;

namespace API.Repositories
{
    public class ShopOrderRepository : RepositoryBase<ShopOrder>, IShopOrderRepository
    {
        public ShopOrderRepository(StoreContext context) : base(context)
        {
        }
    }

}
