using CramMathUltra.Domain.Enums;

namespace CramMathUltra.Domain.Entities;

public class SessionConfiguration
{
    public TrainingModeType Mode { get; set; }
    public DifficultyLevel Difficulty { get; set; }
    public int MaxValue { get; set; }
    public int QuestionCount { get; set; }
}