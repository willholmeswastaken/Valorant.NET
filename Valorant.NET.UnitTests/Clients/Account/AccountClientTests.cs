using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Valorant.NET.Clients;
using Valorant.NET.Clients.Account;
using Valorant.NET.Models;
using Valorant.NET.Models.Account;
using Valorant.NET.Resolvers;
using Xunit;

namespace Valorant.NET.UnitTests.Clients.Account
{
    public class AccountClientTests
    {
        private Mock<IRiotHttpClient> _mockPlayerResponseHttpClient;
        private Mock<IRiotApiUrlResolver> _mockRiotApiUrlResolver;
        private const NonValorantEndpointRegion PlayerRegion = NonValorantEndpointRegion.Europe;
        private readonly string PlayerPuuid = Guid.NewGuid().ToString();
        private const string PlayerGameName = "SevenZ";
        private const string PlayerTagLine = "2070";
        private static Uri ExpectedUri = new Uri("https://europe.api.riotgames.com/riot");

        public AccountClientTests()
        {
            _mockPlayerResponseHttpClient = new Mock<IRiotHttpClient>();
            _mockRiotApiUrlResolver = new Mock<IRiotApiUrlResolver>();
        }

        [Fact]
        public async Task GetByRiotId_Should_Return_Player()
        {
            ConfigureMocks($"/account/v1/accounts/by-riot-id/{PlayerGameName}/{PlayerTagLine}");
            using var accountClient = new AccountClient(_mockPlayerResponseHttpClient.Object, _mockRiotApiUrlResolver.Object);

            var response = await accountClient.GetByRiotId(PlayerGameName, PlayerTagLine, PlayerRegion);

            response.Should().NotBeNull();
            response.Puuid.Should().Be(PlayerPuuid);
            response.GameName.Should().Be(PlayerGameName);
            response.TagLine.Should().Be(PlayerTagLine);

            _mockPlayerResponseHttpClient.VerifyAll();
            _mockRiotApiUrlResolver.VerifyAll();
        }

        [Fact]
        public async Task GetByRiotId_Should_Throw_When_GameName_Invalid()
        {
            using var accountClient = new AccountClient(Mock.Of<IRiotHttpClient>(), Mock.Of<IRiotApiUrlResolver>());

            var getByRiotIdResponseException = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await accountClient.GetByRiotId(string.Empty, string.Empty);
            });

            getByRiotIdResponseException.ParamName.Should().Be("gameName");
        }

        [Fact]
        public async Task GetByRiotId_Should_Throw_When_TagLine_Invalid()
        {
            using var accountClient = new AccountClient(Mock.Of<IRiotHttpClient>(), Mock.Of<IRiotApiUrlResolver>());

            var getByRiotIdResponseException = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await accountClient.GetByRiotId("SevenZ", string.Empty);
            });

            getByRiotIdResponseException.ParamName.Should().Be("tagLine");
        }

        [Fact]
        public async Task GetByPuuid_Should_Return_Player()
        {
            ConfigureMocks($"/account/v1/accounts/by-puuid/{PlayerPuuid}");
            using var accountClient = new AccountClient(_mockPlayerResponseHttpClient.Object, _mockRiotApiUrlResolver.Object);

            var response = await accountClient.GetByPuuid(PlayerPuuid, PlayerRegion);

            response.Should().NotBeNull();
            response.Puuid.Should().Be(PlayerPuuid);
            response.GameName.Should().Be(PlayerGameName);
            response.TagLine.Should().Be(PlayerTagLine);

            _mockPlayerResponseHttpClient.VerifyAll();
            _mockRiotApiUrlResolver.VerifyAll();
        }

        [Fact]
        public async Task GetByPuuid_Should_Throw_When_Puuid_Invalid()
        {
            using var accountClient = new AccountClient(Mock.Of<IRiotHttpClient>(), Mock.Of<IRiotApiUrlResolver>());

            var getByRiotIdResponseException = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await accountClient.GetByPuuid(string.Empty);
            });

            getByRiotIdResponseException.ParamName.Should().Be("puuid");
        }

        [Fact]
        public async Task GetActivePlayerShard_Should_Return_Details()
        {
            var endpoint = $"/account/v1/active-shards/by-game/val/by-puuid/{PlayerPuuid}";
            var mockShard = "eu";
            ConfigureRiotApiUrlResolver(endpoint);

            _mockPlayerResponseHttpClient.Setup(x => x.GetAsync<AccountShardResponse>(It.Is<Uri>(inputUri => inputUri == ExpectedUri)))
                .ReturnsAsync(new AccountShardResponse { ActiveShard = mockShard, Game = PlayerGameName, Puuid = PlayerPuuid });

            using var accountClient = new AccountClient(_mockPlayerResponseHttpClient.Object, _mockRiotApiUrlResolver.Object);

            var response = await accountClient.GetActivePlayerShard(PlayerPuuid, PlayerRegion);

            response.Should().NotBeNull();
            response.Puuid.Should().Be(PlayerPuuid);
            response.Game.Should().Be(PlayerGameName);
            response.ActiveShard.Should().Be(mockShard);

            _mockPlayerResponseHttpClient.VerifyAll();
            _mockRiotApiUrlResolver.VerifyAll();
        }

        [Fact]
        public async Task GetActivePlayerShard_Should_Throw_When_Puuid_Invalid()
        {
            using var accountClient = new AccountClient(Mock.Of<IRiotHttpClient>(), Mock.Of<IRiotApiUrlResolver>());

            var getByRiotIdResponseException = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await accountClient.GetActivePlayerShard(string.Empty);
            });

            getByRiotIdResponseException.ParamName.Should().Be("puuid");
        }

        private void ConfigureMocks(string endpoint)
        {
            ConfigureRiotHttpClientForPlayerResponse();
            ConfigureRiotApiUrlResolver(endpoint);
        }

        private void ConfigureRiotHttpClientForPlayerResponse()
        {
            _mockPlayerResponseHttpClient.Setup(x => x.GetAsync<AccountResponse>(It.Is<Uri>(inputUri => inputUri == ExpectedUri)))
                .ReturnsAsync(new AccountResponse { Puuid = PlayerPuuid, GameName = PlayerGameName, TagLine = PlayerTagLine })
                .Verifiable();
        }

        private void ConfigureRiotApiUrlResolver(string endpoint)
        {
            _mockRiotApiUrlResolver.Setup(x => x.Resolve(It.Is<NonValorantEndpointRegion>(inputRegion => inputRegion == PlayerRegion), It.Is<string>(inputEndpoint => inputEndpoint == endpoint)))
                .Returns(ExpectedUri)
                .Verifiable();
        }
    }
}
