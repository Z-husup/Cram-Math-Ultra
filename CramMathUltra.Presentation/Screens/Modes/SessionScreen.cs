using CramMathUltra.Presentation.Core;
using CramMathUltra.Presentation.Factories;

namespace CramMathUltra.Presentation.Screens.Modes;

public class SessionScreen : Screen
{
    public override UiState Render(ScreenContext context)
    {
        Console.Clear();

        string center =
            $@"
SOLVE:

{context.CenterText}

Answer below:
";

        UiState state =
            context.IsCorrect ? UiState.Correct :
            context.IsWrong ? UiState.Wrong :
            UiState.Neutral;

        Layout.Render(
            AsciiFactory.Left(state),
            center,
            AsciiFactory.Right(state)
        );

        return state;
    }
}