using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using System.Collections.Generic;

namespace blog.Infrastructure.Interfaces
{
    public interface IAuthor : IGenericInterface<Author, AuthorDto>
    {
        List<Author> GetAll();
        Author GetById( string id );
    }
}
