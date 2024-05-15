using Fleet_Manegment_System.Services.ServicesController;
using Fleet_Manegment_System.Services.Vehichles;
using Fleet_Manegment_System.Services.Vehicle;
using FPro;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Data;
using System.Numerics;

namespace Fleet_Manegment_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleInformationController : ControllerBase
    {
        private readonly IRun _addVController = new AddController();
        private readonly IRun _deleteController = new DeleteController();
        private readonly IRun _updateController = new UpdateController();
        private readonly VehicleInformation _getController = new ();


        [HttpPost("addVehicleInformation")]
        public IActionResult AddVehicleInformation([FromBody] GVAR gvar)
        {
            if (gvar == null)
            {
                return BadRequest("Invalid or missing data for vehicle addition.");
            }

            if (_addVController.Run(gvar))
            {
                return Ok(new {success = true, message = "VehicleInformation added successfully." });
            }
            return BadRequest($"Error adding VehicleInformation");
        }

        [HttpPost("deleteVehicleInformation")]
        public IActionResult DeleteVehicleInformation([FromBody] GVAR gvar)
        {
            if (gvar == null)
            {
                return BadRequest("Invalid or missing data for vehicle deletion.");
            }
            if (_deleteController.Run(gvar))
            {
                return Ok(new { success = true, message = "VehicleInformation added successfully." });
            }
            return BadRequest($"Error deleting VehicleInformation");

        }

        [HttpPut("updateVehicleInformation")]
        public IActionResult UpdateVehicleInformation([FromBody] GVAR gvar)
        {
            if (gvar == null)
            {
                return BadRequest("Invalid or missing data for vehicle update.");
            }

            if(_updateController.Run(gvar))
            {
                return Ok(new { success = true, message = "VehicleInformation added successfully." });
            }
            return BadRequest($"Error updating VehicleInformation");

        }

        [HttpPut("assignDriver")]

        public IActionResult assignDriver([FromBody] GVAR gvar)
        {
            if (gvar != null)
            {
                return Ok(_getController.AssignOrUpdateVehicleDriver(gvar));
            }

            return BadRequest($"Error updating VehicleInformation");
        }

        [HttpPost("getSpecificVehicleInformation")]
        public ActionResult<GVAR> GetVehicleInformation([FromBody] GVAR gvar)
        {
            if (gvar == null)
            {
                return BadRequest("Invalid or missing data for retrieving vehicle information.");
            }

            _ = BigInteger.TryParse(gvar.DicOfDic["getVehicleInformation"]["vehicleid"].ToString(), out BigInteger vehicleID);
            
            var result = _getController.GetSpecificVehicleInformation(vehicleID);
            return Ok(result);

        }

        [HttpGet("getAllVehiclesInformation")]
        [Produces("application/json")]
        public ActionResult<GVAR> GetAllVehicleInformation()
        {
            
            var result = _getController.GetVehiclesInformation();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("No vehicle information available.");
        }

        [HttpPost("getVehicleInformation")]
        [Produces("application/json")]
        public ActionResult<GVAR> GetVehicle([FromBody] GVAR gvar)
        {
            var result = _getController.GetVehicleInformation(gvar);

            if (result == null)
            {
                return NotFound("No vehicle found.");
            }
            return Ok(result);
        }

        [HttpGet("getAll")]
        [Produces("application/json")]
        public ActionResult<GVAR> GetAll()
        {
            var result = _getController.GetAll();

            if (result == null)
            {
                return NotFound("No vehicle found.");
            }
            return Ok(result);
        }


    }
}
