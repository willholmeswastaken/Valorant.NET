using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Valorant.NET.Models.Content
{
    [ExcludeFromCodeCoverage]
    public class Act
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("localizedNames")]
        public LocalizedNames LocalizedNames { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
