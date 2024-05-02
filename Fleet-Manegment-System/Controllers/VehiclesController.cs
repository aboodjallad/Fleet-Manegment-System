using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Fleet_Manegment_System.Services;
using FPro;
using System.Collections.Concurrent;

namespace Fleet_Manegment_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class VehiclesController : ControllerBase
    {
        private readonly DriverServices _driverService;

        public VehiclesController(DriverServices driverService)
        {
            _driverService = driverService;
        }

        [HttpPost("add")]
        public IActionResult AddDriver([FromBody] GVAR gvar)
        {



            if (gvar.DicOfDic.TryGetValue("DriverInfo", out var driverInfo))
            {
                //_driverService.Add(new GVAR { DicOfDic = new ConcurrentDictionary<string, ConcurrentDictionary<string, string>> { ["DriverInfo"] = driverInfo } });
                return Ok("Driver added successfully");
            }

            return BadRequest("Driver information is missing");
        }
    }

}

