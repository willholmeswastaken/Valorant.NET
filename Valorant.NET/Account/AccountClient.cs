using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Valorant.NET.Handlers;
using Valorant.NET.Models;
using Valorant.NET.Models.Exceptions;
using Valorant.NET.Resolvers;

namespace Valorant.NET.Account
{
    public class AccountClient : BaseRiotClient, IAccountClient
    {
        private readonly IRiotApiUrlResolver _riotApiUrlResolver;
        private readonly IRiotApiResponseHandler _riotApiResponseHandler;

        private const string AccountsUrl = "/account/v1";

        public AccountClient(IRiotTokenResolver riotTokenResolver,
            IRiotApiUrlResolver riotApiUrlResolver,
            IRiotApiResponseHandler riotApiResponseHandler)
            : base(riotTokenResolver)
        {
            _riotApiUrlResolver = riotApiUrlResolver;
            _riotApiResponseHandler = riotApiResponseHandler;
        }

        public async Task<AccountResponse> GetByRiotId(string gameName, string tagLine, Region region = Region.Europe)
        {
            if (string.IsNullOrWhiteSpace(gameName)) throw new ArgumentNullException(nameof(gameName));
            if (string.IsNullOrWhiteSpace(tagLine)) throw new ArgumentNullException(nameof(tagLine));

            var url = _riotApiUrlResolver.Resolve(region, $"{AccountsUrl}/accounts/by-riot-id/{gameName}/{tagLine}");
            try
            {
                var response = await _riotHttpClient.GetAsync(url);
                await _riotApiResponseHandler.Execute(response);
                return JsonConvert.DeserializeObject<AccountResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new RiotApiException(url.ToString(), ex);
            }
        }

        public async Task<AccountResponse> GetByPuuid(string puuid, Region region = Region.Europe)
        {
            if (string.IsNullOrWhiteSpace(puuid)) throw new ArgumentNullException(nameof(puuid));

            var url = _riotApiUrlResolver.Resolve(region, $"{AccountsUrl}/accounts/by-puuid/{puuid}");

            try
            {
                var response = await _riotHttpClient.GetAsync(url);
                await _riotApiResponseHandler.Execute(response);
                return JsonConvert.DeserializeObject<AccountResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new RiotApiException(url.ToString(), ex);
            }
        }

        public async Task<AccountShardResponse> GetActivePlayerShard(string puuid, Region region = Region.Europe)
        {
            if (string.IsNullOrWhiteSpace(puuid)) throw new ArgumentNullException(nameof(puuid));

            var url = _riotApiUrlResolver.Resolve(region, $"{AccountsUrl}/active-shards/by-game/val/by-puuid/{puuid}");

            try
            {
                var response = await _riotHttpClient.GetAsync(url);
                await _riotApiResponseHandler.Execute(response);
                return JsonConvert.DeserializeObject<AccountShardResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new RiotApiException(url.ToString(), ex);
            }
        }
    }
}
