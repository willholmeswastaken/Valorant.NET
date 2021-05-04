using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valorant.NET.Clients;
using Valorant.NET.Clients.Ranked;
using Valorant.NET.Handlers;
using Valorant.NET.Resolvers;
using Xunit;

namespace Valorant.NET.IntegrationTests.Clients.Ranked
{
    public class RankedClientTests : IClassFixture<RiotApiTestFixture>
    {
        private readonly RiotApiTestFixture _fixture;

        public RankedClientTests(RiotApiTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact] 
        public async Task GetLeaderboardByAct_Should_return_valid_response()
        {
            var expectedAmountOfPlayersReturned = 2;
            using var rankedClient = new RankedClient(new RiotHttpClient(new RiotTokenResolver(), new RiotApiResponseHandler()), new RiotApiUrlResolver());

            var response = await rankedClient.GetLeaderboardByAct(_fixture.Config.CurrentActId, 0, 2);

            response.Should().NotBeNull();
            response.ActId.Should().Be(_fixture.Config.CurrentActId);
            response.Players.Count().Should().Be(expectedAmountOfPlayersReturned);
        }
    }
}
