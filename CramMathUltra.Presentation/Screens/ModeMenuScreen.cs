using CramMathUltra.Domain.Enums;
using CramMathUltra.Presentation.Core;

namespace CramMathUltra.Presentation.Screens;

public class ModeMenuScreen
{
    private readonly Layout3Column _layout = new();

    public TrainingModeType Show()
    {
        while (true)
        {
            Console.Clear();

            var center =
                @"
SELECT MODE

1. Standard Arithmetic
2. Table Fill
3. Typing Practice

ESC - back
";

            _layout.Render(
                AsciiImage.Load("Assets/ASCII/ascii_neutral_left.txt"),
                center,
                AsciiImage.Load("Assets/ASCII/ascii_neutral_right.txt")
            );

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.D1) return TrainingModeType.Standard;
            if (key.Key == ConsoleKey.D2) return TrainingModeType.TableFill;
            if (key.Key == ConsoleKey.D3) return TrainingModeType.TypingPractice;
            if (key.Key == ConsoleKey.Escape) throw new OperationCanceledException();
        }
    }
}