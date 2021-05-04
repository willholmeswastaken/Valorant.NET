using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Valorant.NET.Models.Ranked
{
    [ExcludeFromCodeCoverage]
    public class Player
    {
        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("gameName")]
        public string GameName { get; set; }

        [JsonProperty("tagLine")]
        public string TagLine { get; set; }

        [JsonProperty("leaderboardRank")]
        public int LeaderboardRank { get; set; }

        [JsonProperty("rankedRating")]
        public int RankedRating { get; set; }

        [JsonProperty("numberOfWins")]
        public int NumberOfWins { get; set; }

        [JsonProperty("competitiveTier")]
        public int CompetitiveTier { get; set; }
    }
}
