using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace CarRentApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {

        public IActionResult Index()
        {
            var message = new { Message = "Welcome to rent a car!" };

            return Ok(JsonSerializer.Serialize(message));
        }
    }
}
