using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class JiraTask :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public JiraStatus Status { get; set; }
        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public ICollection<TaskImage> Images { get; set; }
        public ICollection<UserFavoriteJiraTask> UserFavorites { get; set; }
    }
}
