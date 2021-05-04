using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Valorant.NET.Models.Content
{
    [ExcludeFromCodeCoverage]
    public class Character
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
