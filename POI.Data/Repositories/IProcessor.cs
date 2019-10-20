using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POI.Common.Models;

namespace POI.Data.Repositories
{
    public interface IProcessor<T> where T : BaseDatabaseObject
    {
        Task Create(T item);
        Task Update(T item);
        Task Delete(int itemId);
    }
}
