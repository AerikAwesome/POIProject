using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POI.Common.Models;

namespace POI.Data.Repositories.Management
{
    public interface IEventProvider : IProvider<Event>
    {
        Task<IEnumerable<Event>> GetEventsForPlace(int placeId);
    }
}
