using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Valorant.NET.Models.Account
{
    [ExcludeFromCodeCoverage]
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
