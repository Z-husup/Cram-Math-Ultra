using CramMathUltra.Application.Abstractions;
using CramMathUltra.Application.Models;

namespace CramMathUltra.Application.Sessions;

public class SessionController
{
    private readonly IGameEngine _engine;

    private GameState _state;

    public SessionController(IGameEngine engine)
    {
        _engine = engine;
    }

    public GameState Start()
    {
        _state = _engine.Start();
        return _state;
    }

    public GameState Step(string input)
    {
        _state = _engine.ProcessInput(input);
        return _state;
    }
}