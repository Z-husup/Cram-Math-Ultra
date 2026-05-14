using CramMathUltra.Domain.Enums;

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

    public TrainingModeType Mode { get; set; }

    // TABLE FILL
    public int Row { get; set; }
    public int Col { get; set; }

    public int TableSize { get; set; } = 10;

    public int[,] TableProgress { get; set; } = new int[10, 10];

    public bool[,] TableSolved { get; set; } = new bool[10, 10];
}