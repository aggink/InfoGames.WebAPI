using InfoGames.WebAPI.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace InfoGames.Data.DbInitializers;

/// <summary>
/// Класс отвечающий за инициализация БД начальными данными
/// </summary>
public static class GamesDbInit
{
    /// <summary>
    /// Инициализация БД
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <returns></returns>
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var scope = serviceProvider.CreateScope();
        await using var gamesDbContext = scope.ServiceProvider.GetService<GamesDbContext>();

        var IsExists = gamesDbContext!.GetService<IDatabaseCreator>() is RelationalDatabaseCreator gamesDbCreator && await gamesDbCreator.ExistsAsync();
        if (!IsExists)
        {
            await gamesDbContext!.Database.MigrateAsync();
            await gamesDbContext!.SaveChangesAsync();
        }
    }
}
