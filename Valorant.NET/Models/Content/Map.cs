﻿using Newtonsoft.Json;

namespace Valorant.NET.Models.Content
{
    public class Map
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("localizedNames")]
        public LocalizedNames LocalizedNames { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("assetName")]
        public string AssetName { get; set; }

        [JsonProperty("assetPath")]
        public string AssetPath { get; set; }
    }
}
