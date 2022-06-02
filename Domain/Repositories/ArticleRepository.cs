using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using System.Threading.Tasks;

namespace blog.Domain.Repositories
{
    public class ArticleRepository : IArticle
    {
        
        public string GetAll()
        {
            return "Bruno Paulino";
        }
        public async Task<Article> Add( Article entity )
        {
            throw new System.NotImplementedException();
        }

        public bool Delete( string id )
        {
            throw new System.NotImplementedException();
        }

        public async Task<Article> Edit( string id, Article entity )
        {
            throw new System.NotImplementedException();
        }

        public async Task<Article> GetById( string id )
        {
            throw new System.NotImplementedException();
        }
    }
}
