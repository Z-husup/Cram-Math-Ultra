using CramMathUltra.Application.Abstractions;
using CramMathUltra.Application.Generators;
using CramMathUltra.Application.Sessions;
using CramMathUltra.CLI.Rendering;
using CramMathUltra.Domain.Entities;
using CramMathUltra.Domain.Enums;
using CramMathUltra.Presentation.Input;

var configuration = new SessionConfiguration
{
    Operation = OperationType.Addition,
    Mode = TrainingModeType.Standard,
    MaxValue = 10,
    QuestionCount = 5
};

ITaskGenerator generator =
    new RandomArithmeticGenerator(
        configuration.MaxValue,
        configuration.Operation);

IInputHandler inputHandler =
    new ConsoleRealtimeInputHandler();

ISessionEngine engine =
    new StandardArithmeticEngine(
        generator,
        configuration,
        inputHandler);

var result = await engine.RunAsync();

ResultRenderer.Render(result);