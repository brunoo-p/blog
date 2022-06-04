using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace blog.Controllers
{
    [ApiController]
    [Route("api/v1/category")]
    public class CategoryController : Controller
    {

        private ICategory _repository;

        public CategoryController( ICategory repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "List all categories", Description = "Get all categories registered on the database")]

        public ActionResult GetAll()
        {
            var list = _repository.GetAll();
            if ( list == null )
            {
                return Ok("First you need register a category");
            }
            return Ok(list);
        }

        [HttpGet]
        [Route("listArticles/{nameCategory}")]
        [SwaggerOperation(Summary = "List all articles", Description = "Get all articles linked this category name")]

        public ActionResult GetAllArticle_WithCategoryName(string nameCategory)
        {
            var list = _repository.GetAllArticleByCategory(nameCategory);
            if ( list == null )
            {
                return Ok("First you need register a category");
            }
            return Ok(list);
        }


        [HttpPost]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Create new category", Description = "Add new category to database")]

        public ActionResult Add( [FromBody] CategoryDto category)
        {
            var newCategory= _repository.Add(category);
            return Ok(newCategory);
        }


        [HttpDelete]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Flag to delete", Description = "Set article with a flag to deleted")]

        public ActionResult FlagDelete( string id )
        {
            var deleted = _repository.Delete(id);

            if ( !deleted )
            {
                return StatusCode(500, "Error to exclude");
            }

            return Ok(deleted);
        }
    }
}
