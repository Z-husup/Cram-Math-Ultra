using CramMathUltra.Presentation.Core;

namespace CramMathUltra.Presentation.Factories;

public static class AsciiFactory
{
    private static string BasePath =>
        Path.Combine(AppContext.BaseDirectory, "Assets", "ASCII");

    public static string Left(UiState state)
    {
        return state switch
        {
            UiState.Correct => AsciiImage.Load("Assets/ASCII/ascii_correct_left.txt"),
            UiState.Wrong => AsciiImage.Load("Assets/ASCII/ascii_wrong_left.txt"),
            _ => AsciiImage.Load("Assets/ASCII/ascii_neutral_left.txt")
        };
    }

    public static string Right(UiState state)
    {
        return state switch
        {
            UiState.Correct => AsciiImage.Load("Assets/ASCII/ascii_correct_right.txt"),
            UiState.Wrong => AsciiImage.Load("Assets/ASCII/ascii_wrong_right.txt"),
            _ => AsciiImage.Load("Assets/ASCII/ascii_neutral_right.txt")
        };
    }

    private static string Load(string fileName)
    {
        var path = Path.Combine(BasePath, fileName);

        if (!File.Exists(path))
            return $"[MISSING: {path}]";

        return File.ReadAllText(path);
    }
}