using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess.Repositories
{
    public class VehicleRepository : IVehiclesRepository
    {
        private readonly ApplicationDbContext dbContext;

        public VehicleRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Add(Vehicle vehicle)
        {
            dbContext.Vehicles.Add(vehicle);
            var changes = await dbContext.SaveChangesAsync();

            if (changes > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var vehicle = await dbContext.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                return false;
            }

            dbContext.Vehicles.Remove(vehicle);
            var changes = await dbContext.SaveChangesAsync();
            if (changes > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<Vehicle> Get(int id)
        {
            var query = dbContext.Vehicles
                .Include(v => v.ManufacturerDetails);

            return await query.FirstAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            var query = dbContext.Vehicles
                .Include(v => v.ManufacturerDetails);

            return await query.ToListAsync();
        }

        public async Task<(bool, Vehicle)> Update(Vehicle vehicle)
        {
            dbContext.Entry(vehicle).State = EntityState.Modified;
            var changes = await dbContext.SaveChangesAsync();
            if (changes > 0)
            {
                return (true, vehicle);
            }

            return (false, vehicle);
        }
    }
}
