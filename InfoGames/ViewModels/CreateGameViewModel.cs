using System.ComponentModel.DataAnnotations;

namespace InfoGames.WebAPI.ViewModels;

/// <summary>
/// Модель создания игры
/// </summary>
public class CreateGameViewModel
{
    /// <summary>
    /// Названия
    /// </summary>
    [Required(ErrorMessage = "Название игры не задано")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Студия разработчик
    /// </summary>
    [Required(ErrorMessage = "Студия разработчик не задана")]
    public string StudioDeveloper { get; set; } = null!;

    /// <summary>
    /// Жанры игр
    /// </summary>
    [Required(ErrorMessage = "Игровые жанры не заданы")]
    public List<string> Genres { get; set; } = null!;
}
