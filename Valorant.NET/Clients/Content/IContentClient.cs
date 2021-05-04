using System.Threading.Tasks;
using Valorant.NET.Models;
using Valorant.NET.Models.Content;

namespace Valorant.NET.Clients.Content
{
    /// <summary>
    /// Interacts with the Valorant Content endpoint.
    /// </summary>
    public interface IContentClient
    {
        Task<ContentResponse> GetContentOptionallyFilteredByLocale(string locale = "en-GB", ValorantEndpointRegion region = ValorantEndpointRegion.EU);
    }
}
