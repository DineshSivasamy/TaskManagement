using Model;
using Repository.Interface;

namespace Repository.Entitiy
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(JiraBoardDbContext dbContext) : base(dbContext)
        {
        }
    }
}
