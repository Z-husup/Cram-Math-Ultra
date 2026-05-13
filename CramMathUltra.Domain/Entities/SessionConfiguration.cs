using CramMathUltra.Domain.Enums;

namespace CramMathUltra.Domain.Entities;

public class SessionConfiguration
{
    public TrainingModeType Mode { get; set; }

    public int QuestionCount { get; set; } = 10;

    public int MaxValue { get; set; } = 10;
}