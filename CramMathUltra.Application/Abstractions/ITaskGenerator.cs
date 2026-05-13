using CramMathUltra.Domain.Entities;

namespace CramMathUltra.Application.Abstractions;

public interface ITaskGenerator
{
    ArithmeticProblem Generate();
}