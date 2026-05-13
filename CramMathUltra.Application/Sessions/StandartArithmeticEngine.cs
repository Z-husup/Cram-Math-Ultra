using CramMathUltra.Application.Abstractions;
using CramMathUltra.Domain.Entities;

namespace CramMathUltra.Application.Sessions;

public class StandardArithmeticEngine : ISessionEngine
{
    private readonly ITaskGenerator _generator;
    private readonly SessionConfiguration _configuration;
    private readonly IInputHandler _inputHandler;

    public StandardArithmeticEngine(
        ITaskGenerator generator,
        SessionConfiguration configuration,
        IInputHandler inputHandler)
    {
        _generator = generator;
        _configuration = configuration;
        _inputHandler = inputHandler;
    }

    public Task<TrainingResult> RunAsync()
    {
        var result = new TrainingResult();

        for (int i = 0; i < _configuration.QuestionCount; i++)
        {
            Console.Clear();

            var problem = _generator.Generate();

            Console.WriteLine(
                $"Question {i + 1}/{_configuration.QuestionCount}");

            while (true)
            {
                Console.SetCursorPosition(0, 2);

                Console.Write(
                    $"{problem.Expression} = ");

                int answer =
                    _inputHandler.ReadNumber(
                        problem.AnswerLength);

                result.TotalQuestions++;

                if (answer == problem.CorrectAnswer)
                {
                    result.CorrectAnswers++;

                    Console.WriteLine();
                    Console.WriteLine("Correct!");

                    Thread.Sleep(500);

                    break;
                }

                Console.WriteLine();
                Console.WriteLine("Wrong!");

                Thread.Sleep(500);

                Console.SetCursorPosition(0, 2);

                Console.Write(
                    new string(' ', Console.WindowWidth));

                Console.SetCursorPosition(0, 2);
            }
        }

        return Task.FromResult(result);
    }
}