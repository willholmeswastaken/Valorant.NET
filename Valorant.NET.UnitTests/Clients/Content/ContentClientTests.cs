using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Valorant.NET.Clients;
using Valorant.NET.Clients.Content;
using Valorant.NET.Models;
using Valorant.NET.Models.Content;
using Valorant.NET.Resolvers;
using Xunit;

namespace Valorant.NET.UnitTests.Clients.Content
{
    public class ContentClientTests 
    {
        [Fact]
        public async Task Should_Return_Content()
        {
            var region = ValorantEndpointRegion.EU;
            var endpoint = "/content/v1/contents?locale=en-GB";
            var expectedUri = new Uri("https://eu.api.riotgames.com/val");
            var expectContentVersion = "unitTest";

            var mockApiUrlResolver = new Mock<IRiotApiUrlResolver>();
            mockApiUrlResolver.Setup(x => x.Resolve(It.Is<ValorantEndpointRegion>(inputRegion => inputRegion == region), It.Is<string>(inputEndpoint => inputEndpoint == endpoint)))
                .Returns(expectedUri)
                .Verifiable();

            var mockRiotHttpClient = new Mock<IRiotHttpClient>();
            mockRiotHttpClient.Setup(x => x.GetAsync<ContentResponse>(It.Is<Uri>(inputUri => inputUri == expectedUri)))
                .ReturnsAsync(new ContentResponse { Version = expectContentVersion })
                .Verifiable();

            using var contentClient = new ContentClient(mockRiotHttpClient.Object, mockApiUrlResolver.Object);

            var response = await contentClient.GetContentOptionallyFilteredByLocale();

            response.Should().NotBeNull();
            response.Version.Should().Be(expectContentVersion);

            mockApiUrlResolver.VerifyAll();
            mockRiotHttpClient.VerifyAll();
        }
    }
}
