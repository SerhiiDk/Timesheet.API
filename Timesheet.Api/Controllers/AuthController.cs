using Microsoft.AspNetCore.Mvc;
using Timesheet.Api.Models.ResourceModels;
using Timesheet.Domain.Iterfaces;

namespace Timesheet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public ActionResult<bool> Login([FromBody]LoginRequest request)
        {
            //var authService = new AuthService();

            return Ok(_authService.Login(request.LastName));
        }
    }
}
