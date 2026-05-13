namespace CramMathUltra.Application.Abstractions;

public interface ISessionRenderer
{
    void ShowQuestion(string expression, int index, int total);
    void ShowCorrect();
    void ShowWrong(int correctAnswer);
}