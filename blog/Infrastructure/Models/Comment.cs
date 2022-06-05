using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blog.Infrastructure.Models
{
    public class Comment : Base
    {
        [BsonRequired]
        [Required]
        public string ArticleId { get; set; }

        [BsonRequired]
        [Required]
        public string Text { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; private set; } = false;

        public Comment(string articleId, string text)
        {
            ArticleId = articleId;
            Text = text;
        }
    }
}
