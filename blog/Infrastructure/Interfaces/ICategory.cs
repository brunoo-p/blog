using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using System.Collections.Generic;

namespace blog.Infrastructure.Interfaces
{
    public interface ICategory : IGenericInterface<Category, CategoryDto>
    {
        List<Category> GetAll();
        List<Article> GetAllArticleByCategory( string name );
    }
}
