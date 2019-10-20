using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POI.Common.Models;

namespace POI.Data.Repositories
{
    public interface IProvider<T> where T : BaseDatabaseObject
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
    }
}
