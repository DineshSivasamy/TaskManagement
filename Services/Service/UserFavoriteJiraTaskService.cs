using Microsoft.Extensions.Logging;
using Model;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Service
{
    public class UserFavoriteJiraTaskService : IUserFavoriteJiraTaskService
    {
        private readonly IRepositoryBase<UserFavoriteJiraTask> Repository;
        private readonly IRepositoryBase<User> UserRepository;
        private readonly IRepositoryBase<JiraTask> JiraRepository;
        private readonly ILogger _logger;

        public UserFavoriteJiraTaskService(IRepositoryBase<UserFavoriteJiraTask> repository, IRepositoryBase<User> userRepository, IRepositoryBase<JiraTask> jiraRepository,ILogger logger)
        {
            Repository = repository;
            UserRepository = userRepository;
            JiraRepository = jiraRepository;
            _logger = logger;
        }

        public UserFavoriteJiraTask Create(Guid userId, Guid favTaskId)
        {
            var user = UserRepository.Get(x => x.Id == userId);

            if(user != null)
            {
                var task = JiraRepository.Get(x => x.Id == favTaskId);

                if (task != null)
                {
                    var newRequest = new UserFavoriteJiraTask
                    {
                        UserId = userId,
                        TaskId = favTaskId
                    };
                    return Repository.Create(newRequest);
                }
                else
                {
                    _logger.LogError($"Not able to assign Jira with Id {favTaskId} as favorite for User with Id {userId}, since task Id is not available in system");
                }

            }
            else
            {
                _logger.LogError($"Not able to assign Jira with Id {favTaskId} as favorite for User with Id {userId}, since User Id is not available in system");
            }
            return null;
        }

        public bool Delete(UserFavoriteJiraTask userFavTask)
        {
            return Repository.Delete(userFavTask);
        }

        public IList<UserFavoriteJiraTask> GetByTaskId(Guid taskId)
        {
            var result = Repository.Get(x => x.TaskId == taskId);
            if(result != null && result.Count() > 0)
            {
                return result.ToList();
            }
            return new List<UserFavoriteJiraTask>();
        }

        public IList<UserFavoriteJiraTask> GetByUserId(Guid userid)
        {
            var result = Repository.Get(x => x.UserId == userid);
            if (result != null && result.Count() > 0)
            {
                return result.ToList();
            }
            return new List<UserFavoriteJiraTask>();
        }
    }
}
