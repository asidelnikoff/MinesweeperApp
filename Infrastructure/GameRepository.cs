using Domain;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Infrastructure;

public class GameRepository : IGameRepository
{
    private ConcurrentDictionary<Guid, Game> _games;

    public GameRepository()
    {
        _games = new ConcurrentDictionary<Guid, Game>();
    }

    public async Task<Game> Create(int width, int height, int minesCount)
    {
        var game = new Game(width, height, minesCount);
        if (_games.TryAdd(game.Id, game))
        {
            return game;
        }
        else
        {
            throw new GameAlreadyExistsException(game.Id);
        }
    }

    public async Task<Game> Get(Guid id)
    {
        if (_games.ContainsKey(id))
        {
            return _games[id];
        }

        throw new NoSuchGameException(id);
    }
}
