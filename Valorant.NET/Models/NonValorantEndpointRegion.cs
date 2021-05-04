using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

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
