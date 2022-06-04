using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace blog.Infrastructure.Models.Dtos
{
    public class CategoryDto
    {
        [BsonRequired]
        [Required]
        public string Name { get; set; }

        [BsonRequired]
        [Required]
        public string Type { get; set; }

        public CategoryDto(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }
}
