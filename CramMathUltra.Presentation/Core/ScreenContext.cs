using CramMathUltra.Domain.Entities;

namespace CramMathUltra.Presentation.Core;

public class ScreenContext
{
    public string? CenterText { get; set; }

    public TrainingResult? Result { get; set; }

    public bool IsCorrect { get; set; }

    public bool IsWrong { get; set; }
}