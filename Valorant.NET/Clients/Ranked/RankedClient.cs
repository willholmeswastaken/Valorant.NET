using System;
using System.Threading.Tasks;
using Valorant.NET.Models;
using Valorant.NET.Models.Exceptions;
using Valorant.NET.Models.Ranked;
using Valorant.NET.Resolvers;

namespace Valorant.NET.Clients.Ranked
{
    public class RankedClient : IRankedClient
    {
        private readonly IRiotHttpClient _httpClient;
        private readonly IRiotApiUrlResolver _riotApiUrlResolver;

        private const string RankedUrl = "/ranked/v1";
        private const int MaximumPlayersReturnedByRequest = 200;

        public RankedClient(IRiotHttpClient httpClient,
            IRiotApiUrlResolver riotApiUrlResolver)
        {
            _riotApiUrlResolver = riotApiUrlResolver;
            _httpClient = httpClient;
        }

        public async Task<RankedResponse> GetLeaderboardByAct(string actId, int startPositionIndex, int numberOfPlayersToReturn = MaximumPlayersReturnedByRequest, ValorantEndpointRegion region = ValorantEndpointRegion.EU)
        {
            if (string.IsNullOrWhiteSpace(actId)) throw new ArgumentNullException(actId);
            if ((startPositionIndex + 1) > numberOfPlayersToReturn) throw new StartPositionGreaterThanTotalPlayersReturnedException(startPositionIndex, numberOfPlayersToReturn);

            var url = _riotApiUrlResolver.Resolve(region, $"{RankedUrl}/leaderboards/by-act/{actId}?size={numberOfPlayersToReturn}&?startIndex={startPositionIndex}");

            return await _httpClient.GetAsync<RankedResponse>(url);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
