using API.Contexts;
using API.Models;

namespace API.Repositories
{
    public class UserReviewRepository : RepositoryBase<UserReview>, IUserReviewRepository
    {
        public UserReviewRepository(StoreContext context) : base(context)
        {
        }
    }

}
