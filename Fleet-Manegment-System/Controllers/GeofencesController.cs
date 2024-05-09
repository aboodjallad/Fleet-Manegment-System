using Fleet_Manegment_System.Services.Geofences;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Data;

namespace Fleet_Manegment_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeofencesController : ControllerBase
    {
        private readonly Geofences _geofencesService = new();
        private readonly Circular _circularService = new();
        private readonly Rectangular _rectangularService = new();
        private readonly Polygon _polygonService = new();

        

        [HttpGet("getAllGeofences")]
        public ActionResult<ConcurrentDictionary<string, DataTable>> GetGeofences()
        {
            var geofences = _geofencesService.GetAllGeofences();
            if (geofences == null || geofences.Count == 0)
            {
                return NotFound("No geofences found.");
            }
            return Ok(geofences);
        }

        [HttpGet("getCircularGeofences")]
        public ActionResult<ConcurrentDictionary<string, DataTable>> GetCircularGeofences()
        {
            var circularGeofences = _circularService.GetAllCircularGeofences();
            if (circularGeofences == null || circularGeofences.Count == 0)
            {
                return NotFound("No circular geofences found.");
            }
            return Ok(circularGeofences);
        }

        [HttpGet("getRectangularGeofences")]
        public ActionResult<ConcurrentDictionary<string, DataTable>> GetRectangularGeofences()
        {
            var rectangularGeofences = _rectangularService.GetAllRectangularGeofences();
            if (rectangularGeofences == null || rectangularGeofences.Count == 0)
            {
                return NotFound("No rectangular geofences found.");
            }
            return Ok(rectangularGeofences);
        }

        [HttpGet("getPolygonGeofences")]
        public ActionResult<ConcurrentDictionary<string, DataTable>> GetPolygonGeofences()
        {
            var polygonGeofences = _polygonService.GetAllPolygonGeofences();
            if (polygonGeofences == null || polygonGeofences.Count == 0)
            {
                return NotFound("No polygon geofences found.");
            }
            return Ok(polygonGeofences);
        }
    }
} // all done
