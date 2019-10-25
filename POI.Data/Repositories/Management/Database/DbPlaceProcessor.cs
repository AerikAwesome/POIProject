using System.Data;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using POI.Common.Models;

namespace POI.Data.Repositories.Management.Database
{
    public class DbPlaceProcessor : IProcessor<Place>
    {
        private readonly IDbConnection _sqlConnection;
        private readonly string _queryCreate = "INSERT INTO Places (x) VALUES (@x); SELECT CAST(SCOPE_IDENTITY() as int)";
        private readonly string _queryUpdate = "";

        public DbPlaceProcessor(IDbConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<Place> Create(Place place)
        {
            var id = await _sqlConnection.InsertAsync(place).ConfigureAwait(false);
            place.Id = id;
            return place;
        }

        public async Task Update(Place place)
        {
            await _sqlConnection.UpdateAsync(place).ConfigureAwait(false);
        }

        public async Task Delete(int placeId)
        {
            await _sqlConnection.DeleteAsync(new Place{Id = placeId}).ConfigureAwait(false);
        }
    }
}
