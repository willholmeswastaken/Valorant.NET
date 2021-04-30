using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Valorant.NET.Models.Exceptions
{
    public class RiotApiException : Exception
    {
        public RiotApiException(string url, Exception ex)
            : base("Failed to communicate with Riot Api", ex)
        {
            Data.Add(nameof(url), url);
        }

        public RiotApiException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            Data.Add(nameof(statusCode), statusCode);
        }
    }
}
