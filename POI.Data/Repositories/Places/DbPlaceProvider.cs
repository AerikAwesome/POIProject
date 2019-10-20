using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using POI.Common.Models;

namespace POI.Data.Repositories.Places
{
    public class DbPlaceProvider : IProvider<Place>
    {
        private readonly ISqlConnector _sqlConnector;
        private static string _queryString = "select id, type, name, loc_long as Longitude, loc_lat as Latitude";

        public DbPlaceProvider(ISqlConnector sqlConnector)
        {
            _sqlConnector = sqlConnector;
        }

        public async Task<IEnumerable<Place>> Get()
        {
            IEnumerable<Place> places;
            await using (var connection = _sqlConnector.GetConnection())
            {
                places = await connection.QueryAsync<Place, Location, Place>(_queryString, map:((place, location) =>
                {
                    place.Location = location;
                    return place;
                }), splitOn: "Longitude");
            }

            return places;
        }

        public Task<Place> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
