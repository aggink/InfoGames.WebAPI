using InfoGames.WebAPI.Data.DbContexts;
using InfoGames.WebAPI.Infrastructure.Repositories.Base;
using InfoGames.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoGames.WebAPI.Infrastructure.Repositories;

public class GameRepository : BaseRepository<GamesDbContext>, IRepository<GameModel>
{
    public GameRepository(GamesDbContext dbContext, ILogger<GamesDbContext> logger) 
        :base(dbContext, logger) { }

    public async Task<GameModel?> CreateAsync(GameModel model)
    {
        await using var transaction = await BeginTransactionAsync();

        try
        {
            model.Id = Guid.NewGuid();
            await _dbContext.Games.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            return model;
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while adding the \"{nameof(GameModel)}\" entity to the database.");
            await transaction.RollbackAsync();
            await transaction.CommitAsync();
            return null;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        await using var transaction = await BeginTransactionAsync();

        try
        {
            var entity = await _dbContext.Games.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                _logger.LogError($"The entity \"{nameof(GameModel)}\" with identifier \"{id}\" was not found in the database.");
                return false;
            }

            _dbContext.Games.Remove(entity);
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while deleting the entity \"{nameof(GameModel)}\" with the identifier \"{id}\" in the database.");
            await transaction.RollbackAsync();
            await transaction.CommitAsync();
            return false;
        }
    }

    public async Task<GameModel?> FindByIdAsync(Guid id)
    {
        var entity = await _dbContext.Games.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
        {
            _logger.LogError($"The entity \"{nameof(GameModel)}\" with identifier \"{id}\" was not found in the database.");
            return null;
        }

        return entity;
    }

    public async Task<GameModel?> UpdateAsync(GameModel model)
    {
        await using var transaction = await BeginTransactionAsync();

        try
        {
            var entity = await _dbContext.Games.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (entity == null)
            {
                _logger.LogError($"The entity \"{nameof(GameModel)}\" with identifier \"{model.Id}\" was not found in the database.");
                return null;
            }

            entity.Name = model.Name;
            entity.StudioDeveloper = model.StudioDeveloper;
            entity.Genres = model.Genres;

            _dbContext.Games.Update(entity);
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            return entity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while updating the \"{nameof(GameModel)}\" entity with the identifier \"{model.Id}\" in the database.");
            await transaction.RollbackAsync();
            await transaction.CommitAsync();
            return null;
        }
    }
}