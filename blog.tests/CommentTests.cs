using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using blog.tests.Mocks;
using Moq;

namespace blog.tests
{
    public class CommentTests
    {
        private readonly Mock<IComment> _repositoryMock;
        private readonly string id = "00000000009";

        public CommentTests()
        {
            _repositoryMock = new Mock<IComment>();
        }

        [Fact(DisplayName = "Should be return the new comment registered")]
        public void AddNewComment()
        {
            var comment = CommentMock.ObjectDTO();
            var commentReturned = CommentMock.ObjectClass(comment);
            _repositoryMock.Setup(_ => _.Add(comment)).Returns(commentReturned);

            var expected = _repositoryMock.Object.Add(comment);

            Assert.NotNull(expected);
            Assert.IsNotType<CommentDto>(expected);
            Assert.IsType<Comment>(expected);

        }

        [Fact(DisplayName = "Should be return true if is set flag deleted on comment")]
        public void ExcludeComment()
        {
            _repositoryMock.Setup(_ => _.Delete(id)).Returns(true);

            var expected = _repositoryMock.Object.Delete(id);

            Assert.IsType<Boolean>(expected);
            Assert.True(expected);
        }


        [Fact(DisplayName = "Should be edit the comment")]
        public void EditComment()
        {
            var newComment= CommentMock.NewCommentToEdit();
            var commentReturned = CommentMock.ObjectClass(newComment);
            _repositoryMock.Setup(_ => _.Edit(id, newComment)).Returns(commentReturned);

            var expected = _repositoryMock.Object.Edit(id, newComment);

            Assert.NotNull(expected);
            Assert.IsType<Comment>(expected);
            Assert.Same(commentReturned, expected);
            Assert.True(expected.Equals(commentReturned));
        }
    }
}
