namespace CramMathUltra.Presentation.ASCII;

public static class AsciiHeader
{
    public static void Draw(string text)
    {
        Console.WriteLine();
        Console.WriteLine("====================================");
        Console.WriteLine($"   {text}");
        Console.WriteLine("====================================");
        Console.WriteLine();
    }
}