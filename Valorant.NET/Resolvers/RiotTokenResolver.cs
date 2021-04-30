using System;
using System.Collections.Generic;
using System.Text;

namespace Valorant.NET.Resolvers
{
    public class RiotTokenResolver : IRiotTokenResolver
    {
        public string Resolve()
        {
            var token = Environment.GetEnvironmentVariable(Constants.RIOT_API_TOKEN);
            if (string.IsNullOrWhiteSpace(token)) throw new ArgumentNullException(nameof(token));
            return token;
        }
    }
}
