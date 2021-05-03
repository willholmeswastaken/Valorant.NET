using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Valorant.NET.Handlers;
using Valorant.NET.Models.Exceptions;
using Valorant.NET.Resolvers;

namespace Valorant.NET
{
    public abstract class BaseRiotClient : IDisposable
    {
        private readonly HttpClient _riotHttpClient;
        private readonly IRiotApiResponseHandler _riotApiResponseHandler;

        protected BaseRiotClient(IRiotTokenResolver riotTokenResolver, IRiotApiResponseHandler riotApiResponseHandler)
        {
            _riotHttpClient = new HttpClient();
            _riotHttpClient.DefaultRequestHeaders.Add(Constants.RIOT_API_TOKEN_HEADER_KEY, riotTokenResolver.Resolve());
            _riotApiResponseHandler = riotApiResponseHandler;
        }

        protected async Task<T> GetAsync<T>(Uri url)
        {
            try
            {
                var response = await _riotHttpClient.GetAsync(url);
                await _riotApiResponseHandler.Execute(response);
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new RiotApiException(url.ToString(), ex);
            }
        }

        public void Dispose()
        {
            _riotHttpClient.Dispose();
        }
    }
}
