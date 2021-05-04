using System.Runtime.Serialization;

namespace Valorant.NET.Models
{
    public enum ValorantEndpointRegion
    {
        [EnumMember(Value = "ap")]
        AP,
        [EnumMember(Value = "br")]
        BR,
        [EnumMember(Value = "eu")]
        EU,
        [EnumMember(Value = "kr")]
        KR,
        [EnumMember(Value = "latam")]
        LATAM,
        [EnumMember(Value = "na")]
        NA
    }
}
