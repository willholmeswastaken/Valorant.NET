using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

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
