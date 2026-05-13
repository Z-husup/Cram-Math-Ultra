namespace CramMathUltra.Application.Abstractions;

public interface ISessionRenderer
{
    void ShowQuestion(string expression, int index, int total);
    void ShowInputPrompt(string text);
    void ShowCorrect();
    void ShowWrong(string info);
}