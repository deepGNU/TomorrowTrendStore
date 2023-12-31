using API.Contexts;
using API.Models;
using API.Services;

namespace API.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(StoreContext context) : base(context)
        {
        }

        public User? GetAuthenticatedUser(LoginInfo loginInfo)
        {
            User? user = FindByCondition(u => u.Username == loginInfo.Username).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            if (!PasswordHashingService.VerifyPassword(loginInfo.Password, user.PasswordHash))
            {
                return null;
            }

            return user;
        }
    }

}
