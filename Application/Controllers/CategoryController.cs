using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : Controller
    {

        private IGenericInterface<Category> _reposittory;

        public CategoryController( IGenericInterface<Category> repository)
        {
            _reposittory = repository;
        }


        [HttpGet]
        public ActionResult Index()
        {
            return Ok("OK");
        }
    }
}
