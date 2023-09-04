using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entitiy
{
    public class UserFavoriteJiraTaskRepository : RepositoryBase<UserFavoriteJiraTask>, IUserFavoriteJiraTaskRepository
    {
        public UserFavoriteJiraTaskRepository(JiraBoardDbContext dbContext) : base(dbContext)
        {
        }
    }
}
