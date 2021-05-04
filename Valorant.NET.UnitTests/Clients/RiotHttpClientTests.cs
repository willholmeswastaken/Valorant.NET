using FluentAssertions;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Valorant.NET.Clients;
using Valorant.NET.Handlers;
using Valorant.NET.Models.Account;
using Valorant.NET.Models.Exceptions;
using Valorant.NET.Resolvers;
using Xunit;

namespace Valorant.NET.UnitTests.Clients
{
    public class RiotHttpClientTests
    {
        private readonly Uri UriMock = new Uri("https://riotgames.com");
        private readonly AccountResponse _mockAccountResponse;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private readonly HttpResponseMessage _mockHttpResponseMessage;
        private readonly Mock<IRiotTokenResolver> _mockRiotTokenResolver;

        public RiotHttpClientTests()
        {
            _mockAccountResponse = new AccountResponse()
            {
                Puuid = "test",
                GameName = "SevenZ",
                TagLine = "2070"
            };

            _mockHttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(_mockAccountResponse))
            };

            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _mockHttpMessageHandler
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(_mockHttpResponseMessage)
               .Verifiable();

            _mockRiotTokenResolver = new Mock<IRiotTokenResolver>();
            _mockRiotTokenResolver.Setup(x => x.Resolve())
                .Returns("test")
               .Verifiable();
        }

        [Fact]
        public async Task GetAsync_Should_Return_DeserializedOutput()
        {
            var riotApiResponseHandlerMock = new Mock<IRiotApiResponseHandler>();
            riotApiResponseHandlerMock.Setup(x => x.Execute(It.Is<HttpResponseMessage>(message => message == _mockHttpResponseMessage)))
                .Returns(Task.CompletedTask)
               .Verifiable();

            using var httpClient = new RiotHttpClient(_mockRiotTokenResolver.Object, riotApiResponseHandlerMock.Object, new HttpClient(_mockHttpMessageHandler.Object));

            var response = await httpClient.GetAsync<AccountResponse>(UriMock);

            response.Should().BeEquivalentTo(_mockAccountResponse);

            _mockHttpMessageHandler.VerifyAll();
            _mockRiotTokenResolver.VerifyAll();
            riotApiResponseHandlerMock.VerifyAll();
        }

        [Fact]
        public async Task GetAsync_Should_Throw_On_ResponseHandlerError()
        {
            var apiResponseHandlerException = new Exception("it borked");

            var riotApiResponseHandlerMock = new Mock<IRiotApiResponseHandler>();
            riotApiResponseHandlerMock.Setup(x => x.Execute(It.Is<HttpResponseMessage>(message => message == _mockHttpResponseMessage)))
                .ThrowsAsync(apiResponseHandlerException)
               .Verifiable();

            using var httpClient = new RiotHttpClient(_mockRiotTokenResolver.Object, riotApiResponseHandlerMock.Object, new HttpClient(_mockHttpMessageHandler.Object));

            var responseException = await Assert.ThrowsAsync<RiotApiException>(async () =>
            {
                await httpClient.GetAsync<AccountResponse>(UriMock);
            });

            responseException.InnerException.Should().BeEquivalentTo(apiResponseHandlerException);
            responseException.Data["url"].Should().BeEquivalentTo(UriMock.ToString());

            riotApiResponseHandlerMock.VerifyAll();
            _mockRiotTokenResolver.VerifyAll();
            riotApiResponseHandlerMock.VerifyAll();
        }
    }
}
