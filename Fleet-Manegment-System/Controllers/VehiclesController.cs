using Microsoft.AspNetCore.Mvc;
using FPro;
using Fleet_Manegment_System.Services.ServicesController;

namespace Fleet_Manegment_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IRun _addVehicleController = new AddController();
        private readonly IRun _deleteVehicleController = new DeleteController();
        private readonly IRun _updateVehicleController = new UpdateController();
        //private readonly IRun _getVehicleController = new GetController();

        
        [HttpPost("addVehicle")]
        public IActionResult AddVehicle([FromBody] GVAR gvar)
        {
            if (gvar == null)
            {
                return BadRequest("Invalid GVAR provided.");
            }
            if (_addVehicleController.Run(gvar))
            {
                return Ok("Vehicle added successfully.");
            }
            return BadRequest($"Error adding Vehicle");
        }

        [HttpDelete("deleteVehicle")]
        public IActionResult DeleteVehicle([FromBody] GVAR gvar)
        {
            if (gvar == null)
            {
                return BadRequest("Invalid GVAR provided.");
            }
            if (_deleteVehicleController.Run(gvar))
            {
                return Ok("Vehicle deleted successfully.");
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
                return Ok("Vehicle updated successfully.");
            }
            return BadRequest($"Error updating Vehicle");
        }
    }
}
