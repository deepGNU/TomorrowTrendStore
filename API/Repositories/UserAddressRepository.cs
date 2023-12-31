using API.Contexts;
using API.Models;

namespace API.Repositories
{
    public class UserAddressRepository : RepositoryBase<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(StoreContext context) : base(context)
        {
        }
    }

}
