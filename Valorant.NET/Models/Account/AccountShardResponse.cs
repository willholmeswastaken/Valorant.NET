using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Valorant.NET.Models.Account
{
    [ExcludeFromCodeCoverage]
    public class AccountShardResponse
    {
        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("game")]
        public string Game { get; set; }

        [JsonProperty("activeShard")]
        public string ActiveShard { get; set; }
    }
}
