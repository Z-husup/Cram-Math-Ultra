using CramMathUltra.Presentation.ASCII;
using CramMathUltra.Presentation.CLI.Rendering;

namespace CramMathUltra.Presentation.CLI.Screens;

public static class IntroScreen
{
    public static void Show()
    {
        Console.Clear();

        PlayAnimation();

        Console.Clear();

        AsciiHeader.Draw("CRAM MATH ULTRA");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }

    private static void PlayAnimation()
    {
        string[] frames =
        {
            @"ASCII"               
        };

        foreach (var frame in frames)
        {
            Console.Clear();
            
            Console.Write(ConsoleLayout.CenterLine(frame, ConsoleLayout.GetWidth()));
            
            Thread.Sleep(2500);
        }

        Thread.Sleep(500);
    }
}