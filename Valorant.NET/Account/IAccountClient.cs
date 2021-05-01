using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Valorant.NET.Models;

namespace Valorant.NET.Account
{
    public interface IAccountClient
    {
        /// <summary>
        /// Retrieves the account by the riot id of the user i.e. SevenZ#2070
        /// </summary>
        /// <param name="gameName">SevenZ</param>
        /// <param name="tagLine">2070</param>
        /// <param name="region">Api url region, choose the closest to you</param>
        /// <returns>Account details</returns>
        Task<AccountResponse> GetByRiotId(string gameName, string tagLine, Region region = Region.Europe);

        /// <summary>
        /// Retrieves the account by the riot puuid of the user.
        /// </summary>
        /// <param name="puuid">Player universally unique identifier</param>
        /// <param name="region">Api url region, choose the closest to you</param>
        /// <returns>Account details</returns>
        Task<AccountResponse> GetByPuuid(string puuid, Region region = Region.Europe);
    }
}
