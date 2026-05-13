using CramMathUltra.Application.Abstractions;
using CramMathUltra.Application.Models;

namespace CramMathUltra.Application.Engines;

public class SessionEngine : IGameEngine
{
    private readonly Random _random = new();

    private readonly GameState _state = new();

    private int _a;
    private int _b;
    private int _answer;

    public GameState Start()
    {
        Generate();

        return _state;
    }

    public GameState ProcessInput(string input)
    {
        if (!int.TryParse(input, out int value))
            return _state;

        if (value == _answer)
        {
            _state.Correct++;
            _state.IsCorrect = true;
            _state.IsWrong = false;
        }
        else
        {
            _state.Wrong++;
            _state.IsWrong = true;
            _state.IsCorrect = false;
        }

        Generate();

        return _state;
    }

    private void Generate()
    {
        _a = _random.Next(1, 100);
        _b = _random.Next(1, 100);

        _answer = _a + _b;

        _state.CurrentQuestion = $"{_a} + {_b}";
        _state.ExpectedAnswerLength = _answer.ToString().Length;
    }
}