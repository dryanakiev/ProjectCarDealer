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
    public class PersonRepository
    {
        private static PersonRepository _instance;

        public static PersonRepository getInstance()
        {
            if (_instance == null)
            {
                _instance = new PersonRepository();
            }

            return _instance;
        }

        public List<Person> GetAllPeople()
        {
            List<Person> people = new List<Person>();

            string commandString = "SELECT * FROM Person";

            try
            {
                SqlConnection connection = DBConnection.GetConnection();

                SqlDataReader reader = DBCommand.ExecuteCommand(connection, commandString);

                while (reader.Read())
                {
                    people.Add(MapToUser(reader));
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }

            return people;
        }

        public List<Person> GetAllDrivers()
        {
            List<Person> drivers = new List<Person>();

            string commandString = "SELECT * FROM Person WHERE Driver = '1'";

            try
            {
                SqlConnection connection = DBConnection.GetConnection();

                SqlDataReader reader = DBCommand.ExecuteCommand(connection, commandString);

                while (reader.Read())
                {
                    drivers.Add(MapToUser(reader));
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }

            return drivers;
        }

        public void AddPerson(string personFirstName, string personLastName, int personAge, bool driver, string driverLicence)
        {
            string commandString = "INSERT INTO Person PersonFirstName, PersonLastName, PersonAge, Driver, DriverLicence VALUES @personFirstName, @personLastName, @personAge, @driver, @driverLicence";

            try
            {
                SqlConnection connection = DBConnection.GetConnection();

                SqlCommand command = new SqlCommand(commandString, connection);

                command.Parameters.AddWithValue("@personFirstName", personFirstName);
                command.Parameters.AddWithValue("@personLastName", personLastName);
                command.Parameters.AddWithValue("@personAge", personAge);
                command.Parameters.AddWithValue("@driver", driver);
                command.Parameters.AddWithValue("@driverLicence", driverLicence);

                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void DeletePersonById(int personId)
        {
            string commandString = "DELETE FROM Person WHERE PersonId = @personId";

            try
            {
                SqlConnection connection = DBConnection.GetConnection();

                SqlCommand command = new SqlCommand(commandString, connection);

                command.Parameters.AddWithValue("@personId", personId);

                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
        }

        public bool PersonCanDriveById(int personId)
        {
            string commandString = "Select * FROM Person WHERE PersonId = @personId AND Driver = '1'";

            try
            {
                SqlConnection connection = DBConnection.GetConnection();

                SqlDataReader reader = DBCommand.ExecuteCommand(connection, commandString);

                return reader.Read();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }

            return false;
        }

        private Person MapToUser(SqlDataReader reader)
        {
            Person person = new Person();

            person.PersonId = (int)reader.GetValue(0);
            person.PersonFirstName = (string)reader.GetValue(1);
            person.PersonLastName = (string)reader.GetValue(2);
            person.PersonAge = (int)reader.GetValue(3);
            person.Driver = (bool)reader.GetValue(4);
            person.DriversLicense = (string)reader.GetValue(5);

            return person;
        }
    }
}
