using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Domain.Iterfaces;

namespace Timesheet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService; 
        }


        [HttpGet("{employee}")]
        public IActionResult GetEmpoyeereport(string lastName)
        {

            //var employee = 

            return Ok();
        }
    }
}
