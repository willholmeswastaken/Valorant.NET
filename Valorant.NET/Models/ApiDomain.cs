using System.Runtime.Serialization;

namespace Valorant.NET.Models
{
    public enum ApiDomain
    {
        [EnumMember(Value = "riot")]
        Riot,
        [EnumMember(Value = "val")]
        Valorant
    }
}
