using CramMathUltra.Application.Abstractions;
using CramMathUltra.Application.Models;
using CramMathUltra.Domain.Enums;

namespace CramMathUltra.Application.Engines;

public class TableFillEngine : IGameEngine
{
    private readonly Random _random = new();
    private readonly GameState _state = new();

    public GameState Start()
    {
        _state.Mode = TrainingModeType.TableFill;

        _state.TableSize = 10;

        PickNextCell();

        return _state;
    }

    public GameState ProcessInput(string input)
    {
        if (!int.TryParse(input, out var value))
            return _state;

        var correct = (_state.Row + 1) * (_state.Col + 1);

        if (value == correct)
        {
            _state.Correct++;
            _state.IsCorrect = true;
            _state.IsWrong = false;

            _state.TableSolved[_state.Row, _state.Col] = true;
        }
        else
        {
            _state.Wrong++;
            _state.IsWrong = true;
            _state.IsCorrect = false;
        }

        PickNextCell();

        return _state;
    }

    private void PickNextCell()
    {
        if (_state.TableSize == 10)
        {
            PickRandomCell(10);
            return;
        }

        PickCyclicCell(_state.TableSize);
    }

    private void PickRandomCell(int size)
    {
        _state.Row = _random.Next(0, size);
        _state.Col = _random.Next(0, size);

        SetQuestion();
    }

    private void PickCyclicCell(int size)
    {
        do
        {
            _state.Col++;

            if (_state.Col >= size)
            {
                _state.Col = 0;
                _state.Row++;
            }

            if (_state.Row >= size)
            {
                _state.Row = 0;
            }

        } while (_state.TableSolved[_state.Row, _state.Col] && HasUnsolved(size));

        SetQuestion();
    }

    private bool HasUnsolved(int size)
    {
        for (int r = 0; r < size; r++)
            for (int c = 0; c < size; c++)
                if (!_state.TableSolved[r, c])
                    return true;

        return false;
    }

    private void SetQuestion()
    {
        var a = _state.Row + 1;
        var b = _state.Col + 1;

        _state.CurrentQuestion = $"{a} × {b}";
        _state.ExpectedAnswerLength = (a * b).ToString().Length;
    }
}