using CramMathUltra.Domain.Entities;
using CramMathUltra.Presentation.ASCII;
using CramMathUltra.Presentation.CLI.Rendering;

namespace CramMathUltra.Presentation.CLI.Screens;

public static class ResultScreen
{
    public static void Show(TrainingResult result)
    {
        Console.Clear();

        AsciiHeader.Draw("RESULT SUMMARY");

        string[] content =
        {
            $"Total Questions : {result.TotalQuestions}",
            $"Correct Answers : {result.CorrectAnswers}",
            $"Wrong Answers   : {result.WrongAnswers}",
            $"Accuracy        : {result.Accuracy:F2}%"
        };

        foreach (var line in content)
        {
            AsciiBox.Draw("STAT", line);
        }

        Console.WriteLine();
        ConsoleLayout.WriteCenteredLines(new[]
        {
            "Press any key to continue..."
        });

        Console.ReadKey(true);
    }
}