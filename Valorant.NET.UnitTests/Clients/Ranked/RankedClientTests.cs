using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valorant.NET.Clients;
using Valorant.NET.Clients.Ranked;
using Valorant.NET.Models;
using Valorant.NET.Models.Exceptions;
using Valorant.NET.Models.Ranked;
using Valorant.NET.Resolvers;
using Xunit;

namespace Valorant.NET.UnitTests.Clients.Ranked
{
    public class RankedClientTests
    {
        [Fact]
        public async Task Should_Return_Ranked_Leaderboard_By_Act()
        {
            var region = ValorantEndpointRegion.EU;
            var act = Guid.NewGuid().ToString();
            var numberOfPlayersToReturn = 2;
            var startPositionIndex = 0;

            var endpoint = $"/ranked/v1/leaderboards/by-act/{act}?size={numberOfPlayersToReturn}&?startIndex={startPositionIndex}";
            var expectedUri = new Uri("https://eu.api.riotgames.com/val");

            var mockApiUrlResolver = new Mock<IRiotApiUrlResolver>();
            mockApiUrlResolver.Setup(x => x.Resolve(It.Is<ValorantEndpointRegion>(inputRegion => inputRegion == region), It.Is<string>(inputEndpoint => inputEndpoint == endpoint)))
                .Returns(expectedUri)
                .Verifiable();

            var mockRiotHttpClient = new Mock<IRiotHttpClient>();
            mockRiotHttpClient.Setup(x => x.GetAsync<RankedResponse>(It.Is<Uri>(inputUri => inputUri == expectedUri)))
                .ReturnsAsync(new RankedResponse { ActId = act, Players = new List<Player> { new Player(), new Player() } })
                .Verifiable();

            using var rankedClient = new RankedClient(mockRiotHttpClient.Object, mockApiUrlResolver.Object);

            var response = await rankedClient.GetLeaderboardByAct(act, startPositionIndex, numberOfPlayersToReturn, region);

            response.Should().NotBeNull();
            response.ActId.Should().Be(act);
            response.Players.Count().Should().Be(numberOfPlayersToReturn);

            mockApiUrlResolver.VerifyAll();
            mockRiotHttpClient.VerifyAll();
        }

        [Fact]
        public async Task Should_Throw_When_ActId_Not_Specified()
        {
            using var rankedClient = new RankedClient(Mock.Of<IRiotHttpClient>(), Mock.Of<IRiotApiUrlResolver>());

            var leaderboardResponseException = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await rankedClient.GetLeaderboardByAct(string.Empty, 0);
            });

            leaderboardResponseException.ParamName.Should().Be("actId");
        }

        [Fact]
        public async Task Should_Throw_When_Start_Position_Exceeds_Players_Returned()
        {
            var startPositionIndex = 1;
            var totalPlayersReturned = 0;

            using var rankedClient = new RankedClient(Mock.Of<IRiotHttpClient>(), Mock.Of<IRiotApiUrlResolver>());

            var leaderboardResponseException = await Assert.ThrowsAsync<StartPositionGreaterThanTotalPlayersReturnedException>(async () =>
            {
                await rankedClient.GetLeaderboardByAct("testing", startPositionIndex, totalPlayersReturned);
            });

            leaderboardResponseException.StartIndex.Should().Be(startPositionIndex);
            leaderboardResponseException.TotalPlayersReturned.Should().Be(totalPlayersReturned);
            leaderboardResponseException.Message.Should().Be($"A starting index of {startPositionIndex} is greater than the total players returned {totalPlayersReturned}.");
        }
    }
}
