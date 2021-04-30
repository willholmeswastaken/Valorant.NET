using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Valorant.NET.Handlers;
using Valorant.NET.Models;
using Valorant.NET.Models.Exceptions;
using Valorant.NET.Resolvers;

namespace Valorant.NET.Account
{
    public class AccountClient : IAccountClient
    {
        private readonly HttpClient _client;
        private readonly IRiotApiResponseHandler _riotApiResponseHandler;

        private const string AccountsUrl = "/account/v1/accounts";

        public AccountClient(IRiotTokenResolver tokenResolver, IRiotApiResponseHandler riotApiResponseHandler)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add(Constants.RIOT_API_TOKEN_HEADER_KEY, tokenResolver.Resolve());
            _riotApiResponseHandler = riotApiResponseHandler;
        }

        public async Task<AccountResponse> GetByRiotId(string gameName, string tagLine, Region region = Region.Europe)
        {
            if (string.IsNullOrWhiteSpace(gameName)) throw new ArgumentNullException(nameof(gameName));
            if (string.IsNullOrWhiteSpace(tagLine)) throw new ArgumentNullException(nameof(tagLine));

            var url = new Uri($"{Constants.RIOT_API_BASE_URL.Replace("{region}", region.ToString())}{AccountsUrl}/by-riot-id/{gameName}/{tagLine}");
            try
            {
                var response = await _client.GetAsync(url);
                await _riotApiResponseHandler.Execute(response);

                return JsonConvert.DeserializeObject<AccountResponse>(await (response.Content.ReadAsStringAsync()));
            }
            catch (Exception ex)
            {
                throw new RiotApiException(url.ToString(), ex);
            }
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
