using System.Collections.Generic;
using System.Threading.Tasks;

namespace POI.Data.Repositories.Management
{
    public interface IProvider<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
    }
}
