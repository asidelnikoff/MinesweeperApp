using Infrastructure.Interfaces;
using MinesweeperApp.Extensions;
using MinesweeperApp.Models;
using MinesweeperApp.Services.Interfaces;
using System.Threading.Tasks;

namespace MinesweeperApp.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<GameInfoResponse> Create(NewGameRequest request)
    {
        var game = await _gameRepository.Create(
            request.Width,
            request.Height,
            request.MinesCount);

        return game.ToModel();
    }

    public async Task<GameInfoResponse> MakeTurn(GameTurnRequest request)
    {
        var game = await _gameRepository.Get(request.GameId);
        game.MakeTurn(request.Row, request.Col);

        return game.ToModel();
    }
}
