using API.Contexts;
using API.Models;

namespace API.Repositories
{
    public class OrderLineRepository : RepositoryBase<OrderLine>, IOrderLineRepository
    {
        public OrderLineRepository(StoreContext context) : base(context)
        {
        }
    }

}
