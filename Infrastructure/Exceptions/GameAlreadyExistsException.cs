using System;

namespace Infrastructure.Exceptions;

public class GameAlreadyExistsException : Exception
{
    public Guid GameId { get; init; }

    public GameAlreadyExistsException(Guid gameId) : base()
    {
        GameId = gameId;
    }

    public GameAlreadyExistsException(Guid gameId, string message) : base(message)
    {
        GameId = gameId;
    }

    public GameAlreadyExistsException(
        Guid gameId,
        string message,
        Exception innerException) : base(message, innerException)
    {
        GameId = gameId;
    }
}
