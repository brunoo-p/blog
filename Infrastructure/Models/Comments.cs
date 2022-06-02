using System.ComponentModel.DataAnnotations;

namespace blog.Infrastructure.Models
{
    public class Comments : Base
    {
        [Required]
        public string Text { get; set; }

        public bool IsDeleted { get; set; } = false;

        public Comments(string text)
        {
            Text = text;
        }

        public void Exclude() { IsDeleted = true; }
    }
}
