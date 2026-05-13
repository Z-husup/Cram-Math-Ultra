using CramMathUltra.Domain.Entities;

namespace CramMathUltra.CLI.Rendering;

public static class ResultRenderer
{
    public static void Render(TrainingResult result)
    {
        Console.Clear();

        Console.WriteLine("Session Finished");
        Console.WriteLine();

        Console.WriteLine($"Questions : {result.TotalQuestions}");
        Console.WriteLine($"Correct   : {result.CorrectAnswers}");
        Console.WriteLine($"Wrong     : {result.WrongAnswers}");
        Console.WriteLine($"Accuracy  : {result.Accuracy:F2}%");

        Console.WriteLine();
        Console.WriteLine("Press any key...");

        Console.ReadKey();
    }
}