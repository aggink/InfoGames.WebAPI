using InfoGames.WebAPI.ViewModels;

namespace InfoGames.WebAPI.Infrastructure.Managers.Interfaces;

public interface IGameManager
{
    /// <summary>
    /// Создать сущность в БД
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<bool> CreateAsync(CreateGameViewModel model);

    /// <summary>
    /// Обновить сущность в БД
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(UpdateGameViewModel model);

    /// <summary>
    /// Удалить сущность в БД
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id);

    /// <summary>
    /// Получить сущность по id из БД
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<GameViewModel?> GetById(Guid id);

    /// <summary>
    /// Получить список всех игр
    /// </summary>
    /// <returns></returns>
    IQueryable<GameViewModel> GetAll();

    /// <summary>
    /// Получить список игр определенного жанра
    /// </summary>
    /// <param name="genre"></param>
    /// <returns></returns>
    IQueryable<GameViewModel> GetGamesOfGenre(string genre);
}