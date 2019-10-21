using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace POI.Data.Repositories
{
    public class SqlConnector
    {
        private readonly string _connectionString;

        public SqlConnector(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("POIDatabase");
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
