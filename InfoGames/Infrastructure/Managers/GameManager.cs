using InfoGames.WebAPI.Infrastructure.Managers.Interfaces;
using InfoGames.WebAPI.Infrastructure.Providers.Interfaces;
using InfoGames.WebAPI.Infrastructure.Repositories.Base;
using InfoGames.WebAPI.Models;
using InfoGames.WebAPI.ViewModels;

namespace InfoGames.WebAPI.Infrastructure.Managers;

public class GameManager : IGameManager
{
    private readonly IRepository<GameModel> _repository;
    private readonly IGameProvider _provider;

    public GameManager(IRepository<GameModel> repository, IGameProvider provider)
    {
        _repository = repository;
        _provider = provider;
    }

    public async Task<bool> CreateAsync(CreateGameViewModel model)
    {
        var entity = new GameModel()
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            StudioDeveloper = model.StudioDeveloper,
            Genres = string.Join(",", model.Genres.Select(x => x.Trim(' ')))
    };

        var result = await _repository.CreateAsync(entity);
        if (result == null) return false;

        return true;
    }

    public async Task<bool> UpdateAsync(UpdateGameViewModel model)
    {
        var entity = new GameModel()
        {
            Id = model.Id,
            Name = model.Name,
            StudioDeveloper = model.StudioDeveloper,
            Genres = string.Join(",", model.Genres.Select(x => x.Trim(' ')))
        };

        var result = await _repository.UpdateAsync(entity);
        if (result == null) return false;

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var result = await _repository.DeleteAsync(id);
        if (!result) return false;

        return true;
    }

    public async Task<GameViewModel?> GetById(Guid id)
    {
        var result = await _repository.FindByIdAsync(id);
        if (result == null) return null;

        return new GameViewModel()
        {
            Id = result.Id,
            Name = result.Name,
            StudioDeveloper = result.StudioDeveloper,
            Genres = result.Genres.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
        };
    }

    public IQueryable<GameViewModel> GetAll()
    {
        var result = _provider.GetAll();

        return result.Select(x => new GameViewModel()
        {
            Id = x.Id,
            Name = x.Name,
            StudioDeveloper = x.StudioDeveloper,
            Genres = x.Genres.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
        });
    }

    public IQueryable<GameViewModel> GetGamesOfGenre(string genre)
    {
        var result = _provider.GetGamesOfGenre(genre);

        return result.Select(x => new GameViewModel()
        {
            Id = x.Id,
            Name = x.Name,
            StudioDeveloper = x.StudioDeveloper,
            Genres = x.Genres.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
        });
    }
}