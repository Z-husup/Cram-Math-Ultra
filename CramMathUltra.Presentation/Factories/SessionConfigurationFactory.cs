using CramMathUltra.Domain.Entities;
using CramMathUltra.Domain.Enums;

namespace CramMathUltra.Presentation.Factories;

public static class SessionConfigurationFactory
{
    public static SessionConfiguration Create(
        int operationChoice,
        int modeChoice,
        int maxValue)
    {
        return new SessionConfiguration
        {
            Operation = operationChoice switch
            {
                1 => OperationType.Addition,
                2 => OperationType.Subtraction,
                3 => OperationType.Multiplication,
                4 => OperationType.Division,
                _ => OperationType.Addition
            },

            Mode = modeChoice switch
            {
                1 => TrainingModeType.Standard,
                2 => TrainingModeType.Flash,
                3 => TrainingModeType.WhichOperation,
                4 => TrainingModeType.ChainMemory,
                _ => TrainingModeType.Standard
            },

            MaxValue = maxValue,
            QuestionCount = 10
        };
    }
}