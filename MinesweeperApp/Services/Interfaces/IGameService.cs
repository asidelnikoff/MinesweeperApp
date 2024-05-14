using MinesweeperApp.Models;
using System.Threading.Tasks;

namespace MinesweeperApp.Services.Interfaces;

public interface IGameService
{
    Task<GameInfoResponse> Create(NewGameRequest request);
    Task<GameInfoResponse> MakeTurn(GameTurnRequest request);
}
