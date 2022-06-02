using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using System.Threading.Tasks;

namespace blog.Domain.Repositories
{
    public class CommentRepository : IGenericInterface<Comment>
    {
        public async Task<Comment> Add( Comment entity )
        {
            throw new System.NotImplementedException();
        }

        public bool Delete( string id )
        {
            throw new System.NotImplementedException();
        }

        public async Task<Comment> Edit( string id, Comment entity )
        {
            throw new System.NotImplementedException();
        }

        public async Task<Comment> GetById( string id )
        {
            throw new System.NotImplementedException();
        }
    }
}
