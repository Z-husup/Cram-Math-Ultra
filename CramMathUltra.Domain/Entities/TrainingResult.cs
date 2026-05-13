namespace CramMathUltra.Domain.Entities;

public class TrainingResult
{
    public int TotalQuestions { get; set; }

    public int CorrectAnswers { get; set; }

    public int WrongAnswers =>
        TotalQuestions - CorrectAnswers;

    public double Accuracy =>
        TotalQuestions == 0
            ? 0
            : (double)CorrectAnswers / TotalQuestions * 100;
}