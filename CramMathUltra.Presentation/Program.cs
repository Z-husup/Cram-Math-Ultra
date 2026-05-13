using CramMathUltra.Application.Abstractions;
using CramMathUltra.Application.Generators;
using CramMathUltra.Application.Sessions;
using CramMathUltra.CLI.Menu;
using CramMathUltra.CLI.Rendering;
using CramMathUltra.Domain.Entities;
using CramMathUltra.Factories;
using CramMathUltra.Presentation.Input;

while (true)
{
    int operationChoice = MainMenu.Show();

    if (operationChoice == 0)
        break;

    int modeChoice = ModeMenu.Show();

    int maxValue = DifficultyMenu.Show();

    SessionConfiguration configuration =
        SessionConfigurationFactory.Create(
            operationChoice,
            modeChoice,
            maxValue);

    ITaskGenerator generator =
        new RandomArithmeticGenerator(
            configuration.MaxValue,
            configuration.Operation);

    IInputHandler inputHandler =
        new ConsoleRealtimeInputHandler();

    ISessionEngine engine =
        new StandardArithmeticEngine(
            generator,
            configuration,
            inputHandler);

    var result = await engine.RunAsync();

    ResultRenderer.Render(result);
}