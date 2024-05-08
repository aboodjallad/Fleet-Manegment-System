using Fleet_Manegment_System.Services.General;
using Fleet_Manegment_System.Services.Routes;
using Fleet_Manegment_System.Services.Vehicle;
using FPro;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Data;

namespace Fleet_Manegment_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteHistoryController : ControllerBase
    {
        private readonly RouteHistory _routeHistoryService = new();

        [HttpPost("getRouteHistory")]
        public ActionResult<ConcurrentDictionary<string, DataTable>> GetRouteHistory([FromBody] GVAR gvar)
        {
            if (gvar == null || !gvar.DicOfDic.ContainsKey("getRouteHistory"))
            {
                return BadRequest("Invalid or missing GVAR data.");
            }

            var routeHistoryData = _routeHistoryService.GetRouteHistory(gvar.DicOfDic["getRouteHistory"]);
            if (routeHistoryData == null || routeHistoryData.Count == 0)
            {
                return NotFound("No route history data found for the provided criteria.");
            }

            return Ok(routeHistoryData);
        }

        [HttpPost("addRouteHistory")]
        public IActionResult AddRouteHistory([FromBody] GVAR gvar)
        {
            if (gvar == null)
            {
                return BadRequest("Invalid or missing GVAR data.");
            }

            try
            {
                foreach (var dic in gvar.DicOfDic)
                {
                    var dictionary = dic.Value;
                    if (dictionary == null)
                    {
                        Console.WriteLine("Dictionary cant be empty \n Skipped");
                        continue;
                    }

                    if (dic.Key.Contains("RouteHistory"))
                    {
                        bool success = _routeHistoryService.AddRouteHistory(dictionary);
                        if (success)
                        {
                            return Ok("Route history added successfully.");
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding route history: {ex.Message}");
            }

            return BadRequest("Failed to add route history.");

        }
    }
}
