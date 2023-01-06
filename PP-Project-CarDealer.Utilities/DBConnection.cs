using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCarDealer.Utilities
{
    public class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(ProjectProperties.DB_URL);

            return connection;
        }

    }
}
