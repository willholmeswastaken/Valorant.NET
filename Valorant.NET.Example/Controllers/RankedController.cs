using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Valorant.NET.Clients.Ranked;

namespace Valorant.NET.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankedController : ControllerBase
    {
        private readonly IRankedClient _rankedClient;

        public RankedController(IRankedClient rankedClient)
        {
            _rankedClient = rankedClient;
        }

        // GET: api/ranked
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int startPosition = 0, [FromQuery] int totalPlayersToReturn = 2, [FromQuery] string actId = "52e9749a-429b-7060-99fe-4595426a0cf7")
        {
            return Ok(await _rankedClient.GetLeaderboardByAct("52e9749a-429b-7060-99fe-4595426a0cf7", startPosition, totalPlayersToReturn));
        }
    }
}
