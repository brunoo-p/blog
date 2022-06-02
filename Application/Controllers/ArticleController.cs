using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult GetAll()
        {
            string name = _repository.GetAll();
            return Ok(name);
        }
    }
}
