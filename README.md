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
- [ ] Account/GetByRiotId
- [ ] Account/GetActiveShardByPuuid

- [ ] Content/GetContents

- [ ] Ranked/GetLeaderboardByAct

- [ ] Matches/GetByPuuid
- [ ] Matches/GetById
- [ ] Matches/ByQueue
