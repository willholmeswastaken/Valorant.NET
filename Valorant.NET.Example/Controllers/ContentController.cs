using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Valorant.NET.Clients.Content;

namespace Valorant.NET.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentClient _contentClient;

        public ContentController(IContentClient contentClient)
        {
            _contentClient = contentClient;
        }

        // GET: api/content
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string locale)
        {
            return Ok(await _contentClient.GetContentOptionallyFilteredByLocale(locale));
        }
    }
}
