using CramMathUltra.Application.Models;

namespace CramMathUltra.Application.Abstractions;

public interface IGameEngine
{
    GameState Start();
    GameState ProcessInput(string input);
}