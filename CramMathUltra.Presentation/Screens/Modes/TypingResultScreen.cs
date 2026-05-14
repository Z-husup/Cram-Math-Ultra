using CramMathUltra.Application.Models;
using CramMathUltra.Presentation.Core;

namespace CramMathUltra.Presentation.Screens.Modes;

public class TypingResultScreen
{
    private readonly Layout3Column _layout = new();

    public void Show(GameState state)
    {
        Console.Clear();

        var accuracy =
            state.Keystrokes == 0
                ? 0
                : (100.0 * (state.Keystrokes - state.Mistakes) / state.Keystrokes);

        var center =
            $@"
SESSION COMPLETE

RESULT SUMMARY:

Keystrokes : {state.Keystrokes}
Mistakes   : {state.Mistakes}
Accuracy   : {accuracy:F1}%

────────────────────────────

KEYWORD: BLIND TRAINING COMPLETE

Press any key to continue...
";

        _layout.Render(
            AsciiImage.Load("Assets/ASCII/ascii_neutral_left.txt"),
            center,
            AsciiImage.Load("Assets/ASCII/ascii_neutral_right.txt")
        );

        Console.ReadKey(true);
    }
}