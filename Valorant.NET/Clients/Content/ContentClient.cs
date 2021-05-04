using System.Threading.Tasks;
using Valorant.NET.Models;
using Valorant.NET.Models.Content;
using Valorant.NET.Resolvers;

namespace Valorant.NET.Clients.Content
{
    public class ContentClient : IContentClient
    {
        private readonly IRiotHttpClient _httpClient;
        private readonly IRiotApiUrlResolver _riotApiUrlResolver;

        private const string ContentUrl = "/content/v1";

        public ContentClient(IRiotHttpClient httpClient,
            IRiotApiUrlResolver riotApiUrlResolver)
        {
            _riotApiUrlResolver = riotApiUrlResolver;
            _httpClient = httpClient;
        }

        public async Task<ContentResponse> GetContentOptionallyFilteredByLocale(string locale = "en-GB", ValorantEndpointRegion region = ValorantEndpointRegion.EU)
        {
            var url = _riotApiUrlResolver.Resolve(region, $"{ContentUrl}/contents?locale={locale}");

            return await _httpClient.GetAsync<ContentResponse>(url);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
