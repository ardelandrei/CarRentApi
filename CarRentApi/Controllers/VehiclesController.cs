using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRentApi.Services;
using DataAccess.Models;

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
        public async Task<IActionResult> GetVehicles()
        {
            var vehicles = await vehicleService.GetVehicles();

            if (vehicles != null)
            {
                return Ok(JsonSerializer.Serialize(vehicles.ToArray()));
            }

            return NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await vehicleService.GetVehicle(id);

            if (vehicle != null)
            {
                return Ok(JsonSerializer.Serialize(vehicle));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostVehicle(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await vehicleService.InsertVehicle(vehicle);

            if (response.IsSuccess)
            {
                return CreatedAtAction(nameof(GetVehicle), 
                    new { id = response.Vehicle.Id }, 
                    JsonSerializer.Serialize(response.Vehicle)
                    );
            }

            return BadRequest();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id && !ModelState.IsValid)
            {
                return BadRequest();
            }

            var updated = await vehicleService.UpdateVehicle(vehicle);

            if (updated)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var removed = await vehicleService.DeleteVehicle(id);

            if (removed)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
