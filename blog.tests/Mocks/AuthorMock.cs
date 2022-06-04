using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;


namespace blog.tests.Mocks
{
    internal class AuthorMock
    {
        public static AuthorDto ObjectDTO()
        {
            return new AuthorDto(
                firstName: "Bruno",
                lastName: "Paulino",
                age: 25,
                email: "email@email.com"
            );
        }
        public static Author ObjectClass(AuthorDto author)
        {
            return new Author(
                firstName: author.FirstName,
                lastName: author.LastName,
                age: author.Age,
                email: author.Email
            );
        }

        public static AuthorDto NewAuthorToEdit()
        {
            return new AuthorDto(
                firstName: "John",
                lastName: "Doe",
                age: 43,
                email: "yahoo@yahoo.com"
            );
        }

        public static List<Author> ListAuthors()
        {
            return new List<Author>() {
                ObjectClass(ObjectDTO()),
                ObjectClass(ObjectDTO()),
                ObjectClass(ObjectDTO()),
                ObjectClass(ObjectDTO()),
            };
        }
    }
}
