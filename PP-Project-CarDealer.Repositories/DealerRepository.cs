using Microsoft.Data.SqlClient;
using ProjectCarDealer.Models;
using ProjectCarDealer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCarDealer.Repositories
{
    public class DealerRepository
    {
        private static DealerRepository _instance;

        public static DealerRepository getInstance()
        {
            if (_instance == null)
            {
                _instance = new DealerRepository();
            }

            return _instance;
        }

        public List<Dealer> GetAllDealers()
        {
            List<Dealer> dealers = new List<Dealer>();

            string commandString = "SELECT * FROM Dealer";

            try
            {
                SqlConnection connection = DBConnection.GetConnection();

                SqlDataReader reader = DBCommand.ExecuteCommand(connection, commandString);

                while (reader.Read())
                {
                    dealers.Add(MapToDealer(reader));
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }

            return dealers;
        }

        public void AddDealer(string dealerName, string dealerLocation)
        {
            string commandString = "INSERT INTO Dealer DealerName, DealerLocation VALUES @dealerName, @dealerLocation";

            try
            {
                SqlConnection connection = DBConnection.GetConnection();

                SqlCommand command = new SqlCommand(commandString, connection);

                command.Parameters.AddWithValue("@dealerName", dealerName);
                command.Parameters.AddWithValue("@dealerLocation", dealerLocation);

                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void DeleteDealerById(int dealerId)
        {
            string commandString = "DELETE FROM Dealer WHERE DealerId = @dealerId";

            try
            {
                SqlConnection connection = DBConnection.GetConnection();

                SqlCommand command = new SqlCommand(commandString, connection);

                command.Parameters.AddWithValue("@dealerId", dealerId);

                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
        }

        private Dealer MapToDealer(SqlDataReader reader)
        {
            Dealer dealer = new Dealer();

            dealer.DealerId = (int)reader.GetValue(0);
            dealer.DealerName = (string)reader.GetValue(1);
            dealer.DealerLocation = (string)reader.GetValue(2);
            

            return dealer;
        }
    }
}
