using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace blog.Controllers
{
    [ApiController]
    [Route("api/v1/author")]
    public class AuthorController : Controller
    {

        private IAuthor _repository;
        public AuthorController(IAuthor repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "List all authors", Description = "Get all authors registered on the database")]

        public ActionResult GetAll()
        {
            var list = _repository.GetAll();
            if ( list == null )
            {
                return Ok("First you need register an author");
            }
            return Ok(list);
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Find author by ID", Description = "Get author searching by ID")]
        [ProducesResponseType(typeof(AuthorDto), 200)]
        [ProducesResponseType(500)]

        public ActionResult GetById( string id )
        {
            var author = _repository.GetById(id);
            if ( author == null )
            {
                return StatusCode(404, "Not Found author");
            }

            return Ok(author);
        }

        [HttpPost]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Create new author", Description = "Add new author to database")]

        public ActionResult Add( [FromBody] AuthorDto author )
        {
            var newAuthor = _repository.Add(author);
            return Ok(newAuthor);
        }

        [HttpPut]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Update an author", Description = "Select author by ID to update")]

        public ActionResult Update( string id, AuthorDto author )
        {
            var updated = _repository.Edit(id, author);
            return Ok(updated);
        }


        [HttpDelete]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Flag to deleted", Description = "Set author with a flag to deleted")]

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
