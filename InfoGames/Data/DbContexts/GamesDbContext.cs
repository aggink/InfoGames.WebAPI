using InfoGames.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoGames.WebAPI.Data.DbContexts;

/// <summary>
/// Сеанс с БД Games
/// </summary>
public class GamesDbContext : DbContext
{
    public GamesDbContext(DbContextOptions options) 
        : base(options) { }

    public DbSet<GameModel> Games { get; set; } = null!;
}
