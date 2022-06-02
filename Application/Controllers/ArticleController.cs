using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace blog.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ArticleController : ControllerBase
    {

        private IArticle _repository;

        public ArticleController( IArticle repository )
        {
            _repository = repository;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "List all articles", Description = "Get all articles registered on the database")]
        public ActionResult GetAll()
        {
            string name = _repository.GetAll();
            return Ok(name);
        }
    }
}
