using CramMathUltra.Application.Models;

namespace CramMathUltra.Application.Engines;

public class TableEngine : EngineBase
{
    private int[,] _table;
    private int _row;
    private int _col;
    private int _size = 5;

    public override GameState Start()
    {
        _table = new int[_size, _size];
        _row = 0;
        _col = 0;

        GenerateTable();

        UpdateState();

        return State;
    }

    public override GameState ProcessInput(string input)
    {
        if (!int.TryParse(input, out int value))
            return State;

        int correct =
            _table[_row, _col];

        if (value == correct)
        {
            State.Correct++;
            State.IsCorrect = true;
            State.IsWrong = false;
        }
        else
        {
            State.Wrong++;
            State.IsCorrect = false;
            State.IsWrong = true;
        }

        MoveNext();

        UpdateState();

        return State;
    }

    private void GenerateTable()
    {
        for (int r = 0; r < _size; r++)
        for (int c = 0; c < _size; c++)
            _table[r, c] = (r + 1) * (c + 1);
    }

    private void MoveNext()
    {
        _col++;

        if (_col >= _size)
        {
            _col = 0;
            _row++;
        }

        if (_row >= _size)
        {
            State.IsFinished = true;
        }
    }

    private void UpdateState()
    {
        if (_row < _size)
        {
            State.CurrentQuestion =
                $"Cell [{_row + 1},{_col + 1}] = ?";
        }
    }
}