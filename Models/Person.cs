using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCarDealer.Models
{
    public class Person
    {
        private int _personId;
        private string _personFirstName;
        private string _personLastName;
        private int _personAge;
        private bool _driver;
        private string _driversLicense;

        public Person()
        {
            _personId = 0;
            _personFirstName = "Not defined";
            _personLastName = "Not defined";
            _personAge = 0;
            _driver = false;
            _driversLicense = "Not defined";
        }

        public Person(int personId, string personFirstName, string personLastName, int personAge, bool driver, string driversLicense)
        {
            _personId = personId;
            _personFirstName = personFirstName;
            _personLastName = personLastName;
            _personAge = personAge;
            _driver = driver;
            _driversLicense = driversLicense;
        }

        public int PersonId { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public int PersonAge { get; set; }
        public bool Driver { get; set; }
        public string DriversLicense { get; set; }
    }
}
