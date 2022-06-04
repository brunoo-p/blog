using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace blog.Controllers
{
    [ApiController]
    [Route("api/v1/article")]
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
            var list = _repository.GetAll();
            if (list == null) {
                return Ok("First you need register an article");
            }
            return Ok(list);
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Find article by ID", Description = "Get article searching by ID")]

        public ActionResult GetById( string id )
        {
            var article = _repository.GetById(id);
            if ( article == null )
            {
                return StatusCode(404, "Not Found article");
            }

            return Ok(article);
        }

        [HttpPost]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Create new article", Description  = "Add new article to database")]

        public ActionResult Add([FromBody] ArticleDto article)
        {
            var newArticle = _repository.Add(article);
            return Ok(newArticle);
        }

        [HttpPut]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Update an article", Description = "Select article by ID to update")]

        public ActionResult Update( string id, ArticleDto article )
        {
            var updated = _repository.Edit(id, article);
            return Ok(updated);
        }

        [HttpPut]
        [Route("{id}/updateCategory")]
        [SwaggerOperation(Summary = "Update the category", Description = "Update the article category")]

        public ActionResult UpdateCategory( string id, [FromBody] CategoryDto categoryName)
        {
            var updated = _repository.UpdateCategoryName(id, categoryName);
            return Ok(updated);
        }


        [HttpDelete]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Flag to deleted", Description = "Set article with a flag to deleted")]

        public ActionResult FlagDelete( string id )
        {
            var deleted = _repository.Delete(id);

            if (!deleted) {
                return StatusCode(500, "Error to exclude");
            }

            return Ok(deleted);
        }
    }
}
