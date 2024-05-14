namespace MinesweeperApp.Models;

public record NewGameRequest
{
    public required int Width { get; init; }
    public required int Height { get; init; }
    public required int MinesCount { get; init; }
}
