using CramMathUltra.Domain.Enums;

namespace CramMathUltra.Domain.Entities;

public class MathExpression
{
    public int Left { get; }
    public int Right { get; }
    public OperationType Operation { get; }

    public MathExpression(int left, int right, OperationType operation)
    {
        Left = left;
        Right = right;
        Operation = operation;
    }

    public int Evaluate()
    {
        return Operation switch
        {
            OperationType.Addition => Left + Right,
            OperationType.Subtraction => Left - Right,
            OperationType.Multiplication => Left * Right,
            OperationType.Division => Left / Right,
            _ => throw new InvalidOperationException("Unsupported operation.")
        };
    }

    public override string ToString()
    {
        return $"{Left} {GetSymbol()} {Right}";
    }

    private string GetSymbol()
    {
        return Operation switch
        {
            OperationType.Addition => "+",
            OperationType.Subtraction => "-",
            OperationType.Multiplication => "*",
            OperationType.Division => "/",
            _ => "?"
        };
    }
}