using System;

namespace MinesweeperApp.Models;

public record GameTurnRequest
{
    public Guid GameId { get; init; }
    public int Col { get; init; }
    public int Row { get; init; }
}
