using Microsoft.AspNetCore.Mvc;
using FPro;
using System.Collections.Concurrent;
using Fleet_Manegment_System.Services.Driver;
using System.Data;
using Fleet_Manegment_System.Services.ServicesController;

namespace Fleet_Manegment_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly DriverServices _driverService = new();
        private readonly IRun _addController =  new AddController();
        private readonly IRun _deleteController = new DeleteController();
        private readonly IRun _updateController = new UpdateController();

       

        [HttpPost("addDriver")]
        public IActionResult AddDriver([FromBody] GVAR gvar)
        {
            try
            {
                _addController.Run(gvar);
                return Ok("Driver added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding driver: {ex.Message}");
            }
        }

        [HttpDelete("deleteDriver")]
        public IActionResult DeleteDriver([FromBody] GVAR gvar)
        {
            try
            {
                _deleteController.Run(gvar);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting driver: {ex.Message}");
            }
        }

        [HttpGet("getAllDrivers")]
        [Produces("application/json")]
        public ActionResult<GVAR> GetAllDrivers()
        {
            var result = _driverService.GetDrivers();

            if (result == null || result.DicOfDT.Count == 0)
            {
                return NotFound("No drivers found.");
            }
            return Ok(result);
        }


        [HttpPut("updateDriver")]
        public IActionResult UpdateDriver([FromBody] GVAR gvar)
        {
            try
            {
                _updateController.Run(gvar);
                return Ok("Driver updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating driver: {ex.Message}");
            }
        }

    }
}
