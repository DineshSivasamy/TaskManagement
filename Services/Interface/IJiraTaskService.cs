using Model;
using System;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface IJiraTaskService 
    {
        IList<JiraTask> GetAllJiraTask();

        JiraTask Get(Guid id);

        JiraTask Create(JiraTask jiraTask);

        JiraTask Update(Guid id, JiraTask jiraTask);

        bool Delete(Guid id);
    }
}
