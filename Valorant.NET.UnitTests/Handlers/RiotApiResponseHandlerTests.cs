using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Valorant.NET.Handlers;
using Valorant.NET.Models.Exceptions;
using Xunit;

namespace Valorant.NET.UnitTests.Handlers
{
    public class RiotApiResponseHandlerTests
    {
        private readonly RiotApiResponseHandler _handler;

        public RiotApiResponseHandlerTests()
        {
            _handler = new RiotApiResponseHandler();   
        }

        [Fact]
        public async Task Should_Handle_When_Success_StatusCode()
        {
            var mockApiResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            var handlerResponse = _handler.Execute(mockApiResponseMessage);
            await handlerResponse;

            handlerResponse.IsCompletedSuccessfully.Should().BeTrue();
        }

        [Fact]
        public async Task Should_Throw_When_Non_Success_StatusCode()
        {
            var mockApiResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent("it failed") };

            var handlerResponseException = await Assert.ThrowsAsync<RiotApiException>(async () =>
            {
                await _handler.Execute(mockApiResponseMessage);
            });

            handlerResponseException.Data["statusCode"].Should().Be(mockApiResponseMessage.StatusCode);
        }
    }
}
