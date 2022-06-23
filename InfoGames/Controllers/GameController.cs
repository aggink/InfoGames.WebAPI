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

    public GameController(IGameManager manager)
    {
        _manager = manager;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _manager.GetById(id);
        if (result == null) return NotFound();

        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateGameViewModel model)
    {
        var result = await _manager.CreateAsync(model);
        if (!result) return BadRequest();

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateGameViewModel model)
    {
        var result = await _manager.UpdateAsync(model);
        if (!result) return BadRequest();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _manager.DeleteAsync(id);
        if (!result) return BadRequest();

        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _manager.GetAll();
        if (result == null || result.Count() == 0) return NotFound();

        return Json(result);
    }

    [HttpGet]
    [Route("GetGamesOfGenre/{genre}")]
    public IActionResult Get(string genre)
    {
        var result = _manager.GetGamesOfGenre(genre);
        if (result == null || result.Count() == 0) return NotFound();

        return Json(result);
    }
}