using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinesweeperApp.Models;
using MinesweeperApp.Services.Interfaces;
using System.Threading.Tasks;

namespace MinesweeperApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MinesweeperController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly ILogger<MinesweeperController> _logger;

        public MinesweeperController(
            IGameService gameService,
            ILogger<MinesweeperController> logger)
        {
            _gameService = gameService;
            _logger = logger;
        }

        [HttpPost("/new")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GameInfoResponse>> Create(NewGameRequest request)
        {
            return Ok(await _gameService.Create(request));
        }

        [HttpPost("/turn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GameInfoResponse>> MakeTurn(GameTurnRequest request)
        {
            return Ok(await _gameService.MakeTurn(request));
        }
    }
}
