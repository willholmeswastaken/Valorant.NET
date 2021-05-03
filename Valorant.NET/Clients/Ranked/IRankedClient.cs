using System;
using System.Threading.Tasks;
using Valorant.NET.Models;
using Valorant.NET.Models.Ranked;

namespace Valorant.NET.Clients.Ranked
{
    public interface IRankedClient
    {
        /// <summary>
        /// This returns the current leaderboard in ranked for a given region
        /// </summary>
        /// <param name="actId">The guid of the current act</param>
        /// <param name="startPositionIndex">The leaderboard index of which player position you want to start at, starts from 0</param>
        /// <param name="lastPositionIndex">The leaderboard index of which player position you want to end at</param>
        /// <param name="region">The region you want to get the leaderboard for</param>
        /// <returns></returns>
        Task<RankedResponse> GetLeaderboardByAct(string actId, int startPositionIndex, int lastPositionIndex, Region region = Region.Europe);
    }
}
