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
            var account = new AccountClient(new RiotTokenResolver(), new RiotApiUrlResolver(), new RiotApiResponseHandler());

            var response = await account.GetByRiotId(_fixture.Config.GameName, _fixture.Config.TagLine);

            response.Should().NotBeNull();
            response.Puuid.Should().Be(_fixture.Config.Puuid);
            response.GameName.Should().Be(_fixture.Config.GameName);
            response.TagLine.Should().Be(_fixture.Config.TagLine);
        }

        [Fact]
        public async Task GetByPuuid_Should_return_200_ok()
        {
            var account = new AccountClient(new RiotTokenResolver(), new RiotApiUrlResolver(), new RiotApiResponseHandler());

            var response = await account.GetByPuuid(_fixture.Config.Puuid);

            response.Should().NotBeNull();
            response.Puuid.Should().Be(_fixture.Config.Puuid);
            response.GameName.Should().Be(_fixture.Config.GameName);
            response.TagLine.Should().Be(_fixture.Config.TagLine);
        }

        [Fact]
        public async Task GetActiveShardByPuuid_Should_return_200_ok()
        {
            var account = new AccountClient(new RiotTokenResolver(), new RiotApiUrlResolver(), new RiotApiResponseHandler());

            var response = await account.GetActivePlayerShard(_fixture.Config.Puuid);

            response.Should().NotBeNull();
            response.Puuid.Should().Be(_fixture.Config.Puuid);
            response.Game.Should().Be("val");
            response.activeShard.Should().Be("eu");
        }
    }
}
