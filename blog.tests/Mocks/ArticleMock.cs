using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.tests.Mocks
{
    internal class ArticleMock
    {
        public static ArticleDto ObjectDTO()
        {
            return new ArticleDto(
                authorId: "123-456-789",
                title: "Title fake article",
                description: "Decription",
                text: "Lorem ipsum dolor"
            );
        }
        public static Article ObjectClass( ArticleDto article )
        {
            return new Article(
                article.AuthorId,
                article.Title,
                article.Description,
                article.Text,
                article.CategoryName
            );
        }

        public static ArticleDto NewArticleToEdit()
        {
            return new ArticleDto(
                authorId: "123-456-789",
                title: "Other itle",
                description: "Bla bla bla",
                text: "many words many words"
            );
        }

        public static List<Article> ListArticles()
        {
            return new List<Article>() {
                ObjectClass(ObjectDTO()),
                ObjectClass(ObjectDTO()),
                ObjectClass(ObjectDTO()),
                ObjectClass(ObjectDTO()),
            };
        }
    }
}
