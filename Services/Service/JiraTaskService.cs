using Model;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Service
{
    public class JiraTaskService : IJiraTaskService
    {
        private readonly IRepositoryBase<JiraTask> Repository;

        public JiraTaskService(IRepositoryBase<JiraTask> repositoryBase)
        {
            Repository = repositoryBase;
        }

        public JiraTask Create(JiraTask jiraTask)
        {            
            return Repository.Create(jiraTask);
        }

        public bool Delete(Guid id)
        {
            var task = Get(id);

            if (task != null)
            {
                var result = Repository.Delete(task);
                return result;
            }
            return false;
        }

        public JiraTask Get(Guid id)
        {
            var result = Repository.Get(x => x.Id == id);
            return result.FirstOrDefault();
        }

        public IList<JiraTask> GetAllJiraTask()
        {
            return Repository.GetAll().ToList();
        }

        public JiraTask Update(Guid id, JiraTask jiraTask)
        {
            var task = Get(id);
            if (task != null)
            {
                var result = Repository.Update(jiraTask);
                return result;
            }
            return null;
        }
    }
}
