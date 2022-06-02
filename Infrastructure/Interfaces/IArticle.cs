using blog.Infrastructure.Models;

namespace blog.Infrastructure.Interfaces
{
    public interface IArticle : IGenericInterface<Article>
    {
        string GetAll();
    }
}
