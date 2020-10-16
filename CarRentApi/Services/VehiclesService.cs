using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DataAccess.Models;
using DataAccess.Repositories;

namespace CarRentApi.Services
{
    public class VehiclesService : IVehicleService
    {
        private readonly IVehiclesRepository vehicleRepository;
        private readonly ILogger<VehiclesService> logger;

        public VehiclesService(IVehiclesRepository vehicleRepository, ILogger<VehiclesService> logger)
        {
            this.vehicleRepository = vehicleRepository;
            this.logger = logger;
        }

        public Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return vehicleRepository.GetAll();
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            Vehicle vehicle = null;
            try
            {
                vehicle = await vehicleRepository.Get(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }

            return vehicle;
        }

        public async Task<bool> DeleteVehicle(int id)
        {
            try
            {
                var deleted = await vehicleRepository.Delete(id);
                return deleted;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }

            return false;
        }

        public async Task<(bool IsSuccess, Vehicle Vehicle)> InsertVehicle(Vehicle vehicle)
        {
            try
            {
                var response = await vehicleRepository.Add(vehicle);
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }

            return (false, null);
        }

        public async Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                var updated = await vehicleRepository.Update(vehicle);
                return updated;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }

            return false;
        }
    }
}
