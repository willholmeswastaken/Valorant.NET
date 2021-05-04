using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Valorant.NET.Clients;
using Valorant.NET.Clients.Account;
using Valorant.NET.Clients.Content;
using Valorant.NET.Clients.Ranked;
using Valorant.NET.Handlers;
using Valorant.NET.Resolvers;

namespace Valorant.NET
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static void AddValorantDotNet(this IServiceCollection services)
        {
            services.AddScoped<IRiotHttpClient, RiotHttpClient>();
            services.AddSingleton<IRiotTokenResolver, RiotTokenResolver>();
            services.AddSingleton<IRiotApiUrlResolver, RiotApiUrlResolver>();
            services.AddSingleton<IRiotApiResponseHandler, RiotApiResponseHandler>();

            services.AddScoped<IAccountClient, AccountClient>();
            services.AddScoped<IRankedClient, RankedClient>();
            services.AddScoped<IContentClient, ContentClient>();
        }
    }
}