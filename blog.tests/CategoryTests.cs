using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using blog.tests.Mocks;
using Moq;

namespace blog.tests
{
    public class CategoryTests
    {
        private readonly Mock<ICategory> _repositoryMock;
        private readonly string id = "00000000009";

        public CategoryTests()
        {
            _repositoryMock = new Mock<ICategory>();
        }

        [Fact(DisplayName = "Should be return the new category registered")]
        public void AddNewCategory()
        {
            var category = CategoryMock.ObjectDTO();
            var categoryReturned = CategoryMock.ObjectClass(category);
            _repositoryMock.Setup(_ => _.Add(category)).Returns(categoryReturned);

            var expected = _repositoryMock.Object.Add(category);

            Assert.NotNull(expected);
            Assert.IsNotType<CategoryDto>(expected);
            Assert.IsType<Category>(expected);

        }

        [Fact(DisplayName = "Should be return empty if not found category registered")]
        public void GetEmpty_IfNotFoundCategory()
        {
            var categoryEmptyList = new List<Category>();
            _repositoryMock.Setup(_ => _.GetAll()).Returns(categoryEmptyList);

            var expected = _repositoryMock.Object.GetAll();

            Assert.NotNull(expected);
            Assert.Empty(expected);
            Assert.IsNotType<Category>(expected);
            Assert.IsType<List<Category>>(expected);
        }

        [Fact(DisplayName = "Should be return a list with all categories registered")]
        public void GetList_WithCategories()
        {
            var categoryList = CategoryMock.ListCategories();
            _repositoryMock.Setup(_ => _.GetAll()).Returns(categoryList);

            var expected = _repositoryMock.Object.GetAll();

            Assert.NotNull(expected);
            Assert.NotEmpty(expected);
            Assert.IsNotType<Category>(expected);
            Assert.IsNotType<List<CategoryDto>>(expected);
            Assert.IsType<List<Category>>(expected);
        }

        [Fact(DisplayName = "Should be return true if is set flag deleted on category")]
        public void ExcludeCategory()
        {
            _repositoryMock.Setup(_ => _.Delete(id)).Returns(true);

            var expected = _repositoryMock.Object.Delete(id);

            Assert.IsType<Boolean>(expected);
            Assert.True(expected);
        }

        [Fact(DisplayName = "Should be edit the category")]
        public void EditCategory()
        {
            var newCategory = CategoryMock.NewCategoryToEdit();
            var categoryReturned = CategoryMock.ObjectClass(newCategory);
            _repositoryMock.Setup(_ => _.Edit(id, newCategory)).Returns(categoryReturned);

            var expected = _repositoryMock.Object.Edit(id, newCategory);

            Assert.NotNull(expected);
            Assert.IsType<Category>(expected);
            Assert.Same(categoryReturned, expected);
            Assert.True(expected.Equals(categoryReturned));
        }


        [Fact(DisplayName = "Should be return a empty array")]
        public void GetEmptyArrayByCategory()
        {
            string categoryName = "anything";
            var listArticleReturned = new List<Article>();
            _repositoryMock.Setup(_ => _.GetAllArticleByCategory(categoryName)).Returns(listArticleReturned);

            var expected = _repositoryMock.Object.GetAllArticleByCategory(categoryName);

            Assert.NotNull(expected);
            Assert.Empty(expected);
            Assert.IsType<List<Article>>(expected);
            Assert.True(expected.Equals(listArticleReturned));
        }


        [Fact(DisplayName = "Should be return a list with all articles linked this category")]
        public void GetAllArticleByCategory()
        {
            string categoryName = "crime";
            var listArticleReturned = ArticleMock.ListArticles();
            _repositoryMock.Setup(_ => _.GetAllArticleByCategory(categoryName)).Returns(listArticleReturned);

            var expected = _repositoryMock.Object.GetAllArticleByCategory(categoryName);

            Assert.NotNull(expected);
            Assert.NotEmpty(expected);
            Assert.IsType<List<Article>>(expected);
            Assert.True(expected.Equals(listArticleReturned));
        }
    }
}
