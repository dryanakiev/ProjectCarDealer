using ProjectCarDealer.Models;
using ProjectCarDealer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCarDealer.Services
{
    public class VehicleService
    {
        private static VehicleService _instance;
        private VehicleRepository _vehicleRepository;

        public VehicleService()
        {
            _vehicleRepository = VehicleRepository.getInstance();
        }

        public static VehicleService getInstance()
        {
            if (_instance == null)
            {
                _instance = new VehicleService();
            }

            return _instance;
        }

        public List<Vehicle> GetVehicles()
        {
            List<Vehicle> vehicles = _vehicleRepository.GetAllVehicles();

            return vehicles;
        }
        public List<Vehicle> GetMakes(string vehicleMake)
        {
            List<Vehicle> vehicles = _vehicleRepository.GetAllMakes(vehicleMake);

            return vehicles;
        }

        public void AddVehicle(string vehicleMake, string vehicleModel, int vehicleHorsePower, string vehicleCategory)
        {
            _vehicleRepository.AddVehicle(vehicleMake, vehicleModel, vehicleHorsePower, vehicleCategory);
        }

        public void DeleteVehicle(int VIN)
        {
            _vehicleRepository.DeleteVehicleById(VIN);
        }
    }
}
