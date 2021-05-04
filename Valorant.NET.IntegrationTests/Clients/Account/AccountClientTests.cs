using FluentAssertions;
using System;
using System.Threading.Tasks;
using Valorant.NET.Clients;
using Valorant.NET.Clients.Account;
using Valorant.NET.Handlers;
using Valorant.NET.Resolvers;
using Xunit;

namespace Valorant.NET.IntegrationTests.Clients.Account
{
    public class AccountClientTests : IClassFixture<RiotApiTestFixture>, IDisposable
    {
        private readonly RiotApiTestFixture _fixture;
        private readonly AccountClient _accountClient;

        public AccountClientTests(RiotApiTestFixture fixture)
        {
            _fixture = fixture;
            _accountClient = new AccountClient(new RiotHttpClient(new RiotTokenResolver(), new RiotApiResponseHandler()), new RiotApiUrlResolver());
        }

        [Fact]
        public async Task GetByRiotId_Should_return_player_profile()
        {
            var response = await _accountClient.GetByRiotId(_fixture.Config.GameName, _fixture.Config.TagLine);

            response.Should().NotBeNull();
            response.Puuid.Should().Be(_fixture.Config.Puuid);
            response.GameName.Should().Be(_fixture.Config.GameName);
            response.TagLine.Should().Be(_fixture.Config.TagLine);
        }

        [Fact]
        public async Task GetByPuuid_Should_return_player_profile()
        {
            var response = await _accountClient.GetByPuuid(_fixture.Config.Puuid);

            response.Should().NotBeNull();
            response.Puuid.Should().Be(_fixture.Config.Puuid);
            response.GameName.Should().Be(_fixture.Config.GameName);
            response.TagLine.Should().Be(_fixture.Config.TagLine);
        }

        [Fact]
        public async Task GetActiveShardByPuuid_Should_return_player_profile()
        {
            var response = await _accountClient.GetActivePlayerShard(_fixture.Config.Puuid);

            response.Should().NotBeNull();
            response.Puuid.Should().Be(_fixture.Config.Puuid);
            response.Game.Should().Be("val");
            response.activeShard.Should().Be("eu");
        }

        public void Dispose()
        {
            _accountClient.Dispose();
        }
    }
}
