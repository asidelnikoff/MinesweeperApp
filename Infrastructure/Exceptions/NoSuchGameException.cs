using System;

namespace Infrastructure.Exceptions;

public class NoSuchGameException : Exception
{
    public Guid GameId { get; init; }

    public NoSuchGameException(Guid gameId) : base()
    {
        GameId = gameId;
    }

    public NoSuchGameException(Guid gameId, string message) : base(message)
    {
        GameId = gameId;
    }

    public NoSuchGameException(
        Guid gameId,
        string message,
        Exception innerException) : base(message, innerException)
    {
        GameId = gameId;
    }
}
