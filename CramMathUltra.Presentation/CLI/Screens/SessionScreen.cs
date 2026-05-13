using CramMathUltra.Presentation.ASCII;

namespace CramMathUltra.Presentation.CLI.Screens;

public static class SessionScreen
{
    public static void DrawQuestion(
        string expression,
        int index,
        int total)
    {
        Console.Clear();

        AsciiHeader.Draw($"QUESTION {index}/{total}");

        AsciiBox.Draw("Solve", expression);
    }

    public static void ShowCorrect()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✓ Correct");
        Console.ResetColor();
    }

    public static void ShowWrong(int correct)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"✗ Wrong (Answer: {correct})");
        Console.ResetColor();
    }
}