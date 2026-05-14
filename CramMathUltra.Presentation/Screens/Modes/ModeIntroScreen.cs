using CramMathUltra.Domain.Enums;
using CramMathUltra.Presentation.Core;

namespace CramMathUltra.Presentation.Screens.Modes;

public class ModeIntroScreen
{
    private readonly Layout3Column _layout = new();

    public void Show(TrainingModeType mode)
    {
        Console.Clear();

        var center = mode switch
        {
            TrainingModeType.Standard => StandardIntro(),
            TrainingModeType.TableFill => TableIntro(),
            TrainingModeType.TypingPractice => TypingIntro(),
            _ => StandardIntro()
        };

        _layout.Render(
            AsciiImage.Load("Assets/ASCII/ascii_neutral_left.txt"),
            center,
            AsciiImage.Load("Assets/ASCII/ascii_neutral_right.txt")
        );

        Console.ReadKey(true);
    }

    private string StandardIntro()
    {
        return Wrap(@"
STANDARD MODE

You will solve simple math problems.

Just type the final answer when you are sure.

Try to stay accurate, speed will come later.

Press to continue ...
");
    }

    private string TableIntro()
    {
        return Wrap(@"
TABLE FILL MODE

You will build multiplication table step by step.

Only one cell is active at a time.

Fill it correctly and the table slowly completes itself.

Press to continue ...
");
    }

    private string TypingIntro()
    {
        return Wrap(@"
BLIND TYPING MODE

You will train typing without looking at keyboard.

Focus on feeling where keys are.

Try to keep rhythm and reduce mistakes.

Fingers guide:
1-0 number row is split across both hands.
Start slow, 
accuracy matters more than speed.

Press to continue ...
");
    }

    private string Wrap(string text)
    {
        var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var lines = new List<string>();
        var current = "";

        foreach (var w in words)
        {
            if ((current + " " + w).Trim().Length > 40)
            {
                lines.Add(current);
                current = w;
            }
            else
            {
                current = (current + " " + w).Trim();
            }
        }

        if (!string.IsNullOrWhiteSpace(current))
            lines.Add(current);

        return string.Join("\n", lines);
    }
}