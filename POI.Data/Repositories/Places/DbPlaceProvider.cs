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

        public DbPlaceProvider(IDbConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<IEnumerable<Place>> Get()
        {
            return await _sqlConnection.GetAllAsync<Place>().ConfigureAwait(false);
        }

        public async Task<Place> Get(int id)
        {
            return await _sqlConnection.GetAsync<Place>(id).ConfigureAwait(false);
        }
    }
}
