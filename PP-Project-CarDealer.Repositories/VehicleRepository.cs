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
    public class VehicleRepository
    {
        private static VehicleRepository _instance;

        public static VehicleRepository getInstance()
        {
            if (_instance == null)
            {
                _instance = new VehicleRepository();
            }

            return _instance;
        }

        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string commandString = "SELECT * FROM Vehicle";

            try
            {
                SqlConnection connection = DBConnection.GetConnection();

                SqlDataReader reader = DBCommand.ExecuteCommand(connection, commandString);

                while (reader.Read())
                {
                    vehicles.Add(MapToVehicle(reader));
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }

            return vehicles;
        }

        public List<Vehicle> GetAllMakes(string vehicleMake)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string commandString = "SELECT * FROM Vehicle WHERE Make = @vehicleMake";

            try
            {
                SqlConnection connection = DBConnection.GetConnection();

                SqlDataReader reader = DBCommand.ExecuteCommand(connection, commandString);

                while (reader.Read())
                {
                    vehicles.Add(MapToVehicle(reader));
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }

            return vehicles;
        }

        public void AddVehicle(string vehicleMake, string vehicleModel, int vehicleHorsePower, string vehicleCategory)
        {
            string commandString = "INSERT INTO Vehicle VehicleMake, VehicleModel, VehicleHorsePower, VehicleCategory VALUES @vehicleMake, @vehicleModel, @vehicleHorsePower, @vehicleCategory";

            try
            {
                SqlConnection connection = DBConnection.GetConnection();

                SqlCommand command = new SqlCommand(commandString, connection);

                command.Parameters.AddWithValue("@vehicleMake", vehicleMake);
                command.Parameters.AddWithValue("@vehicleModel", vehicleModel);
                command.Parameters.AddWithValue("@vehicleHorsePower", vehicleHorsePower);
                command.Parameters.AddWithValue("@vehicleCategory", vehicleCategory);

                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void DeleteVehicleById(int VIN)
        {
            string commandString = "DELETE FROM Vehicle WHERE VIN = @VIN";

            try
            {
                SqlConnection connection = DBConnection.GetConnection();

                SqlCommand command = new SqlCommand(commandString, connection);

                command.Parameters.AddWithValue("@VIN", VIN);

                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
        }

        private Vehicle MapToVehicle(SqlDataReader reader)
        {
            Vehicle vehicle = new Vehicle();

            vehicle.VIN = (int)reader.GetValue(0);
            vehicle.VehicleMake = (string)reader.GetValue(1);
            vehicle.VehicleModel = (string)reader.GetValue(2);
            vehicle.VehicleHorsePower = (int)reader.GetValue(3);
            vehicle.VehicleCategory = (string)reader.GetValue(4);
         
            return vehicle;
        }
    }
}
