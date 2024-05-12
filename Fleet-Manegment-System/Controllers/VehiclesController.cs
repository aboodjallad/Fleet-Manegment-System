using Microsoft.AspNetCore.Mvc;
using FPro;
using Fleet_Manegment_System.Services.ServicesController;
using Fleet_Manegment_System.Services.Driver;
using Fleet_Manegment_System.Services.Vehicle;

namespace Fleet_Manegment_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IRun _addVehicleController = new AddController();
        private readonly IRun _deleteVehicleController = new DeleteController();
        private readonly IRun _updateVehicleController = new UpdateController();
        private readonly VehicleServices vehicleServices = new VehicleServices();


        
        [HttpPost("addVehicle")]
        public IActionResult AddVehicle([FromBody] GVAR gvar)
        {
            if (gvar == null)
            {
                return BadRequest("Invalid GVAR provided.");
            }
            if (_addVehicleController.Run(gvar))
            {
                return Ok(new { success = true, message = "Vehicle added successfully." });
            }
            return BadRequest($"Error adding Vehicle");
        }

        [HttpPost("deleteVehicle")]
        public IActionResult DeleteVehicle([FromBody] GVAR gvar)
        {
            if (gvar == null)
            {
                return BadRequest("Invalid GVAR provided.");
            }
            if (_deleteVehicleController.Run(gvar))
            {
                return Ok(new { success = true, message = "Vehicle deleted successfully." });
            }
            return BadRequest($"Error deleting Vehicle");

        }


        [HttpPut("updateVehicle")]
        public IActionResult UpdateVehicle([FromBody] GVAR gvar)
        {
            if (gvar == null)
            {
                return BadRequest("Invalid GVAR provided.");
            }

            if (_updateVehicleController.Run(gvar))
            {
                return Ok(new { success = true, message = "Vehicle added successfully." });
            }
            return BadRequest($"Error updating Vehicle");
        }


        [HttpPost("getVehicle")]
        [Produces("application/json")]
        public ActionResult<GVAR> GetAllDrivers([FromBody] GVAR gvar)
        {
            var result = vehicleServices.GetVehicle(gvar);

            if (result == null)
            {
                return NotFound("No vehicle found.");
            }
            return Ok(result);
        }
    }
}
