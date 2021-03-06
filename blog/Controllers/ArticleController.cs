using System.Collections.Generic;
using System.Net;
using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using blog.Models;
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
        [ProducesResponseType(typeof(List<Article>), 200)]

        public ActionResult GetAll()
        {
            var list = _repository.GetAll();
            return Ok(list);
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Find article by ID", Description = "Get article searching by ID")]
        [ProducesResponseType(typeof(MessageResponse), 403)]
        [ProducesResponseType(typeof(Article), 200)]

        public ActionResult GetById( string id )
        {
            var article = _repository.GetById(id);
            if ( article == null )
            {
                return StatusCode(403, MessageResponse.mapError(HttpStatusCode.Forbidden, "This article don't exist yet."));
            }

            return Ok(article);
        }

        [HttpPost]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Create new article", Description  = "Add new article to database")]
        [ProducesResponseType(typeof(MessageResponse), 400)]
        [ProducesResponseType(typeof(Article), 200)]

        public ActionResult Add([FromBody] ArticleDto article)
        {
            var newArticle = _repository.Add(article);
            
            if (newArticle == null) {
                return StatusCode(400, MessageResponse.mapError(HttpStatusCode.Forbidden, "Invalid authorId"));
            }

            return Ok(newArticle);
        }

        [HttpPut]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Update an article", Description = "Select article by ID to update")]
        [ProducesResponseType(typeof(Article), 200)]

        public ActionResult Update( string id, ArticleDto article )
        {
            var updated = _repository.Edit(id, article);
            if (updated == null) {
                return StatusCode(400, MessageResponse.mapError(HttpStatusCode.BadRequest, "Invalid Id"));
            }
            return Ok(updated);
        }

        [HttpPatch]
        [Route("{id}/updateCategory")]
        [SwaggerOperation(Summary = "Update the category", Description = "Update the article category")]
        [ProducesResponseType(typeof(Article), 200)]

        public ActionResult UpdateCategory( string id, [FromBody] CategoryDto categoryName)
        {
            var updated = _repository.UpdateCategoryName(id, categoryName);
            return Ok(updated);
        }


        [HttpDelete]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Flag to deleted", Description = "Set article with a flag to deleted")]
        [ProducesResponseType(typeof(bool), 200)]

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
