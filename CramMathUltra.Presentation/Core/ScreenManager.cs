namespace CramMathUltra.Presentation.Core;

public class ScreenManager
{
    public UiState Show(Screen screen, ScreenContext context)
    {
        return screen.Render(context);
    }
}