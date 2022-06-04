using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using System.Collections.Generic;

namespace blog.Infrastructure.Interfaces
{
    public interface IArticle : IGenericInterface<Article, ArticleDto>
    {
        List<Article> GetAll();
        Article GetById( string id );

        Article UpdateCategoryName( string id, CategoryDto categoryName );
    }
}
