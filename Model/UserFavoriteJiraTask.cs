using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class UserFavoriteJiraTask: BaseEntity
    {
        public User User { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public JiraTask Task { get; set; }
        [ForeignKey("JiraTask")]
        public Guid TaskId { get; set; }
    }
}
