using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.tests.Mocks
{
    internal class CommentMock
    {
        public static CommentDto ObjectDTO()
        {
            return new CommentDto(
                 articleId: "987-654-321",
                text: "lorem ipsum dolor"
            );
        }
        public static Comment ObjectClass( CommentDto comment )
        {
            return new Comment(
                articleId: comment.ArticleId,
                text: comment.Text
            );
        }

        public static CommentDto NewCommentToEdit()
        {
            return new CommentDto(
                articleId: "987-654-321",
                text: "very well"
            );
        }
    }
}
