namespace MinesweeperApp.Models;

public record ErrorResponse
{
    public required string Error { get; init; }
}
