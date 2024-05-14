using Domain;
using MinesweeperApp.Models;
using System.Linq;

namespace MinesweeperApp.Extensions;

public static class GameExtensions
{
    public static GameInfoResponse ToModel(this Game game)
    {
        return new GameInfoResponse()
        {
            Id = game.Id,
            Width = game.Width,
            Height = game.Height,
            MinesCount = game.MinesCount,
            Completed = game.IsCompleted,
            Field = game.Field
        };
    }
}
