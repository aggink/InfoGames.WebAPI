using InfoGames.WebAPI.Data.DbContexts;
using InfoGames.WebAPI.Infrastructure.Providers.Interfaces;
using InfoGames.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InfoGames.WebAPI.Infrastructure.Providers;

public class GameProvider : IGameProvider
{
    private readonly GamesDbContext _dbContext;

    public GameProvider(GamesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<GameModel> GetAll()
    {
        IQueryable<GameModel> result = _dbContext.Games
            .AsNoTracking();

        return result;
    }

    public IQueryable<GameModel> GetGamesOfGenre(string genre)
    {
        IQueryable<GameModel> result = _dbContext.Games
            .AsNoTracking()
            .Where(x => x.Genres.Contains(genre));

        return result;
    }
}