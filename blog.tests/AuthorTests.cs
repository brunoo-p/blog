using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using blog.tests.Mocks;
using Moq;

namespace blog.tests
{
    public class AuthorTests
    {

        private readonly Mock<IAuthor> _repositoryMock;
        private readonly string id = "00000000009";

        public AuthorTests()
        {
            _repositoryMock = new Mock<IAuthor>();
        }
        
        [Fact(DisplayName = "Should be return the new author registered")]
        public void AddNewAuthor()
        {
            var author = AuthorMock.ObjectDTO();
            var authorReturned = AuthorMock.ObjectClass(author);
            _repositoryMock.Setup(_ => _.Add(author)).Returns(authorReturned);

            var expected = _repositoryMock.Object.Add(author);

            Assert.NotNull(expected);
            Assert.IsNotType<AuthorDto>(expected);
            Assert.IsType<Author>(expected);

        }

        [Fact(DisplayName = "Should be return empty if not found author registered")]
        public void GetEmpty_IfNotFoundAuthors()
        {
            var authorsEmptyList = new List<Author>();
            _repositoryMock.Setup(_ => _.GetAll()).Returns(authorsEmptyList);

            var expected = _repositoryMock.Object.GetAll();

            Assert.NotNull(expected);
            Assert.Empty(expected);
            Assert.IsNotType<Author>(expected);
            Assert.IsType<List<Author>>(expected);
        }

        [Fact(DisplayName = "Should be return a list with all authors registered")]
        public void GetList_WithAuthors()
        {
            var authorsList = AuthorMock.ListAuthors();
            _repositoryMock.Setup(_ => _.GetAll()).Returns(authorsList);

            var expected = _repositoryMock.Object.GetAll();

            Assert.NotNull(expected);
            Assert.NotEmpty(expected);
            Assert.IsNotType<Author>(expected);
            Assert.IsNotType<List<AuthorDto>>(expected);
            Assert.IsType<List<Author>>(expected);
        }

        [Fact(DisplayName = "Should be return true if is set flag deleted in author")]
        public void ExcludeAuthor()
        {
            _repositoryMock.Setup(_ => _.Delete(id)).Returns(true);

            var expected = _repositoryMock.Object.Delete(id);

            Assert.IsType<Boolean>(expected);
            Assert.True(expected);
        }


        [Fact(DisplayName = "Should be edit the author")]
        public void EditAuthor()
        {
            var newAuthor = AuthorMock.NewAuthorToEdit();
            var authorReturned = AuthorMock.ObjectClass(newAuthor);
            _repositoryMock.Setup(_ => _.Edit(id, newAuthor)).Returns(authorReturned);

            var expected = _repositoryMock.Object.Edit(id, newAuthor);

            Assert.NotNull(expected);
            Assert.IsType<Author>(expected);
            Assert.Same(authorReturned, expected);
            Assert.True(expected.Equals(authorReturned));
        }

        [Fact(DisplayName = "Should be return an author")]
        public void GetById()
        {
            var author = AuthorMock.ObjectDTO();
            var mockAuthorReturned = AuthorMock.ObjectClass(author);
            _repositoryMock.Setup(_ => _.GetById(id)).Returns(mockAuthorReturned);

            var expected = _repositoryMock.Object.GetById(id);

            Assert.NotNull(expected);
            Assert.IsType<Author>(expected);
            Assert.True(expected.Equals(mockAuthorReturned));
        }
    }
}