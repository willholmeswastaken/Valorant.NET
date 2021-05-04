using FluentAssertions;
using System;
using Valorant.NET.Models.Exceptions;
using Valorant.NET.Resolvers;
using Xunit;

namespace Valorant.NET.UnitTests.Resolvers
{
    public class RiotTokenResolverTests
    {
        private readonly RiotTokenResolver _resolver;

        public RiotTokenResolverTests()
        {
            _resolver = new RiotTokenResolver();
        }

        [Fact]
        public void Should_Resolve_When_Token_Found()
        {
            var riotApiToken = "riot";

            Environment.SetEnvironmentVariable(Constants.RIOT_API_TOKEN, riotApiToken);
            var resolvedToken = _resolver.Resolve();

            resolvedToken.Should().Be(riotApiToken);
        }

        [Fact]
        public void Should_Throw_When_Token_Not_Found()
        {
            var resolverResponseException = Assert.Throws<MissingRiotApiTokenException>(() =>
            {
                _resolver.Resolve();
            });

            resolverResponseException.Message.Should().Be("Failed to find the environment variable riot-api-token containing the riot api token.");
        }
    }
}
