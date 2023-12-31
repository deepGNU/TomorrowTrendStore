using API.Models;

namespace API.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User? GetAuthenticatedUser(LoginInfo loginInfo);
    }

}
