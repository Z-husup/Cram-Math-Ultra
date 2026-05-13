using CramMathUltra.Application.Abstractions;
using CramMathUltra.Domain.Entities;

namespace CramMathUltra.Application.Sessions;

public class StandardArithmeticEngine : ISessionEngine
{
    private readonly ITaskGenerator _generator;
    private readonly SessionConfiguration _configuration;
    private readonly IInputHandler _inputHandler;
    private readonly ISessionRenderer _renderer;

    public StandardArithmeticEngine(
        ITaskGenerator generator,
        SessionConfiguration configuration,
        IInputHandler inputHandler,
        ISessionRenderer renderer)
    {
        _generator = generator;
        _configuration = configuration;
        _inputHandler = inputHandler;
        _renderer = renderer;
    }
    
    public Task<TrainingResult> RunAsync()
    {
        for (int i = 0; i < _configuration.QuestionCount; i++)
        {
            var problem = _generator.Generate();

            _renderer.ShowQuestion(
                problem.Expression.ToString(),
                i + 1,
                _configuration.QuestionCount);

            _renderer.ShowInputPrompt(
                $"{problem.Expression} = ");

            while (true)
            {
                int answer =
                    _inputHandler.ReadNumber(problem.AnswerLength);

                if (answer == problem.CorrectAnswer)
                {
                    _renderer.ShowCorrect();
                    break;
                }

                _renderer.ShowWrong("Try again");
            }
        }

        return Task.FromResult(new TrainingResult());
    }
}