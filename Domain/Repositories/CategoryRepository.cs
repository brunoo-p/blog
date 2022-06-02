using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using System.Threading.Tasks;

namespace blog.Domain.Repositories
{
    public class CategoryRepository : IGenericInterface<Category>
    {
        public async Task<Category> Add( Category entity )
        {
            throw new System.NotImplementedException();
        }

        public bool Delete( string id )
        {
            throw new System.NotImplementedException();
        }

        public async Task<Category> Edit( string id, Category entity )
        {
            throw new System.NotImplementedException();
        }

        public async Task<Category> GetById( string id )
        {
            throw new System.NotImplementedException();
        }
    }
}
