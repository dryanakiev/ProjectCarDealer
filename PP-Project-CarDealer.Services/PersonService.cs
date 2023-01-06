using ProjectCarDealer.Models;
using ProjectCarDealer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCarDealer.Services
{
    public class PersonService
    {
        private static PersonService _instance;
        private PersonRepository _personRepository;

        public PersonService()
        {
            _personRepository = PersonRepository.getInstance();
        }

        public static PersonService getInstance()
        {
            if (_instance == null)
            {
                _instance = new PersonService();
            }

            return _instance;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = _personRepository.GetAllPeople();

            return people;
        }

        public List<Person> GetDrivers()
        {
            List<Person> people = _personRepository.GetAllDrivers();

            return people;
        }

        public void AddPerson(string personFName, string personLName, int age, bool isDriver, string driversLicence)
        {
            _personRepository.AddPerson(personFName, personLName, age, isDriver, driversLicence);
        }

        public void DeletePerson(int personId)
        {
            _personRepository.DeletePersonById(personId);
        }
    }
}
