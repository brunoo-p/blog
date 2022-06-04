using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;

namespace blog.Infrastructure.Interfaces
{
    public interface IComment : IGenericInterface<Comment, CommentDto>
    {
        
    }
}
