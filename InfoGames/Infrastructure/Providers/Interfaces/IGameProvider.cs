using InfoGames.WebAPI.Models;

namespace InfoGames.WebAPI.Infrastructure.Providers.Interfaces;

public interface IGameProvider
{
    /// <summary>
    /// Получить список всех игр
    /// </summary>
    /// <returns></returns>
    IQueryable<GameModel> GetAll();

    /// <summary>
    /// Получить список игр определенного жанра
    /// </summary>
    /// <returns></returns>
    IQueryable<GameModel> GetGamesOfGenre(string genre);
}