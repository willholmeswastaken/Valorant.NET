using System;
using Valorant.NET.Models;

namespace Valorant.NET.Resolvers
{
    public class RiotApiUrlResolver : IRiotApiUrlResolver
    {
        public Uri Resolve(Region region, string endpoint)
        {
            return new Uri($"{Constants.RIOT_API_BASE_URL.Replace("{region}", region.ToString())}{endpoint}");
        }
    }
}
