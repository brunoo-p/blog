using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthorController : Controller
    {

        private IGenericInterface<Author> _repository;
        public AuthorController(IGenericInterface<Author> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public ActionResult Index()
        {
            return Ok("OK");
        }
    }
}
