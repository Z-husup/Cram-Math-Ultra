using CramMathUltra.Application.Models;

namespace CramMathUltra.Presentation.Screens.Modes;

public class TypingRenderer
{
    public string Render(GameState state)
    {
        return $@"
BLIND TYPING MODE

Keystrokes : {state.Keystrokes}
Mistakes   : {state.Mistakes}
Accuracy   : {(state.Keystrokes == 0 ? 0 : (100.0 * (state.Keystrokes - state.Mistakes) / state.Keystrokes)):F1}%

Number to Type:
{state.TypingTarget}

Answer:
";
    }
}