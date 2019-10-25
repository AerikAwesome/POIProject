using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POI.Common.Models;

namespace POI.Data.Repositories.Management.Static
{
    public class StaticEventRepository : IEventProvider, IProcessor<Event>
    {
        private static readonly List<Event> _events = new List<Event>
        {
            new Event
            {
                Id = 1,
                PlaceId = 1,
                Name = "Tino Martin",
                Description = "Dit is een voorstelling"
            }
        };


        public async Task<IEnumerable<Event>> Get()
        {
            return _events;
        }

        public async Task<Event> Get(int id)
        {
            return _events.SingleOrDefault(e => e.Id == id);
        }

        public async Task<IEnumerable<Event>> GetEventsForPlace(int placeId)
        {
            return _events.Where(e => e.PlaceId == placeId);
        }

        public async Task<Event> Create(Event item)
        {
            _events.Add(item);
            return item;
        }

        public Task Update(Event item)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int itemId)
        {
            _events.RemoveAll(e => e.Id == itemId);
        }
    }
}
