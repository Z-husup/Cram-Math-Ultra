namespace CramMathUltra.Presentation.CLI.Rendering;

public static class ConsoleLayout
{
    public static int GetWidth()
        => Console.WindowWidth;

    public static string CenterLine(string text, int width)
    {
        int pad = (width - text.Length) / 2;
        if (pad < 0) pad = 0;

        return new string(' ', pad) + text;
    }
    
    public static void WriteCenteredLines(IEnumerable<string> lines)
    {
        int width = GetWidth();

        foreach (var line in lines)
        {
            Console.WriteLine(CenterLine(line, width));
        }
    }
}