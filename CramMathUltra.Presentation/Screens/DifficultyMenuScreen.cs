using CramMathUltra.Domain.Enums;
using CramMathUltra.Presentation.Core;

namespace CramMathUltra.Presentation.Screens;

public class DifficultyMenuScreen
{
    private readonly Layout3Column _layout = new();

    public DifficultyLevel Show()
    {
        while (true)
        {
            Console.Clear();

            var center =
                @"
SELECT DIFFICULTY

1. Easy   (up to 10)
2. Medium (up to 100)
3. Hard   (up to 1000)

ESC - back
";

            _layout.Render(
                AsciiImage.Load("Assets/ASCII/ascii_neutral_left.txt"),
                center,
                AsciiImage.Load("Assets/ASCII/ascii_neutral_right.txt")
            );

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.D1) return DifficultyLevel.Easy;
            if (key.Key == ConsoleKey.D2) return DifficultyLevel.Medium;
            if (key.Key == ConsoleKey.D3) return DifficultyLevel.Hard;
            if (key.Key == ConsoleKey.Escape) throw new OperationCanceledException();
        }
    }
}