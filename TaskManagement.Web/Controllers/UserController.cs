using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Services.Interface;

namespace TaskManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : AuthorizeController
    {
        private readonly ILogger _logger;
        private readonly IUserService Userservice;
        private readonly IUserFavoriteJiraTaskService UserFavTaskservice;
        public UserController(ILogger<UserController> logger, IUserService userService, IUserFavoriteJiraTaskService userFavTaskservice) : base(logger)
        {
            _logger = logger;
            Userservice = userService;
            UserFavTaskservice = userFavTaskservice;
        }
        
        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Userservice.GetAllUser());
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            return Ok(Userservice.Get(id));
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var result = Userservice.Create(user);

                if (result != null)
                    return Created(result.Id.ToString(), result);
                _logger.LogError($"Failed to create user with db insertion returning null");
            }
            _logger.LogError($"Failed to create user {user.UserName}, as model state validation failed with {ModelState.Values}");
            return BadRequest("Failed to create new User record");
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] User updateUser)
        {
            if (ModelState.IsValid)
            {
                var result = Userservice.Update(id, updateUser);

                if (result != null)
                    return Ok(result);
                _logger.LogError($"Failed to update user {id} with db insertion returning null");
            }
            _logger.LogError($"Failed to create user {id}, as model state validation failed with {ModelState.Values}");
            return BadRequest("Failed to update User record");
        }

        
        [Route("api/user/{id}/AssignFavoriteJira/{taskId}")]
        [HttpPut]
        public IActionResult AssignFavoriteJira(Guid id, Guid taskId)
        {
            var result = UserFavTaskservice.Create(id, taskId);
            if (result != null)
            {
                return Ok(result);                
            }
            _logger.LogError($"Failed to assign fav task {taskId} to user {id}, as one of the detail is not available in the system");
            return BadRequest("Failed to assign Favorite task for User");
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = Userservice.Delete(id);

            if (result)
            {                
                return Ok("Successfully deleted user record");
            }
            _logger.LogError($"Failed to delete user with id {id}");
            return BadRequest("Failed to delete User record");
        }
    }
}
