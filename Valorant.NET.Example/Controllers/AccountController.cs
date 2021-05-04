using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Valorant.NET.Clients.Account;

namespace Valorant.NET.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountClient _accountClient;

        public AccountController(IAccountClient accountClient)
        {
            _accountClient = accountClient;
        }

        // GET: api/account
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string gameName, [FromQuery] string tagLine)
        {
            return Ok(await _accountClient.GetByRiotId(gameName, tagLine));
        }
    }
}
