namespace InfoGames.WebAPI.Data.Base;

/// <summary>
/// Первичный ключ
/// </summary>
public interface IGuid
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    Guid Id { get; set; }
}
