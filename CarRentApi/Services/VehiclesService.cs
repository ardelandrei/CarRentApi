using DataAccess.Models;
using DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentApi.Services
{
    public class VehiclesService : IVehicleService
    {
        private readonly IVehiclesRepository vehicleRepository;

        public VehiclesService(IVehiclesRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public Task<bool> DeleteVehicle()
        {
            throw new System.NotImplementedException();
        }

        public Task<Vehicle> GetVehicle()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return vehicleRepository.GetAll();
        }

        public Task<bool> InsertVehicle()
        {
            throw new System.NotImplementedException();
        }

        public Task<Vehicle> UpdateVehicle()
        {
            throw new System.NotImplementedException();
        }
    }
}
