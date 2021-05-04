using System.Threading.Tasks;
using Valorant.NET.Handlers;
using Valorant.NET.Models;
using Valorant.NET.Models.Content;
using Valorant.NET.Resolvers;

namespace Valorant.NET.Clients.Content
{
    public class ContentClient : BaseRiotClient, IContentClient
    {
        private readonly IRiotApiUrlResolver _riotApiUrlResolver;

        private const string ContentUrl = "/content/v1";

        public ContentClient(IRiotTokenResolver riotTokenResolver,
            IRiotApiUrlResolver riotApiUrlResolver,
            IRiotApiResponseHandler riotApiResponseHandler)
            : base(riotTokenResolver, riotApiResponseHandler)
        {
            _riotApiUrlResolver = riotApiUrlResolver;
        }

        public async Task<ContentResponse> GetContentOptionallyFilteredByLocale(string locale = "en-GB", ValorantEndpointRegion region = ValorantEndpointRegion.EU)
        {
            var url = _riotApiUrlResolver.Resolve(region, $"{ContentUrl}/contents?locale={locale}");

            return await GetAsync<ContentResponse>(url);
        }
    }
}
