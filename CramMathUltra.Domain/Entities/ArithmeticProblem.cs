namespace CramMathUltra.Domain.Entities;

public class ArithmeticProblem
{
    public MathExpression Expression { get; }

    public ArithmeticProblem(MathExpression expression)
    {
        Expression = expression;
    }

    public int CorrectAnswer => Expression.Evaluate();

    public int AnswerLength =>
        CorrectAnswer.ToString().Length;
}