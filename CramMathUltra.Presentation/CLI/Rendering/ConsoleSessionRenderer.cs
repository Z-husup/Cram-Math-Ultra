using CramMathUltra.Application.Abstractions;
using CramMathUltra.Presentation.CLI.Screens;

namespace CramMathUltra.Presentation.CLI.Rendering;

public class ConsoleSessionRenderer : ISessionRenderer
{
    public void ShowQuestion(string expression, int index, int total)
    {
        SessionScreen.DrawQuestion(expression, index, total);
    }

    public void ShowCorrect()
    {
        SessionScreen.ShowCorrect();
    }

    public void ShowWrong(int correctAnswer)
    {
        SessionScreen.ShowWrong(correctAnswer);
    }
}