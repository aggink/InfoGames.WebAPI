using Microsoft.EntityFrameworkCore;

namespace InfoGames.WebAPI.Data.DbContexts;

public class GamesDbContext : DbContext
{
    public GamesDbContext(DbContextOptions options) : base(options)
    {

    }
}
