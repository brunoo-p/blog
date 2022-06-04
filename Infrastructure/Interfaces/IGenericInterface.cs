using blog.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace blog.Infrastructure.Interfaces
{
    public interface IGenericInterface<T, R>
    {
        T Add( R entity );
        T Edit(string id, R entity);
        bool Delete(string id);

    }
}
