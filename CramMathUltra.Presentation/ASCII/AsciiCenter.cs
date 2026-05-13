namespace CramMathUltra.Presentation.ASCII;

public static class AsciiCenter
{
    public static void Print(string ascii)
    {
        if (string.IsNullOrEmpty(ascii))
            return;

        int consoleWidth;

        try
        {
            consoleWidth = Console.WindowWidth;
        }
        catch
        {
            consoleWidth = 80;
        }

        var lines = ascii.Replace("\r", "").Split('\n');

        foreach (var line in lines)
        {
            int padding = (consoleWidth - line.Length) / 2;

            if (padding < 0)
                padding = 0;

            Console.WriteLine(new string(' ', padding) + line);
        }
    }
}