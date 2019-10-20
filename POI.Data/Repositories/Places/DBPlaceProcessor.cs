using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POI.Common.Models;

namespace POI.Data.Repositories.Places
{
    public class DbPlaceProcessor : IProcessor<Place>
    {
        private readonly ISqlConnector _sqlConnector;
        private readonly string _queryUpdate = "";

        public DbPlaceProcessor(ISqlConnector sqlConnector)
        {
            _sqlConnector = sqlConnector;
        }

        public Task Create(Place place)
        {
            throw new NotImplementedException();
        }

        public Task Update(Place place)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int placeId)
        {
            throw new NotImplementedException();
        }
    }
}
