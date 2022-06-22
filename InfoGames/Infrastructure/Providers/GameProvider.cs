using InfoGames.WebAPI.Data.DbContexts;
using InfoGames.WebAPI.Infrastructure.Providers.Interfaces;
using InfoGames.WebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace InfoGames.WebAPI.Infrastructure.Providers;

public class GameProvider : IGameProvider
{
    private readonly GamesDbContext _dbContext;
    private readonly ILogger<GameProvider> _logger;

    public GameProvider(GamesDbContext dbContext, ILogger<GameProvider> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public IQueryable<GameViewModel> GetAll()
    {
        IQueryable<GameViewModel> result = _dbContext.Games
            .AsNoTracking()
            .Select(x => new GameViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                StudioDeveloper = x.StudioDeveloper,
                Genres = x.Genres.Split(',', StringSplitOptions.None).ToList()
            });

        return result;
    }

    public IQueryable<GameViewModel>? GetGamesOfGenreAsync(string genre)
    {
        IQueryable<GameViewModel> result = _dbContext.Games
            .AsNoTracking()
            .Where(x => x.Genres.Contains(genre, StringComparison.OrdinalIgnoreCase))
            .Select(x => new GameViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                StudioDeveloper = x.StudioDeveloper,
                Genres = x.Genres.Split(',', StringSplitOptions.None).ToList()
            });

        return result;
    }
}