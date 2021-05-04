# Valorant.NET SDK
This is package built to allow .NET developers to interact with the valorant api.

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
### Or if someone would like to open a pull request to do this, I would be eternally grateful
- [ ] Matches/GetByPuuid
- [ ] Matches/GetById
- [ ] Matches/ByQueue
