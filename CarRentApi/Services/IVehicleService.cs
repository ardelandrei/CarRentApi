using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Models;

namespace CarRentApi.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetVehicles();

        Task<Vehicle> GetVehicle(int id);

        Task<(bool IsSuccess, Vehicle Vehicle)> InsertVehicle(Vehicle vehicle);

        Task<bool> DeleteVehicle(int id);

        Task<bool> UpdateVehicle(Vehicle vehicle);
    }
}
