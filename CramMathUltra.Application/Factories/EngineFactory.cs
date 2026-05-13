using CramMathUltra.Application.Abstractions;
using CramMathUltra.Application.Engines;
using CramMathUltra.Domain.Entities;
using CramMathUltra.Domain.Enums;

namespace CramMathUltra.Application.Factories;

public class EngineFactory
{
    public IGameEngine Create()
    {
        return new SessionEngine();
    }
}