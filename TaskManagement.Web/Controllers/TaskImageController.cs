using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Services.Interface;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace TaskManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskImageController : AuthorizeController
    {
        private readonly ILogger _logger;
        private readonly ITaskImageService TaskImageService;
        private readonly IHostingEnvironment _hostEnvironment;
        public TaskImageController(ILogger<TaskImageController> logger, ITaskImageService taskImageService, IHostingEnvironment hostEnvironment) : base(logger)
        {
            _logger = logger;
            TaskImageService = taskImageService;
            _hostEnvironment = hostEnvironment;
        }

        // GET: api/TaskImage/taskid
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid taskId)
        {
            return Ok(TaskImageService.GetAllTaskImages(taskId).ToList());
        }

        // POST: api/TaskImage
        [HttpPost]
        public IActionResult Post([FromBody] TaskImage taskImage)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(taskImage.ImageName);
            string extension = Path.GetExtension(taskImage.ImageName);
            taskImage.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Image/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                taskImage.ImageFile.CopyToAsync(fileStream);
            }

            var result = TaskImageService.Create(taskImage);

            if (result != null)
                return Created(result.Id.ToString(), result);
            else
                return BadRequest("Failed to create new task image record");
        }
    }
}
