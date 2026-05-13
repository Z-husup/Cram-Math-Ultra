using CramMathUltra.Application.Abstractions;
using CramMathUltra.Application.Models;

namespace CramMathUltra.Application.Sessions;

public class SessionOrchestrator
{
    private readonly IGameEngine _engine;

    public SessionOrchestrator(IGameEngine engine)
    {
        _engine = engine;
    }

    public (GameState state, bool exit) Start()
    {
        var state = _engine.Start();
        return (state, false);
    }

    public (GameState state, bool exit) Step(string input)
    {
        var state = _engine.ProcessInput(input);

        if (state.IsFinished)
            return (state, true);

        return (state, false);
    }
}