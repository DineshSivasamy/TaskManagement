using Model;
using Repository.Interface;

namespace Repository.Entitiy
{
    public class JiraTaskRepository : RepositoryBase<JiraTask>, IJiraTaskRepository
    {
        public JiraTaskRepository(JiraBoardDbContext dbContext) : base(dbContext)
        {
        }
    }
}
