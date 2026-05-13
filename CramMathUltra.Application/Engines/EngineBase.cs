using CramMathUltra.Application.Abstractions;
using CramMathUltra.Application.Models;

namespace CramMathUltra.Application.Engines;

public abstract class EngineBase : IGameEngine
{
    protected readonly Random Random = new();

    protected GameState State = new();

    public abstract GameState Start();

    public abstract GameState ProcessInput(string input);
}