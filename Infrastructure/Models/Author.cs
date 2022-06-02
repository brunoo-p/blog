using System.ComponentModel.DataAnnotations;

namespace blog.Infrastructure.Models
{
    public class Author : Base
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsDeleted { get; set; } = false;

        public Author(string firstName, string lastName, int age, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
        }

        public void Exclude() { IsDeleted = true; }
    }
}
