using CramMathUltra.Application.Abstractions;
using CramMathUltra.Application.Models;
using CramMathUltra.Domain.Enums;

namespace CramMathUltra.Application.Engines;

public class TypingPracticeEngine : IGameEngine
{
    private readonly Random _random = new();
    private readonly GameState _state = new();
    private readonly DifficultyLevel _difficulty;

    public TypingPracticeEngine(DifficultyLevel difficulty)
    {
        _difficulty = difficulty;
    }

    public GameState Start()
    {
        _state.Mode = TrainingModeType.TypingPractice;
        Next();
        return _state;
    }

    public GameState ProcessInput(string input)
    {
        _state.Keystrokes++;

        if (input == _state.TypingTarget)
        {
            _state.Correct++;
            _state.IsCorrect = true;
            _state.IsWrong = false;
        }
        else
        {
            _state.Wrong++;
            _state.Mistakes++;
            _state.IsCorrect = false;
            _state.IsWrong = true;
        }

        Next();
        return _state;
    }

    private void Next()
    {
        int length = _difficulty switch
        {
            DifficultyLevel.Easy => 1,
            DifficultyLevel.Medium => _random.Next(2, 4),   // 2–3 digits
            DifficultyLevel.Hard => _random.Next(3, 6),     // 3–5 digits
            _ => 1
        };

        _state.TypingTarget = GenerateNumber(length);

        _state.CurrentQuestion = "TYPE EXACT NUMBER SEQUENCE";

        _state.ExpectedAnswerLength = length;
    }

    private string GenerateNumber(int length)
    {
        var result = new char[length];

        for (int i = 0; i < length; i++)
            result[i] = (char)('0' + _random.Next(0, 10));

        return new string(result);
    }
}