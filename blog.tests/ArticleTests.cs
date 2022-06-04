using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using blog.tests.Mocks;
using Moq;

namespace blog.tests
{
    public class ArticleTests
    {
        private readonly Mock<IArticle> _repositoryMock;
        private readonly string id = "00000000009";

        public ArticleTests()
        {
            _repositoryMock = new Mock<IArticle>();
        }

        [Fact(DisplayName = "Should be return the new article registered")]
        public void AddNewArticle()
        {
            var article = ArticleMock.ObjectDTO();
            var articleReturned = ArticleMock.ObjectClass(article);
            _repositoryMock.Setup(_ => _.Add(article)).Returns(articleReturned);

            var expected = _repositoryMock.Object.Add(article);

            Assert.NotNull(expected);
            Assert.IsNotType<ArticleDto>(expected);
            Assert.IsType<Article>(expected);

        }

        [Fact(DisplayName = "Should be return empty if not found article registered")]
        public void GetEmpty_IfNotFoundArticle()
        {
            var articleEmptyList = new List<Article>();
            _repositoryMock.Setup(_ => _.GetAll()).Returns(articleEmptyList);

            var expected = _repositoryMock.Object.GetAll();

            Assert.NotNull(expected);
            Assert.Empty(expected);
            Assert.IsNotType<Article>(expected);
            Assert.IsType<List<Article>>(expected);
        }

        [Fact(DisplayName = "Should be return a list with all article registered")]
        public void GetList_WithArticles()
        {
            var articleList = ArticleMock.ListArticles();
            _repositoryMock.Setup(_ => _.GetAll()).Returns(articleList);

            var expected = _repositoryMock.Object.GetAll();

            Assert.NotNull(expected);
            Assert.NotEmpty(expected);
            Assert.IsNotType<Article>(expected);
            Assert.IsNotType<List<ArticleDto>>(expected);
            Assert.IsType<List<Article>>(expected);
        }

        [Fact(DisplayName = "Should be return true if is set flag deleted in article")]
        public void ExcludeArticle()
        {
            _repositoryMock.Setup(_ => _.Delete(id)).Returns(true);

            var expected = _repositoryMock.Object.Delete(id);

            Assert.IsType<Boolean>(expected);
            Assert.True(expected);
        }

        [Fact(DisplayName = "Should be edit the article")]
        public void EditArticle()
        {
            var newArticle = ArticleMock.NewArticleToEdit();
            var articleReturned = ArticleMock.ObjectClass(newArticle);
            _repositoryMock.Setup(_ => _.Edit(id, newArticle)).Returns(articleReturned);

            var expected = _repositoryMock.Object.Edit(id, newArticle);

            Assert.NotNull(expected);
            Assert.IsType<Article>(expected);
            Assert.Same(articleReturned, expected);
            Assert.True(expected.Equals(articleReturned));
        }

        [Fact(DisplayName = "Should be update category to article")]
        public void EditTheCategoryOnArticle()
        {
            var article = ArticleMock.ObjectDTO();
            var articleReturned = ArticleMock.ObjectClass(article);
            var newCategory = CategoryMock.ObjectDTO();
            _repositoryMock.Setup(_ => _.UpdateCategoryName(id, newCategory)).Returns(articleReturned);

            var expected = _repositoryMock.Object.UpdateCategoryName(id, newCategory);

            Assert.NotNull(expected);
            Assert.IsType<Article>(expected);
        }


        [Fact(DisplayName = "Should be return an article")]
        public void GetById()
        {
            string id = "00000000009";
            var article = ArticleMock.ObjectDTO();
            var mockArticleReturned = ArticleMock.ObjectClass(article);
            _repositoryMock.Setup(_ => _.GetById(id)).Returns(mockArticleReturned);

            var expected = _repositoryMock.Object.GetById(id);

            Assert.NotNull(expected);
            Assert.IsType<Article>(expected);
            Assert.True(expected.Equals(mockArticleReturned));
        }
    }
}
