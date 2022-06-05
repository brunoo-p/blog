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
        [ProducesResponseType(typeof(MessageResponse), 400)]
        [ProducesResponseType(typeof(Comment), 200)]

        public ActionResult Add( [FromBody] CommentDto comment )
        {
            var newArticle = _repository.Add(comment);
            if (newArticle == null) {
                return StatusCode(400, MessageResponse.mapError(HttpStatusCode.Forbidden, "Invalid authorId"));
            }
            
            return Ok(newArticle);
        }

        [HttpPut]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Update an comment", Description = "Select comment by ID to update")]
        [ProducesResponseType(typeof(MessageResponse), 400)]
        [ProducesResponseType(typeof(Comment), 200)]
        
        public ActionResult Update( string id, CommentDto comment )
        {
            var updated = _repository.Edit(id, comment);
            if (updated == null) {
                return StatusCode(400, MessageResponse.mapError(HttpStatusCode.BadRequest, "Invalid Id"));
            }
            return Ok(updated);
        }


        [HttpDelete]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Flag to deleted", Description = "Set commentary with a flag to deleted")]
         [ProducesResponseType(typeof(bool), 200)]

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
