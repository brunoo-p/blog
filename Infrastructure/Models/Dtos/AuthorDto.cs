using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace blog.Infrastructure.Models.Dtos
{
    public class AuthorDto
    {
        [BsonRequired]
        [Required]
        public string FirstName { get; set; }

        [BsonRequired]
        [Required]
        public string LastName { get; set; }

        [BsonRequired]
        [Required]
        public int Age { get; set; }

        [BsonRequired]
        [Required]
        public string Email { get; set; }

        public AuthorDto( string firstName, string lastName, int age, string email )
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
        }
    }
}
