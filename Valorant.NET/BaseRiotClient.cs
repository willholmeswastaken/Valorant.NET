using System;
using System.Net.Http;
using Valorant.NET.Resolvers;

namespace Valorant.NET
{
    public class BaseRiotClient : IDisposable
    {
        protected readonly HttpClient _riotHttpClient;

        protected BaseRiotClient(IRiotTokenResolver riotTokenResolver)
        {
            _riotHttpClient = new HttpClient();
            _riotHttpClient.DefaultRequestHeaders.Add(Constants.RIOT_API_TOKEN_HEADER_KEY, riotTokenResolver.Resolve());
        }

        public void Dispose()
        {
            _riotHttpClient.Dispose();
        }
    }
}
