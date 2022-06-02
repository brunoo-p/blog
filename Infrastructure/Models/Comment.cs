using System.ComponentModel.DataAnnotations;

namespace blog.Infrastructure.Models
{
    public class Comment : Base
    {
        [Required]
        public string Text { get; set; }

        public bool IsDeleted { get; private set; } = false;

        public Comment(string text)
        {
            Text = text;
        }

        public void Exclude() { IsDeleted = true; }
    }
}
