using System;
using Valorant.NET.Models;

namespace Valorant.NET.Resolvers
{
    /// <summary>
    /// Retrieves the api request url for a Riot request
    /// </summary>
    public interface IRiotApiUrlResolver
    {
        /// <summary>
        /// Resolves the api request url for non-valorant endpoints
        /// </summary>
        /// <param name="region">Defaulted to europe</param>
        /// <param name="endpoint">e.g /account/by-riot-id/{gameName}/{tagLine}</param>
        /// <returns></returns>
        Uri Resolve(NonValorantEndpointRegion region, string endpoint);

        /// <summary>
        /// Resolves the api request url for valorant endpoints
        /// </summary>
        /// <param name="region">Defaulted to europe</param>
        /// <param name="endpoint">e.g /account/by-riot-id/{gameName}/{tagLine}</param>
        /// <returns></returns>
        Uri Resolve(ValorantEndpointRegion region, string endpoint);
    }
}
