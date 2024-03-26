using BlueApi_Backend.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlueApi_Backend.Controllers
{
    [Route("api/AuthTest")]
    [ApiController]
    public class AuthTestController : ControllerBase
    {
        [HttpGet]
        [Authorize]//any one can access

        public async Task<ActionResult<string>> GetSomething()
        {
            return "You are authenticated";
        }
        //if username and password valid->Authentication

        [HttpGet("{id:int}")]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<string>> GetSomething(int someIntValue)
        {
            //authorization -> Authentication + Some access/roles
            return "You are Authorized with Role of Admin";
        }
    }
}
