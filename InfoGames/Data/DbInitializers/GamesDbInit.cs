using InfoGames.WebAPI.Data.DbContexts;
using InfoGames.WebAPI.Infrastructure.Repositories;
using InfoGames.WebAPI.Infrastructure.Repositories.Base;
using InfoGames.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace InfoGames.Data.DbInitializers;

/// <summary>
/// Класс отвечающий за инициализацию БД начальными данными
/// </summary>
public static class GamesDbInit
{
    /// <summary>
    /// Инициализация БД
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <returns></returns>
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        var scope = serviceProvider.CreateScope();
        await using var gamesDbContext = scope.ServiceProvider.GetService<GamesDbContext>();

        var IsExists = gamesDbContext!.GetService<IDatabaseCreator>() is RelationalDatabaseCreator gamesDbCreator && await gamesDbCreator.ExistsAsync();
        if (!IsExists)
            await gamesDbContext!.Database.MigrateAsync();
        else 
            return;

        var gameRepository = scope.ServiceProvider.GetService<IRepository<GameModel>>();
        if (gameRepository == null)
            throw new Exception("GameRepository is not registered");

        List<GameModel> models = new List<GameModel>()
        {
            new GameModel()
            {
                Id = Guid.NewGuid(),
                Name = "Subway Surfers",
                StudioDeveloper = "SYBO Games",
                Genres = "Платформер,Endless Running"
            },
            new GameModel()
            {
                Id = Guid.NewGuid(),
                Name = "Temple Run",
                StudioDeveloper = "Imangi Studios",
                Genres = "Платформер"
            },
            new GameModel()
            {
                Id = Guid.NewGuid(),
                Name = "Geometry Dash",
                StudioDeveloper = "RobTop Games",
                Genres = "Инди-игра,Action"
            },
            new GameModel()
            {
                Id = Guid.NewGuid(),
                Name = "Tomb Raider",
                StudioDeveloper = "Crystal Dynamics",
                Genres = "Action-adventure,Action,RPG,Survival horror,Adventure"
            },
            new GameModel()
            {
                Id = Guid.NewGuid(),
                Name = "Genshin Impact",
                StudioDeveloper = "COGNOSPHERE PTE. LTD.",
                Genres = "Action,RPG,Квест"
            },
            new GameModel()
            {
                Id = Guid.NewGuid(),
                Name = "Dark Souls",
                StudioDeveloper = "From Software",
                Genres = "Подземелье"
            }
        };

        for(int i = 0; i < models.Count; i++)
        {
            await gameRepository.CreateAsync(models[i]);
        }

        await gamesDbContext.SaveChangesAsync();
    }
}