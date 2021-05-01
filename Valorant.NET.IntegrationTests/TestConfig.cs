using System;
using System.Collections.Generic;
using System.Text;

namespace Valorant.NET.IntegrationTests
{
    public class TestConfig
    {
        /// <summary>
        /// Your riot developer api token
        /// </summary>
        public string RiotToken { get; set; }

        /// <summary>
        /// Your gamename part to your riot id
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// Your tagline number part to your riot id
        /// </summary>
        public string TagLine { get; set; }

        /// <summary>
        /// Your player universally unique identifier
        /// </summary>
        public string Puuid { get; set; }
    }
}
