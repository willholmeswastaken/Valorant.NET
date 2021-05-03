# Valorant.NET SDK
This is package built to allow .NET developers to interact with the valorant api.

# How to use
In Startup.cs add this
```
serviceCollection.AddValorantDotNet();
```
This will configure your DI container (assuming you are using the out the box .net di).
## Todo:
- [x] Account/GetByPuuid
- [x] Account/GetByRiotId
- [x] Account/GetActiveShardByPuuid

- [ ] Content/GetContents

- [x] Ranked/GetLeaderboardByAct

- [ ] Matches/GetByPuuid
- [ ] Matches/GetById
- [ ] Matches/ByQueue
- [ ] Implement more granular riot api exception handling
