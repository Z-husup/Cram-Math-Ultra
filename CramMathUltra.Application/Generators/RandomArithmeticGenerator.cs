using CramMathUltra.Application.Abstractions;
using CramMathUltra.Domain.Entities;
using CramMathUltra.Domain.Enums;

namespace CramMathUltra.Application.Generators;

public class RandomArithmeticGenerator : ITaskGenerator
{
    private readonly Random _random = new();

    private readonly int _maxValue;
    private readonly OperationType _operation;

    public RandomArithmeticGenerator(
        int maxValue,
        OperationType operation)
    {
        _maxValue = maxValue;
        _operation = operation;
    }

    public ArithmeticProblem Generate()
    {
        int left = _random.Next(1, _maxValue + 1);
        int right = _random.Next(1, _maxValue + 1);

        if (_operation == OperationType.Division)
        {
            right = _random.Next(1, _maxValue + 1);

            int result = _random.Next(1, _maxValue + 1);

            left = right * result;
        }

        var expression = new MathExpression(
            left,
            right,
            _operation);

        return new ArithmeticProblem(expression);
    }
}