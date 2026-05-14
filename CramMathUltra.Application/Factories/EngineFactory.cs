using CramMathUltra.Application.Abstractions;
using CramMathUltra.Application.Engines;
using CramMathUltra.Domain.Entities;
using CramMathUltra.Domain.Enums;

namespace CramMathUltra.Application.Factories;

public class EngineFactory
{
    public IGameEngine Create(SessionConfiguration config)
    {
        return config.Mode switch
        {
            TrainingModeType.Standard => new SessionEngine(),
            TrainingModeType.TableFill => new TableFillEngine(),
            _ => new SessionEngine()
        };
    }
}