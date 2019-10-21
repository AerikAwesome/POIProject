using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POI.Common.Models;
#pragma warning disable 1998

namespace POI.Data.Repositories.Places
{
    public class StaticPlaceRepository : IProvider<Place>, IProcessor<Place>
    {
        private static readonly List<Place> _places = new List<Place>
        {
            new Place{Id = 1, Name = "TestPlace", Type = PlaceType.Place, Location = new Location{Latitude = 1, Longitude = 1}}
        };
        public async Task<IEnumerable<Place>> Get()
        {
            return _places;
        }

        public async Task<Place> Get(int id)
        {
            return _places.SingleOrDefault(p => p.Id == id);
        }

        public async Task<Place> Create(Place item)
        {
            _places.Add(item);
            return item;
        }

        public Task Update(Place item)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(int itemId)
        {
            _places.RemoveAll(p => p.Id == itemId);
        }
    }
}
