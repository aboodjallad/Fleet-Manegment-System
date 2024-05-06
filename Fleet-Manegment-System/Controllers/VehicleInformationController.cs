using Fleet_Manegment_System.Services.ServicesController;
using Fleet_Manegment_System.Services.Vehichles;
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
            if (gvar == null || !gvar.DicOfDic.ContainsKey("addVehicleInformation"))
                return BadRequest("Invalid or missing data for vehicle addition.");

            _addVController.Run(gvar);
            return Ok("Vehicle information added successfully.");
        }

        [HttpDelete("deleteVehicleInformation")]
        public IActionResult DeleteVehicleInformation([FromBody] GVAR gvar)
        {
            if (gvar == null || !gvar.DicOfDic.ContainsKey("deleteVehicleInformation"))
                return BadRequest("Invalid or missing data for vehicle deletion.");

            _deleteController.Run(gvar);
            return Ok("Vehicle information deleted successfully.");
        }

        [HttpPut("updateVehicleInformation")]
        public IActionResult UpdateVehicleInformation([FromBody] GVAR gvar)
        {
            if (gvar == null || !gvar.DicOfDic.ContainsKey("updateVehicleInformation"))
                return BadRequest("Invalid or missing data for vehicle update.");

            _updateController.Run(gvar);
            return Ok("Vehicle information updated successfully.");
        }

        [HttpGet("getSpecificVehicleInformation")]
        public ActionResult<ConcurrentDictionary<string, DataTable>> GetVehicleInformation([FromBody] GVAR gvar)
        {
            if (gvar == null || !gvar.DicOfDic.ContainsKey("vehicleInformation"))
            {
                return BadRequest("Invalid or missing data for retrieving vehicle information.");
            }

            _ = BigInteger.TryParse(gvar.DicOfDic["getVehicleInformation"]["vehicleid"].ToString(), out BigInteger vehicleID);
            
            var result = _getController.GetSpecificVehicleInformation(vehicleID);

            if (gvar.DicOfDic.ContainsKey("getSpecificVehicleInformation"))
            {
                return Ok(result);
            }

            return NotFound("No vehicle information found.");
        }

        [HttpGet("getAllVehiclesInformation")]
        [Produces("application/json")]
        public ActionResult<GVAR> GetAllVehicleInformation()
        {
            
            var result = _getController.GetVehiclesInformation();
            if (result != null && result.DicOfDT.Count > 0)
            {
                return Ok(result);
            }
            return NotFound("No vehicle information available.");
        }
    }
}
