using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace blog.Infrastructure.Models
{
    public class Article : Base
    {
        [BsonRequired]
        [Required]
        public string AuthorId { get; set; }

        [BsonRequired]
        [Required]
        public string Title { get; set; }

        [BsonRequired]
        [Required]
        public string Description { get; set; }

        [BsonRequired]
        [Required]
        public string Text { get; set; }

        public string CategoryName { get; set; } = null;

        public List<Comment> Comments { get; set; } = null;

        public bool IsDeleted { get; set; } = false;

        public Article( string authorId, string title, string description, string text, string categoryName = null)
        {
            AuthorId = authorId;
            Title = title;
            Description = description;
            Text = text;
            CategoryName = categoryName;
        }
        public Article( string id, string authorId, string title, string description, string text, string categoryName = null, List<Comment> comments = null )
        {
            Id = id;
            AuthorId = authorId;
            Title = title;
            Description = description;
            Text = text;
            CategoryName = categoryName;
            Comments = comments;
        }
        public Article()
        {
      
        }
    }
}
