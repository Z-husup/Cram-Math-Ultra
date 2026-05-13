namespace CramMathUltra.Presentation.Core;

public static class ConsoleSetup
{
    public const int Width = 120;
    public const int Height = 30;

    public static void Init()
    {
        Console.CursorVisible = false;

        try
        {
            Console.SetBufferSize(Width, Height);
            Console.SetWindowSize(Width, Height);
        }
        catch { }
    }

    public static bool IsValid()
    {
        return Console.WindowWidth >= Width &&
               Console.WindowHeight >= Height;
    }
}