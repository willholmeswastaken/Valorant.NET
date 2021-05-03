using System;
using System.Threading.Tasks;
using Valorant.NET.Handlers;
using Valorant.NET.Models;
using Valorant.NET.Models.Account;
using Valorant.NET.Resolvers;

namespace Valorant.NET.Clients.Account
{
    public class AccountClient : BaseRiotClient, IAccountClient
    {
        private readonly IRiotApiUrlResolver _riotApiUrlResolver;

        private const string AccountsUrl = "/account/v1";

        public AccountClient(IRiotTokenResolver riotTokenResolver,
            IRiotApiUrlResolver riotApiUrlResolver,
            IRiotApiResponseHandler riotApiResponseHandler)
            : base(riotTokenResolver, riotApiResponseHandler)
        {
            _riotApiUrlResolver = riotApiUrlResolver;
        }

        public async Task<AccountResponse> GetByRiotId(string gameName, string tagLine, Region region = Region.Europe)
        {
            if (string.IsNullOrWhiteSpace(gameName)) throw new ArgumentNullException(nameof(gameName));
            if (string.IsNullOrWhiteSpace(tagLine)) throw new ArgumentNullException(nameof(tagLine));

            var url = _riotApiUrlResolver.Resolve(region, $"{AccountsUrl}/accounts/by-riot-id/{gameName}/{tagLine}");

            return await GetAsync<AccountResponse>(url);
        }

        public async Task<AccountResponse> GetByPuuid(string puuid, Region region = Region.Europe)
        {
            if (string.IsNullOrWhiteSpace(puuid)) throw new ArgumentNullException(nameof(puuid));

            var url = _riotApiUrlResolver.Resolve(region, $"{AccountsUrl}/accounts/by-puuid/{puuid}");

            return await GetAsync<AccountResponse>(url);
        }

        public async Task<AccountShardResponse> GetActivePlayerShard(string puuid, Region region = Region.Europe)
        {
            if (string.IsNullOrWhiteSpace(puuid)) throw new ArgumentNullException(nameof(puuid));

            var url = _riotApiUrlResolver.Resolve(region, $"{AccountsUrl}/active-shards/by-game/val/by-puuid/{puuid}");

            return await GetAsync<AccountShardResponse>(url);
        }
    }
}
