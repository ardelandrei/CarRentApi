using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentApi.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetVehicles();

        Task<Vehicle> GetVehicle();

        Task<bool> InsertVehicle();

        Task<bool> DeleteVehicle();

        Task<Vehicle> UpdateVehicle();
    }
}
