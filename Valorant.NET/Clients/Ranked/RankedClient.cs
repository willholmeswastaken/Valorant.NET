using System;
using System.Threading.Tasks;
using Valorant.NET.Handlers;
using Valorant.NET.Models;
using Valorant.NET.Models.Exceptions;
using Valorant.NET.Models.Ranked;
using Valorant.NET.Resolvers;

namespace Valorant.NET.Clients.Ranked
{
    public class RankedClient : BaseRiotClient, IRankedClient
    {
        private readonly IRiotApiUrlResolver _riotApiUrlResolver;

        private const string RankedUrl = "/ranked/v1";
        private const int MaximumPlayersReturnedByRequest = 200;

        public RankedClient(IRiotTokenResolver riotTokenResolver,
            IRiotApiUrlResolver riotApiUrlResolver,
            IRiotApiResponseHandler riotApiResponseHandler)
            : base(riotTokenResolver, riotApiResponseHandler)
        {
            _riotApiUrlResolver = riotApiUrlResolver;
        }

        public async Task<RankedResponse> GetLeaderboardByAct(string actId, int startPositionIndex, int numberOfPlayersToReturn = MaximumPlayersReturnedByRequest, ValorantEndpointRegion region = ValorantEndpointRegion.EU)
        {
            if (string.IsNullOrWhiteSpace(actId)) throw new ArgumentNullException(actId);
            if ((startPositionIndex + 1) > numberOfPlayersToReturn) throw new StartPositionGreaterThanTotalPlayersReturnedException(startPositionIndex, numberOfPlayersToReturn);

            var url = _riotApiUrlResolver.Resolve(region, $"{RankedUrl}/leaderboards/by-act/{actId}?size={numberOfPlayersToReturn}&?startIndex={startPositionIndex}");

            return await GetAsync<RankedResponse>(url);
        }
    }
}
