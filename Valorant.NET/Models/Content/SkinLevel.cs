using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Valorant.NET.Models.Content
{
    public class SkinLevel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("localizedNames")]
        public LocalizedNames LocalizedNames { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("assetName")]
        public string AssetName { get; set; }
    }
}
