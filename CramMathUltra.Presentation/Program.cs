using CramMathUltra.Application.Abstractions;
using CramMathUltra.Application.Generators;
using CramMathUltra.Application.Sessions;
using CramMathUltra.Domain.Enums;

ITaskGenerator generator =
    new RandomArithmeticGenerator(
        maxValue: 10,
        operation: OperationType.Addition);

ISessionEngine engine =
    new StandardArithmeticEngine(generator);

await engine.RunAsync();;