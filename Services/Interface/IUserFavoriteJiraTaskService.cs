using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
    public interface IUserFavoriteJiraTaskService
    {
        IList<UserFavoriteJiraTask> GetByUserId(Guid userid);
        IList<UserFavoriteJiraTask> GetByTaskId(Guid taskId);
        UserFavoriteJiraTask Create(Guid userId, Guid facTaskId);
        bool Delete(UserFavoriteJiraTask userFavTask);
    }
}
