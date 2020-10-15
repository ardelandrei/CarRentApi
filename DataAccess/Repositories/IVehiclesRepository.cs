using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IVehiclesRepository
    {
        Task<IEnumerable<Vehicle>> GetAll();

        Task<Vehicle> Get(int id);

        Task<bool> Add(Vehicle vehicle);

        Task<(bool,Vehicle)> Update(Vehicle vehicle);

        Task<bool> Delete(int id);
    }
}
