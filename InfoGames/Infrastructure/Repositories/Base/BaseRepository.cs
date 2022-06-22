using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace InfoGames.WebAPI.Infrastructure.Repositories.Base;

public abstract class BaseRepository<TDbContext>
    where TDbContext : DbContext
{
    protected readonly TDbContext _dbContext;
    protected readonly ILogger<TDbContext> _logger;

    public BaseRepository(TDbContext dbContext, ILogger<TDbContext> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public Task<IDbContextTransaction> BeginTransactionAsync(bool useIfExists = false)
    {
        var transaction = _dbContext.Database.CurrentTransaction;
        if (transaction == null)
        {
            return _dbContext.Database.BeginTransactionAsync();
        }

        return useIfExists ? Task.FromResult(transaction) : _dbContext.Database.BeginTransactionAsync();
    }
}