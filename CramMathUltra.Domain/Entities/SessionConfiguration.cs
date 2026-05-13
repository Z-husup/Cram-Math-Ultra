using CramMathUltra.Domain.Enums;

namespace CramMathUltra.Domain.Entities;

public class SessionConfiguration
{
    public OperationType Operation { get; set; }

    public TrainingModeType Mode { get; set; }

    public int MaxValue { get; set; }

    public int QuestionCount { get; set; } = 10;

    public int FlashDurationMilliseconds { get; set; } = 2000;
}