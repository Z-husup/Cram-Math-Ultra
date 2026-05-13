using CramMathUltra.Domain.Entities;

namespace CramMathUltra.Application.Abstractions;

public interface ISessionEngineFactory
{
    ISessionEngine Create(
        SessionConfiguration configuration);
}