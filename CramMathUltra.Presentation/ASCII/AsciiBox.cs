namespace CramMathUltra.ASCII;

public static class AsciiBox
{
    public static void Draw(string title, string content)
    {
        int width = Math.Max(title.Length, content.Length) + 6;

        string border = "+" + new string('-', width) + "+";

        Console.WriteLine(border);
        Console.WriteLine($"|  {title.PadRight(width - 2)}|");
        Console.WriteLine(border);
        Console.WriteLine($"|  {content.PadRight(width - 2)}|");
        Console.WriteLine(border);
    }
}