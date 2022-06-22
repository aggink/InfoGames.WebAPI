using InfoGames.WebAPI.Data.Base;

namespace InfoGames.WebAPI.Models
{
    /// <summary>
    /// Модель игры
    /// </summary>
    public class GameModel : Auditable
    {
        /// <summary>
        /// Названия
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Студия разработчик
        /// </summary>
        public string StudioDeveloper { get; set; } = null!;

        /// <summary>
        /// Жанры игр
        /// </summary>
        public string Genres { get; set; } = null!;
    }
}