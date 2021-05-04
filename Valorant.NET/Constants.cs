﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Valorant.NET
{
    public sealed class Constants
    {
        public const string RIOT_API_BASE_URL = "https://{region}.api.riotgames.com/{domain}";
        public const string RIOT_API_TOKEN_HEADER_KEY = "X-Riot-Token";
        public const string RIOT_API_TOKEN = "riot-api-token";

        class RiotEndpoints
        {
            public const string ACCOUNT = "/account/v1";
            public const string RANKED = "/ranked/v1";
        }
    }
}
