using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Valorant.NET.Helpers
{
    public static class EnumHelpers
    {
        public static string GetEnumMemberValue<T>(this T value)
            where T : Enum
        {
            return typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }
    }
}
