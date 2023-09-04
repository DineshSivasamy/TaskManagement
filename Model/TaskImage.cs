using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class TaskImage : BaseEntity
    {
        public Guid TaskId { get; set; }
        public JiraTask Task { get; set; }
        public string ImageTitle { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
