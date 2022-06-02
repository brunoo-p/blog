using System.ComponentModel.DataAnnotations;

namespace blog.Infrastructure.Models
{
    public class Article : Base
    {
        [Required]
        public Author Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Text { get; set; }

        public Category Category { get; set; } = null;

        public Comment[] Comments { get; set; } = null;

        public bool IsDeleted { get; private set; } = false;

        public Article( Author author, string title, string description, string text, Category category = null, Comment[] comments = null)
        {
            Author = author;
            Title = title;
            Description = description;
            Text = text;
            Category = category;
            Comments = comments;
        }

        public void Exclude() { IsDeleted = true; }
    }
}
