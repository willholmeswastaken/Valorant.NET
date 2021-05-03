using System;
using Newtonsoft.Json;

namespace Valorant.NET.Models.Account
{
    public class AccountShardResponse
    {
        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("game")]
        public string Game { get; set; }

        [JsonProperty("activeShard")]
        public string activeShard { get; set; }
    }
}
