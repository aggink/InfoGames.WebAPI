namespace InfoGames.WebAPI.Infrastructure.Repositories.Base;

/// <summary>
/// CRUD
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository<TEntity>
{
    /// <summary>
    /// Получить сущность из БД
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TEntity?> FindByIdAsync(Guid id);

    /// <summary>
    /// Создать сущность в БД
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<TEntity?> CreateAsync(TEntity model);

    /// <summary>
    /// Обновить сущность в БД
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<TEntity?> UpdateAsync(TEntity model);

    /// <summary>
    /// Удалить сущность в БД
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TEntity?> DeleteAsync(Guid id);
}
