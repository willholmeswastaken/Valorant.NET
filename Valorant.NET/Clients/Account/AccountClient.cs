using System;
using System.Threading.Tasks;
using Valorant.NET.Models;
using Valorant.NET.Models.Account;
using Valorant.NET.Resolvers;

namespace Valorant.NET.Clients.Account
{
    public class AccountClient : IAccountClient
    {
        private readonly IRiotHttpClient _httpClient;
        private readonly IRiotApiUrlResolver _riotApiUrlResolver;

        private const string AccountsUrl = "/account/v1";

        public AccountClient(IRiotHttpClient httpClient,
            IRiotApiUrlResolver riotApiUrlResolver)
        {
            _riotApiUrlResolver = riotApiUrlResolver;
            _httpClient = httpClient;
        }

        public async Task<AccountResponse> GetByRiotId(string gameName, string tagLine, NonValorantEndpointRegion region = NonValorantEndpointRegion.Europe)
        {
            if (string.IsNullOrWhiteSpace(gameName)) throw new ArgumentNullException(nameof(gameName));
            if (string.IsNullOrWhiteSpace(tagLine)) throw new ArgumentNullException(nameof(tagLine));

            var url = _riotApiUrlResolver.Resolve(region, $"{AccountsUrl}/accounts/by-riot-id/{gameName}/{tagLine}");

            return await _httpClient.GetAsync<AccountResponse>(url);
        }

        public async Task<AccountResponse> GetByPuuid(string puuid, NonValorantEndpointRegion region = NonValorantEndpointRegion.Europe)
        {
            if (string.IsNullOrWhiteSpace(puuid)) throw new ArgumentNullException(nameof(puuid));

            var url = _riotApiUrlResolver.Resolve(region, $"{AccountsUrl}/accounts/by-puuid/{puuid}");

            return await _httpClient.GetAsync<AccountResponse>(url);
        }

        public async Task<AccountShardResponse> GetActivePlayerShard(string puuid, NonValorantEndpointRegion region = NonValorantEndpointRegion.Europe)
        {
            if (string.IsNullOrWhiteSpace(puuid)) throw new ArgumentNullException(nameof(puuid));

            var url = _riotApiUrlResolver.Resolve(region, $"{AccountsUrl}/active-shards/by-game/val/by-puuid/{puuid}");

            return await _httpClient.GetAsync<AccountShardResponse>(url);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
