using CramMathUltra.Application.Abstractions;
using CramMathUltra.Presentation.ASCII;

namespace CramMathUltra.Presentation.CLI.Rendering;

public class ConsoleSessionRenderer : ISessionRenderer
{
    public void ShowQuestion(string expression, int index, int total)
    {
        Console.Clear();
        AsciiHeader.Draw($"QUESTION {index}/{total}");
        AsciiBox.Draw("TASK", expression);
    }

    public void ShowInputPrompt(string text)
    {
        Console.WriteLine();
        Console.WriteLine(ConsoleLayout.CenterLine(text, ConsoleLayout.GetWidth()));
    }

    public void ShowCorrect()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(ConsoleLayout.CenterLine("CORRECT", ConsoleLayout.GetWidth()));
        Console.ResetColor();
    }

    public void ShowWrong(string info)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ConsoleLayout.CenterLine($"WRONG ({info})", ConsoleLayout.GetWidth()));
        Console.ResetColor();
    }
}