using System;
using System.Threading.Tasks;
using Valorant.NET.Models;
using Valorant.NET.Models.Account;

namespace Valorant.NET.Clients.Account
{
    public interface IAccountClient : IDisposable
    {
        /// <summary>
        /// Retrieves the account by the riot id of the user i.e. SevenZ#2070
        /// </summary>
        /// <param name="gameName">SevenZ</param>
        /// <param name="tagLine">2070</param>
        /// <param name="region">Api url region, choose the closest to you</param>
        /// <returns>Account details</returns>
        Task<AccountResponse> GetByRiotId(string gameName, string tagLine, NonValorantEndpointRegion region = NonValorantEndpointRegion.Europe);

        /// <summary>
        /// Retrieves the account by the riot puuid of the user.
        /// </summary>
        /// <param name="puuid">Player universally unique identifier</param>
        /// <param name="region">Api url region, choose the closest to you</param>
        /// <returns>Account details</returns>
        Task<AccountResponse> GetByPuuid(string puuid, NonValorantEndpointRegion region = NonValorantEndpointRegion.Europe);


        /// <summary>
        /// Retrieves the active player shard such as eu, na etc.
        /// </summary>
        /// <param name="puuid">Player universally unique identifier</param>
        /// <returns>Active shard with puuid</returns>
        Task<AccountShardResponse> GetActivePlayerShard(string puuid, NonValorantEndpointRegion region = NonValorantEndpointRegion.Europe);
    }
}
