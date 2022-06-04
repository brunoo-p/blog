using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace blog.Infrastructure.Models.Dtos
{
    public class CommentDto
    {
        [BsonRequired]
        [Required]
        public string ArticleId { get; set; }

        [BsonRequired]
        [Required]
        public string Text { get; set; }

        public CommentDto( string articleId, string text )
        {
            ArticleId = articleId;
            Text = text;
        }
    }
}
