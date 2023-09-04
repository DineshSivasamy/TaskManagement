using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace TaskManagement.Web.Filters
{
    public class HandleExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger _logger;
        
        public HandleExceptionFilter(ILogger<HandleExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {

            _logger.LogCritical(context.Exception, $"Caught Unhandled Exception in application for request: {context.HttpContext.Request.Path.Value}");
            //if (!_hostingEnvironment.IsDevelopment())
            //{
            //    return;
            //}
            //var result = new ViewResult { ViewName = "CustomError" };
            //result.ViewData = new ViewDataDictionary(_modelMetadataProvider,
            //                                            context.ModelState);
            //result.ViewData.Add("Exception", context.Exception);
            //// TODO: Pass additional detailed data via ViewData
            //context.Result = result;
        }
    }
}
