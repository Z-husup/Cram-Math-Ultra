namespace CramMathUltra.Application.Models;

public class GameState
{
    public string CurrentQuestion { get; set; } = "";

    public int ExpectedAnswerLength { get; set; }

    public int Correct { get; set; }

    public int Wrong { get; set; }

    public bool IsCorrect { get; set; }

    public bool IsWrong { get; set; }

    public bool IsFinished { get; set; }
}