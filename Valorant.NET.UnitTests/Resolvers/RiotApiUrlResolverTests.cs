using FluentAssertions;
using Valorant.NET.Models;
using Valorant.NET.Resolvers;
using Xunit;

namespace Valorant.NET.UnitTests.Resolvers
{
    public class RiotApiUrlResolverTests
    {
        private readonly RiotApiUrlResolver _resolver;

        public RiotApiUrlResolverTests()
        {
            _resolver = new RiotApiUrlResolver();
        }

        [Fact]
        public void Should_Resolve_ForValorantEndpoint()
        {
            var region = ValorantEndpointRegion.EU;
            var endpoint = "/testpoint";

            var url = _resolver.Resolve(region, endpoint);

            url.ToString().Should().Be("https://eu.api.riotgames.com/val/testpoint");
        }

        [Fact]
        public void Should_Resolve_ForNonValorantEndpoint()
        {
            var region = NonValorantEndpointRegion.Europe;
            var endpoint = "/testpoint";

            var url = _resolver.Resolve(region, endpoint);

            url.ToString().Should().Be("https://europe.api.riotgames.com/riot/testpoint");
        }
    }
}
