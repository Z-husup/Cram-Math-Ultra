using CramMathUltra.Domain.Entities;

namespace CramMathUltra.Application.Abstractions;

public interface ISessionEngine
{
    Task<TrainingResult> RunAsync();
}