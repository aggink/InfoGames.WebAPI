using InfoGames.WebAPI.ViewModels;

namespace InfoGames.WebAPI.Infrastructure.Providers.Interfaces;

public interface IGameProvider
{
    /// <summary>
    /// Получить список всех игр
    /// </summary>
    /// <returns></returns>
    IQueryable<GameViewModel> GetAll();

    /// <summary>
    /// Получить список игр определенного жанра
    /// </summary>
    /// <returns></returns>
    IQueryable<GameViewModel>? GetGamesOfGenreAsync(string genre);
}