using blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Controllers
{
    [ApiController]
    [Route("api/v1/{controller}")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Ok("OK");
        }
    }
}
