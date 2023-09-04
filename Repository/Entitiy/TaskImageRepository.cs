using Model;
using Repository.Interface;

namespace Repository.Entitiy
{
    public class TaskImageRepository : RepositoryBase<TaskImage>, ITaskImageRepository
    {
        public TaskImageRepository(JiraBoardDbContext dbContext) : base(dbContext)
        {
        }
    }
}
