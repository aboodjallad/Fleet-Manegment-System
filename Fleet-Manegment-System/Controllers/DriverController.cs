﻿using Microsoft.AspNetCore.Mvc;
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
                if (_addController.Run(gvar))
                { 
                return Ok(new { success = true, message = "Driver added successfully."});
                }
                return BadRequest($"Error adding driver");

            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding driver: {ex.Message}");
            }
        } // DONE

        [HttpPost("deleteDriver")]
        public IActionResult DeleteDriver([FromBody] GVAR gvar)
        {
            try
            {
                _deleteController.Run(gvar);
                return Ok(new { success = true, message = "Driver deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting driver: {ex.Message}");
            }
        }//done

        [HttpGet("getAllDrivers")]
        [Produces("application/json")]
        public ActionResult<GVAR> GetAllDrivers()
        {
            var result = _driverService.GetDrivers();

            if (result == null)
            {
                return NotFound("No drivers found.");
            }
            return Ok(result);
        }//done


        [HttpPut("updateDriver")]
        public IActionResult UpdateDriver([FromBody] GVAR gvar)
        {
            try
            {
                if (_updateController.Run(gvar))
                {
                    return Ok(new { success = true, message = "Driver added successfully." });
                }
                else
                    return BadRequest($"Error updating driver");

            }

            catch (Exception ex)
            {
                return BadRequest($"Error updating driver: {ex.Message}");
            }

        }

        [HttpPost("getDriver")]
        [Produces("application/json")]
        public ActionResult<GVAR> GetDriver([FromBody] GVAR gvar)
        {
            var result = _driverService.GetDriver(gvar);

            if (result == null)
            {
                return NotFound("No drivers found.");
            }
            return Ok(result);
        }//done

    }
}
