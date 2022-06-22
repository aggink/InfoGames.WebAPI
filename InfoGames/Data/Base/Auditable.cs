namespace InfoGames.WebAPI.Data.Base;

/// <summary>
/// Базовые поля сущности
/// </summary>
public abstract class Auditable : IGuid
{
    public Guid Id { get; set; }
}