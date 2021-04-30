using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Valorant.NET.Models
{
    public class AccountResponse
    {
        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("gameName")]
        public string GameName { get; set; }

        [JsonProperty("tagLine")]
        public string TagLine { get; set; }
    }
}
