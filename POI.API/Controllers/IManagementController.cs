using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace POI.API.Controllers
{
    public interface IManagementController<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> Post([FromBody] T value);
        Task Put(int id, [FromBody] T value);
        Task Delete(int id);
    }
}
