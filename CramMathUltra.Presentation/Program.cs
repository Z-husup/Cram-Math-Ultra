using CramMathUltra.Application.Abstractions;
using CramMathUltra.CLI.Menu;
using CramMathUltra.CLI.Rendering;
using CramMathUltra.Domain.Entities;
using CramMathUltra.Presentation.CLI.Screens;
using CramMathUltra.Presentation.Factories;

ISessionEngineFactory engineFactory =
    new SessionEngineFactory();

IntroScreen.Show();

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

    ISessionEngine engine =
        engineFactory.Create(configuration);

    var result = await engine.RunAsync();

    ResultRenderer.Render(result);
}