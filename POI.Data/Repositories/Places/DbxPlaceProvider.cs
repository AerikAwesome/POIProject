using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using POI.Common.Models;

namespace POI.Data.Repositories.Places
{
    public class DbPlaceProvider : IProvider<Place>
    {
        private readonly IDbConnection _sqlConnection;
        private static string _queryString = "select id, type, name, loc_long as Longitude, loc_lat as Latitude";

        public DbPlaceProvider(IDbConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<IEnumerable<Place>> Get()
        {
            IEnumerable<Place> places;
            places = await _sqlConnection.QueryAsync<Place, Location, Place>(_queryString, map:((place, location) =>
            {
                place.Location = location;
                return place;
            }), splitOn: "Longitude").ConfigureAwait(false);

            return places;
        }

        public Task<Place> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
