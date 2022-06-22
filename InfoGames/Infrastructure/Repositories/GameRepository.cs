using InfoGames.WebAPI.Infrastructure.Repositories.Base;
using InfoGames.WebAPI.Models;

namespace InfoGames.WebAPI.Infrastructure.Repositories;

public class GameRepository : IRepository<GameModel>
{
    public Task<GameModel?> CreateAsync(GameModel model)
    {
        throw new NotImplementedException();
    }

    public Task<GameModel?> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<GameModel?> FindByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<GameModel?> UpdateAsync(GameModel model)
    {
        throw new NotImplementedException();
    }
}
