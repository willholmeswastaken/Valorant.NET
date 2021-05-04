using System.Runtime.Serialization;

namespace Valorant.NET.Models
{
    public enum NonValorantEndpointRegion
    {
        [EnumMember(Value = "americas")]
        Americas,
        [EnumMember(Value = "asia")]
        Asia,
        [EnumMember(Value = "esports")]
        Esports,
        [EnumMember(Value = "europe")]
        Europe
    }
}
