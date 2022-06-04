using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace blog.Controllers
{
    [ApiController]
    [Route("api/v1/comment")]
    public class CommentController : Controller
    {

        private IComment _repository;
        public CommentController( IComment repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Create new comment", Description = "Add new comment an article")]

        public ActionResult Add( [FromBody] CommentDto comment )
        {
            var newArticle = _repository.Add(comment);
            return Ok(newArticle);
        }

        [HttpPut]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Update an comment", Description = "Select comment by ID to update")]

        public ActionResult Update( string id, CommentDto comment )
        {
            var updated = _repository.Edit(id, comment);
            return Ok(updated);
        }


        [HttpDelete]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Flag to deleted", Description = "Set commentary with a flag to deleted")]

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
