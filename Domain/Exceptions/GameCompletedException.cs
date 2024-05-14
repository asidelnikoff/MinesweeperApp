using System;

namespace Domain.Exceptions;

public class GameCompletedException : Exception
{
    public Guid GameId { get; init; }
    public GameCompletedException(Guid gameId) : base()
    {
        GameId = gameId;
    }
    public GameCompletedException(Guid gameId, string message) : base(message)
    {
        GameId = gameId;
    }
    public GameCompletedException(
        Guid gameId,
        string message,
        Exception innerException) : base(message, innerException)
    {
        GameId = gameId;
    }
}
