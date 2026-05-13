using CramMathUltra.Application.Sessions;
using CramMathUltra.Presentation.Core;
using CramMathUltra.Presentation.Factories;

namespace CramMathUltra.Presentation.Screens;

public class SessionUI
{
    private readonly Layout3Column _layout = new();
    private readonly SessionController _controller;

    public SessionUI(SessionController controller)
    {
        _controller = controller;
    }

    public void Run()
    {
        var state = _controller.Start();

        while (true)
        {
            Console.Clear();

            Render(state);

            if (state.IsFinished)
                break;

            MoveCursorToAnswerPosition();

            var input =
                ReadInput(state.ExpectedAnswerLength);

            state = _controller.Step(input);
        }
    }

    private void Render(CramMathUltra.Application.Models.GameState state)
    {
        var ui =
            state.IsCorrect ? UiState.Correct :
            state.IsWrong ? UiState.Wrong :
            UiState.Neutral;

        _layout.Render(
            AsciiFactory.Left(ui),
            Center(state),
            AsciiFactory.Right(ui)
        );
    }

    private string Center(CramMathUltra.Application.Models.GameState state)
    {
        return $@"
CRAM MATH ULTRA

{state.CurrentQuestion}

Correct: {state.Correct}
Wrong:   {state.Wrong}

Answer:
";
    }

    private void MoveCursorToAnswerPosition()
    {
        int centerColumnStart = 50;

        int answerLine = 9;

        int inputOffset = 9;

        Console.SetCursorPosition(
            centerColumnStart + inputOffset,
            answerLine);
    }

    private string ReadInput(int expectedLength)
    {
        string input = "";

        while (true)
        {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
                throw new OperationCanceledException();

            if (key.Key == ConsoleKey.Backspace)
            {
                if (input.Length > 0)
                {
                    input = input[..^1];

                    Console.Write("\b \b");
                }

                continue;
            }

            if (!char.IsDigit(key.KeyChar))
                continue;

            input += key.KeyChar;

            Console.Write(key.KeyChar);

            if (input.Length >= expectedLength)
            {
                return input;
            }
        }
    }
}