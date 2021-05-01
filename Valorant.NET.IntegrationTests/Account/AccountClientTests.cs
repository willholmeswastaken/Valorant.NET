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
        [Fact]
        public async Task Should_return_200_ok()
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
    }
}
