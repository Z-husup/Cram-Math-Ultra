using CramMathUltra.Application.Abstractions;

namespace CramMathUltra.Application.Sessions;

public class StandardArithmeticEngine : ISessionEngine
{
    private readonly ITaskGenerator _generator;

    public StandardArithmeticEngine(ITaskGenerator generator)
    {
        _generator = generator;
    }

    public Task RunAsync()
    {
        while (true)
        {
            Console.Clear();

            var problem = _generator.Generate();

            Console.Write($"{problem.Expression} = ");

            string? input = Console.ReadLine();

            if (input?.ToLower() == "exit")
                break;

            if (!int.TryParse(input, out int answer))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadKey();
                continue;
            }

            if (answer == problem.CorrectAnswer)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine(
                    $"Wrong. Correct answer: {problem.CorrectAnswer}");
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        return Task.CompletedTask;
    }
}