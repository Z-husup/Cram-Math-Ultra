using CramMathUltra.Application.Models;
using CramMathUltra.Application.Sessions;
using CramMathUltra.Domain.Enums;
using CramMathUltra.Presentation.Audio;
using CramMathUltra.Presentation.Core;
using CramMathUltra.Presentation.Factories;
using CramMathUltra.Presentation.Input;
using CramMathUltra.Presentation.Screens.Modes;

namespace CramMathUltra.Presentation.Screens;

public class SessionUI
{
    private readonly Layout3Column _layout = new();
    private readonly SessionController _controller;

    private readonly ConsoleInputHandler _input = new();
    private readonly TableRenderer _table = new();
    private readonly TypingRenderer _typing = new();

    public SessionUI(SessionController controller)
    {
        _controller = controller;
    }

    public void Run()
    {
        var state = _controller.Start();

        new ModeIntroScreen().Show(state.Mode);

        while (true)
        {
            Console.Clear();

            Render(state);

            if (state.IsFinished)
                break;

            Console.SetCursorPosition(60, 24);

            var input = _input.ReadNumber(state.ExpectedAnswerLength);

            state = _controller.Step(input);
        }
    }

    private void Render(GameState state)
    {
        var ui =
            state.IsCorrect ? UiState.Correct :
            state.IsWrong ? UiState.Wrong :
            UiState.Neutral;

        if (state.IsCorrect) SoundEffects.Correct();
        if (state.IsWrong) SoundEffects.Wrong();

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
            TrainingModeType.TableFill => _table.Render(state),
            TrainingModeType.TypingPractice => _typing.Render(state),
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
}