using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class User :BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public ICollection<UserFavoriteJiraTask> FavoriteTasks { get; set; }
    }
}
