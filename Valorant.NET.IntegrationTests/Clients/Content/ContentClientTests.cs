using FluentAssertions;
using System.Threading.Tasks;
using Valorant.NET.Clients;
using Valorant.NET.Clients.Content;
using Valorant.NET.Handlers;
using Valorant.NET.Resolvers;
using Xunit;

namespace Valorant.NET.IntegrationTests.Clients.Content
{
    public class ContentClientTests
    {
        [Fact]
        public async Task GetContentOptionallyFilteredByLocale_Should_return_valid_response()
        {
            using var contentClient = new ContentClient(new RiotHttpClient(new RiotTokenResolver(), new RiotApiResponseHandler()), new RiotApiUrlResolver());

            var response = await contentClient.GetContentOptionallyFilteredByLocale();

            response.Should().NotBeNull();
        }
    }
}
