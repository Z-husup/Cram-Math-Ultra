using CramMathUltra.Application.Models;
using CramMathUltra.Application.Sessions;
using CramMathUltra.Domain.Enums;
using CramMathUltra.Presentation.Audio;
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

            MoveToInput();

            var input = ReadInput(state.ExpectedAnswerLength);

            state = _controller.Step(input);
        }
    }

    private void Render(GameState state)
    {
        var ui =
            state.IsCorrect ? UiState.Correct :
            state.IsWrong ? UiState.Wrong :
            UiState.Neutral;

        _layout.Render(
            AsciiFactory.Left(ui),
            BuildCenter(state),
            AsciiFactory.Right(ui)
        );
    }

    private string BuildCenter(GameState state)
    {
        return state.Mode switch
        {
            TrainingModeType.TableFill => BuildTable(state),
            _ => BuildStandard(state)
        };
    }

    private string BuildStandard(GameState state)
    {
        return $@"
CRAM MATH ULTRA

{state.CurrentQuestion}

Correct: {state.Correct}
Wrong:   {state.Wrong}

Answer:
";
    }

    private string BuildTable(GameState state)
    {
        int size = state.TableSize;

        var lines = new List<string>();

        for (int r = 0; r < size; r++)
        {
            var row = "";

            for (int c = 0; c < size; c++)
            {
                var value = (r + 1) * (c + 1);

                string cell;

                if (state.TableSolved[r, c])
                    cell = value.ToString().PadLeft(3);
                else if (r == state.Row && c == state.Col)
                    cell = " ? ".PadLeft(3);
                else
                    cell = " . ".PadLeft(3);

                row += cell + " ";
            }

            lines.Add(row);
        }

        return $@"
TABLE FILL ({size}x{size})

{state.CurrentQuestion}

{string.Join("\n", lines)}

Correct: {state.Correct}
Wrong:   {state.Wrong}

Answer:
";
    }

    private void MoveToInput()
    {
        Console.SetCursorPosition(60, 24);
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
                Console.WriteLine();
                return input;
            }
        }
    }
}