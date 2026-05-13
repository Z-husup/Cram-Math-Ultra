using CramMathUltra.Presentation.CLI.Rendering;

namespace CramMathUltra.Presentation.ASCII;

public static class AsciiBox
{
    public static void Draw(string title, string content)
    {
        int width = ConsoleLayout.GetWidth();

        string border = "+" + new string('-', Math.Min(width - 2, 40)) + "+";

        Console.WriteLine(ConsoleLayout.CenterLine(border, width));
        Console.WriteLine(ConsoleLayout.CenterLine($"| {title} |", width));
        Console.WriteLine(ConsoleLayout.CenterLine(border, width));
        Console.WriteLine(ConsoleLayout.CenterLine($"| {content} |", width));
        Console.WriteLine(ConsoleLayout.CenterLine(border, width));
    }
}