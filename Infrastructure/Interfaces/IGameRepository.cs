using Domain;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces;

public interface IGameRepository
{
    Task<Game> Create(int width, int height, int minesCount);
    Task<Game> Get(Guid id);
}
