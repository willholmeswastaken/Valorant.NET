﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Valorant.NET.Models.Ranked
{
    public class RankedResponse
    {
        [JsonProperty("actId")]
        public string ActId { get; set; }

        [JsonProperty("players")]
        public IEnumerable<Player> Players { get; set; }

        [JsonProperty("totalPlayers")]
        public int TotalPlayers { get; set; }

        [JsonProperty("immortalStartingPage")]
        public int ImmortalStartingPage { get; set; }

        [JsonProperty("topTierRRThreshold")]
        public int TopTierRRThreshold { get; set; }

        [JsonProperty("shard")]
        public string Shard { get; set; }
    }
}
