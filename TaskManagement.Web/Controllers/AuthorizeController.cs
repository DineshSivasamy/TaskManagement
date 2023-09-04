using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaskManagement.Web.Controllers
{
    
    //[Authorize]
    [AllowAnonymous]
    public abstract class AuthorizeController : BaseController
    {
        private readonly ILogger _logger;
        public AuthorizeController(ILogger<AuthorizeController> logger) : base(logger)
        {
            _logger = logger;
        }
        
    }
}