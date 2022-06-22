using Microsoft.AspNetCore.Mvc;

namespace InfoGames.WebAPI.Controllers;

[ApiController]
[Route("games")]
[Produces("application/json")]
public class GameController : Controller
{
    public GameController()
    {

    }
}
