using System.Threading.Tasks;

namespace POI.Data.Repositories.Management
{
    public interface IProcessor<T>
    {
        Task<T> Create(T item);
        Task Update(T item);
        Task Delete(int itemId);
    }
}
