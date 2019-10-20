using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace POI.Data.Repositories
{
    public interface ISqlConnector
    {
        SqlConnection GetConnection();
    }
}
