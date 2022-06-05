using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blog.Infrastructure.Models
{
    public class Author : Base
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

        [DefaultValue(false)]
        public bool IsDeleted { get; private set; } = false;
        public Author(string firstName, string lastName, int age, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
        }
        public Author( string id, string firstName, string lastName, int age, string email, bool isDeleted = false )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            IsDeleted = isDeleted;
        }
    }
}
