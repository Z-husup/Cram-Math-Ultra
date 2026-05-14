using CramMathUltra.Application.Abstractions;
using CramMathUltra.Application.Models;
using CramMathUltra.Domain.Entities;

namespace CramMathUltra.Application.Sessions;

public class SessionController
{
    private readonly IGameEngine _engine;
    private readonly SessionConfiguration _config;
    private GameState _state;

    public SessionController(IGameEngine engine, SessionConfiguration config)
    {
        _engine = engine;
        _config = config;
        _state = _engine.Start();
    }

    public SessionConfiguration GetConfiguration() => _config;

    public GameState Start() => _state;

    public GameState Step(string input)
    {
        _state = _engine.ProcessInput(input);
        return _state;
    }

    public GameState GetState() => _state;
}