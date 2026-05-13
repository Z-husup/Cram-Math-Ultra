namespace CramMathUltra.Presentation.Core;

public abstract class Screen
{
    protected readonly Layout3Column Layout = new();

    public abstract UiState Render(ScreenContext context);
}