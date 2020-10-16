using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public interface IVehiclesRepository
    {
        Task<IEnumerable<Vehicle>> GetAll();

        Task<Vehicle> Get(int id);

        Task<(bool IsSuccess, Vehicle Vehicle)> Add(Vehicle vehicle);

        Task<bool> Update(Vehicle vehicle);

        Task<bool> Delete(int id);
    }
}
