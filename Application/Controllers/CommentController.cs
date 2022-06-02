using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;


namespace blog.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CommentController : Controller
    {

        private IGenericInterface<Comment> _repository;
        public CommentController( IGenericInterface<Comment> repository)
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
