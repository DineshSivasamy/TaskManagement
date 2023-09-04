using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Services.Interface;

namespace TaskManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JiraTaskController : AuthorizeController
    {
        private readonly ILogger _logger;
        private readonly IJiraTaskService Taskservice;
        public JiraTaskController(ILogger<JiraTaskController> logger, IJiraTaskService taskservice) : base(logger)
        {
            _logger = logger;
            Taskservice = taskservice;
        }


        // GET: api/JiraTask
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Taskservice.GetAllJiraTask());
        }

        // GET: api/JiraTask/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            return Ok(Taskservice.Get(id));
        }

        // POST: api/JiraTask
        [HttpPost]
        public IActionResult Post([FromBody] JiraTask newTask)
        {
            var result = Taskservice.Create(newTask);

            if (result != null)
                return Created(result.Id.ToString(), result);
            else
                return BadRequest("Failed to create new task record");
        }

        // PUT: api/JiraTask/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] JiraTask updateTask)
        {
            var result = Taskservice.Update(id, updateTask);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Failed to Update Task, as the task id is not present");
        }

        // DELETE: api/JiraTask/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = Taskservice.Delete(id);

            if (result)
            {                
                return Ok("Deleted Task successfully");
            }
            return BadRequest("Failed to Update Task, as the task id is not present");
        }
    }
}
