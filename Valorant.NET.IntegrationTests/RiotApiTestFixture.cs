using System;
using System.IO;
using Newtonsoft.Json;

namespace Valorant.NET.IntegrationTests
{
    public class RiotApiTestFixture
    {
        public TestConfig Config { get; private set; }

        public RiotApiTestFixture()
        {
            using StreamReader r = new StreamReader("testConfig.json");

            string json = r.ReadToEnd();
            Config = JsonConvert.DeserializeObject<TestConfig>(json);
            Environment.SetEnvironmentVariable(Constants.RIOT_API_TOKEN, Config.RiotToken);
        }
    }
}
