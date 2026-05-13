using CramMathUltra.Presentation.CLI.Rendering;

namespace CramMathUltra.Presentation.ASCII;

public static class AsciiHeader
{
    public static void Draw(string text)
    {
        Console.WriteLine();
        ConsoleLayout.WriteCenteredLines(new[]
        {
            "====================================",
            $"   {text}",
            "===================================="
        });
        Console.WriteLine();
    }
}