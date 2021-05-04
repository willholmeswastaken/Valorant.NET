using System;
using System.Collections.Generic;
using System.Text;

namespace Valorant.NET.Models.Exceptions
{
    public class MissingRiotApiTokenException : Exception
    {
        public MissingRiotApiTokenException()
            : base($"Failed to find the environment variable {Constants.RIOT_API_TOKEN} containing the riot api token.")
        {
        }
    }
}
