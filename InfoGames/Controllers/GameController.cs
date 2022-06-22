using InfoGames.WebAPI.Infrastructure.Managers.Interfaces;
using InfoGames.WebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InfoGames.WebAPI.Controllers;

[ApiController]
[Route("api/games")]
[Produces("application/json")]
public class GameController : Controller
{
    private readonly IGameManager _manager;
    private readonly ILogger<GameController> _logger;

    public GameController(IGameManager manager, ILogger<GameController> logger)
    {
        _manager = manager;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<JsonResult> GetById(Guid id)
    {
        if (!ModelState.IsValid || id == Guid.Empty)
            return new JsonResult(null)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

        var result = await _manager.GetById(id);
        if (result == null)
            return new JsonResult(null)
            {
                StatusCode = StatusCodes.Status404NotFound
            };

        return Json(result);
    }

    [HttpPost]
    public async Task<JsonResult> Create(CreateGameViewModel model)
    {
        if (!ModelState.IsValid)
            return new JsonResult(null)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

        var result = await _manager.CreateAsync(model);
        if (!result)
            return new JsonResult(null)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

        return new JsonResult(null)
        {
            StatusCode = StatusCodes.Status200OK
        };
    }

    [HttpPut]
    public async Task<JsonResult> Update(UpdateGameViewModel model)
    {
        if (!ModelState.IsValid || model.Id == Guid.Empty)
            return new JsonResult(null)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

        var result = await _manager.UpdateAsync(model);
        if (!result)
            return new JsonResult(null)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

        return new JsonResult(null)
        {
            StatusCode = StatusCodes.Status200OK
        };
    }

    [HttpDelete("{id}")]
    public async Task<JsonResult> Delete(Guid id)
    {
        if (!ModelState.IsValid || id == Guid.Empty)
            return new JsonResult(null)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

        var result = await _manager.DeleteAsync(id);
        if (!result)
            return new JsonResult(null)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

        return new JsonResult(null)
        {
            StatusCode = StatusCodes.Status200OK
        };
    }

    [HttpGet]
    public JsonResult GetAll()
    {
        var result = _manager.GetAll();
        if(result == null || result.Count() == 0)
            return new JsonResult(null)
            {
                StatusCode = StatusCodes.Status404NotFound
            };

        return Json(result);
    }

    [HttpGet]
    [Route("GetGamesOfGenre/{genre}")]
    public JsonResult Get(string genre)
    {
        if (string.IsNullOrEmpty(genre))
            return new JsonResult(null)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

        var result = _manager.GetGamesOfGenre(genre);
        if (result == null || result.Count() == 0)
            return new JsonResult(null)
            {
                StatusCode = StatusCodes.Status404NotFound
            };

        return Json(result);
    }
}