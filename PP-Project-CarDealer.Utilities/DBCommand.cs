using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCarDealer.Utilities
{
    public class DBCommand
    {
        public static SqlDataReader ExecuteCommand(SqlConnection connection, string commandString)
        {
            SqlCommand command = new SqlCommand(commandString, connection);

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }
    }
}
