using blog.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace blog.Infrastructure.Interfaces
{
    public interface IGenericInterface<T>
    {
        Task<T> Add( T entity );
        Task<T> Edit(string id, T entity);
        Task<T> GetById(string id);
        bool Delete(string id);

    }
}
