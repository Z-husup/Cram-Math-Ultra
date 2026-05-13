using CramMathUltra.Presentation.Core;
using CramMathUltra.Presentation.Factories;

namespace CramMathUltra.Presentation.Screens;

public class ResultScreen : Screen
{
    public override UiState Render(ScreenContext context)
    {
        Console.Clear();

        var r = context.Result!;

        string center =
            $@"
RESULT

Total: {r.TotalQuestions}
Correct: {r.CorrectAnswers}
Wrong: {r.WrongAnswers}
Accuracy: {r.Accuracy:F2}%

Press any key...
";

        Layout.Render(
            AsciiFactory.Left(UiState.Neutral),
            center,
            AsciiFactory.Right(UiState.Neutral)
        );

        Console.ReadKey(true);

        return UiState.Exit;
    }
}