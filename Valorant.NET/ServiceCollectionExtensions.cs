﻿using Microsoft.Extensions.DependencyInjection;
using Valorant.NET.Account;
using Valorant.NET.Handlers;
using Valorant.NET.Resolvers;

namespace Valorant.NET
{
    public static class ServiceCollectionExtensions
    {
        public static void AddValorantDotNet(this IServiceCollection services)
        {
            services.AddSingleton<IRiotTokenResolver, RiotTokenResolver>();
            services.AddScoped<IRiotApiResponseHandler, RiotApiResponseHandler>();
            services.AddScoped<IAccountClient, AccountClient>();
        }
    }
}