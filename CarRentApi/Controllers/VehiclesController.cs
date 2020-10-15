using System.Text.Json;
using CarRentApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> Vehicles()
        {
            var vehicles = await vehicleService.GetVehicles();

            if (vehicles != null)
            {
                return Ok(JsonSerializer.Serialize(vehicles.ToArray()));
            }

            return NotFound();
        }
    }
}
