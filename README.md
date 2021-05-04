<h1 align="center">*Unofficial* Valorant Dotnet SDK</h1>
<p align="center">This is a package built to allow .NET developers to interact with the valorant api.</p>
![Downloads Badge](https://img.shields.io/nuget/dt/ValorantDotNet)
[![Maintenance](https://img.shields.io/badge/Maintained%3F-yes-green.svg)](https://GitHub.com/Naereen/StrapDown.js/graphs/commit-activity)
# How to use
In Startup.cs add this
```
serviceCollection.AddValorantDotNet();
```
This will configure your DI container (assuming you are using the out the box .net di).

Each endpoint has its own client:
```
IAccountClient
IRankedClient
IContentClient
```
All of which expose the relevant api endpoint methods to retrieve your response.

## Todo:
- [x] Account/GetByPuuid
- [x] Account/GetByRiotId
- [x] Account/GetActiveShardByPuuid
- [x] Content/GetContents
- [x] Ranked/GetLeaderboardByAct
- [ ] Expose a method to get leaderboardbycurrentact


### NOTE: As of present I cannot access these apis, so I will postpone this implementation until I do.
- [ ] Matches/GetByPuuid
- [ ] Matches/GetById
- [ ] Matches/ByQueue

# Disclaimer
This package is not supported or endorsed by Riot Games. Any use of this package is at your own risk. I take no responsibility over the use of this package. By downloading through Nuget, you agree to these conditions.
