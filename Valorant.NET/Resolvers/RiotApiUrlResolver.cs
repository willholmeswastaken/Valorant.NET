using System;
using Valorant.NET.Helpers;
using Valorant.NET.Models;

namespace Valorant.NET.Resolvers
{
    public class RiotApiUrlResolver : IRiotApiUrlResolver
    {
        public Uri Resolve(NonValorantEndpointRegion region, string endpoint)
        {
            return BuildUri(region.GetEnumMemberValue(), endpoint, ApiDomain.Riot.GetEnumMemberValue());
        }

        public Uri Resolve(ValorantEndpointRegion region, string endpoint)
        {
            return BuildUri(region.GetEnumMemberValue(), endpoint, ApiDomain.Valorant.GetEnumMemberValue());
        }

        private Uri BuildUri(string region, string endpoint, string apiDomain) => new Uri($"{Constants.RIOT_API_BASE_URL.Replace("{region}", region).Replace("{domain}", apiDomain)}{endpoint}");
    }
}
