using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Domain.Iterfaces;
using Timesheet.Domain.Models;

namespace Timesheet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetController : ControllerBase
    {
        private readonly ITimesheetService _timesheetService;

        public TimesheetController(ITimesheetService timesheetService) 
        {
            _timesheetService = timesheetService;
        }

        [HttpPost]
        public IActionResult CreateTiemsheet([FromBody] TimeLog timeLog)
        {
            if (_timesheetService.TrackTime(timeLog))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
