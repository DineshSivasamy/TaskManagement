using TaskManagement.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace TaskManagement.Web.Controllers
{

    [TypeFilter(typeof(HandleExceptionFilter))]    
    public abstract class BaseController : Controller
    {
        private readonly ILogger _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            _logger.LogInformation($"Entering into controller/method: {context.HttpContext.Request.Path.Value}");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            _logger.LogInformation($"Exiting from controller/method: {context.HttpContext.Request.Path.Value} with response {context.HttpContext.Response.StatusCode}");
        }
    }
    }