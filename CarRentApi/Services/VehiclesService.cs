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

        public Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return vehicleRepository.GetAll();
        }
    }
}
