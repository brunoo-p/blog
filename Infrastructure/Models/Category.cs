using System.ComponentModel.DataAnnotations;

namespace blog.Infrastructure.Models
{
    public class Category : Base
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        public bool IsDeleted { get; private set; } = false;

        public Category( string name, string type )
        {
            Name = name;
            Type = type;
        }

        public void Exclude() { IsDeleted = true; }
    }
}
