using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCarDealer.Models
{
    public class Vehicle
    {
        private int _VIN;
        private string _vehicleMake;
        private string _vehicleModel;
        private int _vehicleHorsePower;
        private string _vehicleCategory;

        public Vehicle()
        {
            _VIN = 0;
            _vehicleMake = "Not defined";
            _vehicleModel = "Not defined";
            _vehicleHorsePower = 0;
            _vehicleCategory = "Not defined";
        }

        public Vehicle(int VIN, string vehicleMake, string vehicleModel, int vehicleHorsePower, string vehicleCategory)
        {
            _VIN = VIN;
            _vehicleMake = vehicleMake;
            _vehicleModel = vehicleModel;
            _vehicleHorsePower = vehicleHorsePower;
            _vehicleCategory = vehicleCategory;
        }

        public int VIN { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleHorsePower { get; set; }
        public string VehicleCategory { get; set; }
    }
}
