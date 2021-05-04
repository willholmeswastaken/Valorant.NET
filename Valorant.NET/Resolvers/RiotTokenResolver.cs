using System;
using Valorant.NET.Models.Exceptions;

namespace Valorant.NET.Resolvers
{
    public class RiotTokenResolver : IRiotTokenResolver
    {
        public string Resolve()
        {
            var token = Environment.GetEnvironmentVariable(Constants.RIOT_API_TOKEN);
            return string.IsNullOrWhiteSpace(token)
                ? throw new MissingRiotApiTokenException()
                : token;
        }
    }
}
