using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace blog.Infrastructure.Models.Dtos
{
    public class ArticleDto
    {
        [BsonRequired]
        [Required]
        public string AuthorId { get; set; }

        [BsonRequired]
        [Required]
        public string Title{ get; set; }

        [BsonRequired]
        [Required]
        public string Description { get; set; }
        
        [BsonRequired]
        [Required]
        public string Text { get; set; }

        public string CategoryName { get; set; } = null;

        public ArticleDto(string authorId, string title, string description, string text)
        {
            AuthorId = authorId;
            Title = title;
            Description = description;
            Text = text;
        }
    }
}
