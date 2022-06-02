using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using System.Threading.Tasks;

namespace blog.Domain.Repositories
{
    public class AuthorRepository : IGenericInterface<Author>
    {
        public async Task<Author> Add( Author entity )
        {
            throw new System.NotImplementedException();
        }

        public bool Delete( string id )
        {
            throw new System.NotImplementedException();
        }

        public async Task<Author> Edit( string id, Author entity )
        {
            throw new System.NotImplementedException();
        }

        public async Task<Author> GetById( string id )
        {
            throw new System.NotImplementedException();
        }
    }
}
