using Domain;
using System;

namespace MinesweeperApp.Models;

public record GameInfoResponse
{
    public required Guid Id { get; init; }
    public required int Width { get; init; }
    public required int Height { get; init; }
    public required int MinesCount { get; init; }
    public required bool Completed { get; init; }
    public required FieldCell[][] Field { get; set; }
}
