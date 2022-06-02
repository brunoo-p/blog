using System.ComponentModel.DataAnnotations;

namespace blog.Infrastructure.Models
{
    public class Base
    {
        [Required]
        public string Id { get; set; }
    }
}
