using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blog.Infrastructure.Models
{
    public class Category : Base
    {
        [BsonRequired]
        [Required]
        public string Name { get; set; }

        [BsonRequired]
        [Required]
        public string Type { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; private set; } = false;

        public Category( string name, string type )
        {
            Name = name;
            Type = type;
        }

        public void Exclude() { IsDeleted = true; }
    }
}
