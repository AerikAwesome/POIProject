using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SqlServer.Types;
using POI.Common.Models;

#pragma warning disable 1998

namespace POI.Data.Repositories.Management.Static
{
    public class StaticPlaceRepository : IProvider<Place>, IProcessor<Place>
    {

        private static readonly List<Place> _places = new List<Place>
        {
            new Place
            {
                Id = 1, 
                Visible = true, 
                Name = "Beatrix theater", 
                Description = "Dit is een theater", 
                Address = "Utrecht_Jaarbeursplein-6A", 
                Coordinates = SqlGeography.Point(52.088301631793456, 5.107164851899615, 4326)
            }
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
