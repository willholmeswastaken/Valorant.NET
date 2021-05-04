using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Valorant.NET.Handlers;
using Valorant.NET.Models.Exceptions;
using Valorant.NET.Resolvers;

namespace Valorant.NET.Clients
{
    public class RiotHttpClient : IRiotHttpClient
    {
        public readonly HttpClient _httpClient;
        private readonly IRiotApiResponseHandler _riotApiResponseHandler;

        public RiotHttpClient(IRiotTokenResolver riotTokenResolver, IRiotApiResponseHandler riotApiResponseHandler, HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.DefaultRequestHeaders.Add(Constants.RIOT_API_TOKEN_HEADER_KEY, riotTokenResolver.Resolve());
            _riotApiResponseHandler = riotApiResponseHandler;
        }

        public async Task<T> GetAsync<T>(Uri uri) where T : class
        {
            try
            {
                var response = await _httpClient.GetAsync(uri);
                await _riotApiResponseHandler.Execute(response);
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new RiotApiException(uri.ToString(), ex);
            }
        }
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
