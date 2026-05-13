using CramMathUltra.Application.Abstractions;
using CramMathUltra.Application.Generators;
using CramMathUltra.Application.Sessions;
using CramMathUltra.CLI.Rendering;
using CramMathUltra.Domain.Entities;
using CramMathUltra.Domain.Enums;
using CramMathUltra.Presentation.Input;

public class SessionEngineFactory : ISessionEngineFactory
{
    public ISessionEngine Create(SessionConfiguration configuration)
    {
        ITaskGenerator generator =
            new RandomArithmeticGenerator(
                configuration.MaxValue,
                configuration.Operation);

        IInputHandler inputHandler =
            new ConsoleRealtimeInputHandler();

        ISessionRenderer renderer =
            new ConsoleSessionRenderer();

        return configuration.Mode switch
        {
            TrainingModeType.Standard =>
                new StandardArithmeticEngine(
                    generator,
                    configuration,
                    inputHandler,
                    renderer),

            _ => throw new NotImplementedException(
                $"Mode {configuration.Mode} not implemented.")
        };
    }
}