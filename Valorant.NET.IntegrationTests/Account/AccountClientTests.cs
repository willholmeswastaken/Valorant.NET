using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Valorant.NET.Account;
using Valorant.NET.Handlers;
using Valorant.NET.Resolvers;
using Xunit;

namespace Valorant.NET.IntegrationTests.Account
{
    public class AccountClientTests : IClassFixture<RiotApiTestFixture>
    {
        private readonly RiotApiTestFixture _fixture;

        public AccountClientTests(RiotApiTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetByRiotId_Should_return_200_ok()
        {
            var gameName = "SevenZ";
            var tagLine = "2070";

            var account = new AccountClient(new RiotTokenResolver(), new RiotApiUrlResolver(), new RiotApiResponseHandler());

            var response = await account.GetByRiotId(gameName, tagLine);

            response.Should().NotBeNull();
            response.Puuid.Should().NotBeNullOrWhiteSpace();
            response.GameName.Should().Be(gameName);
            response.TagLine.Should().Be(tagLine);
        }

        [Fact]
        public async Task GetByPuuid_Should_return_200_ok()
        {
            var puuid = "cgonD5hiAvh0KIXi324gdN-_SKKPp-UiSxfOZeEkO3NL4fr2cODZ15ZbDi-dOltm7_O9c1wXucnIZg";

            var account = new AccountClient(new RiotTokenResolver(), new RiotApiUrlResolver(), new RiotApiResponseHandler());

            var response = await account.GetByPuuid(puuid);

            response.Should().NotBeNull();
            response.Puuid.Should().Be(puuid);
            response.GameName.Should().Be("SevenZ");
            response.TagLine.Should().Be("2070");
        }
    }
}
