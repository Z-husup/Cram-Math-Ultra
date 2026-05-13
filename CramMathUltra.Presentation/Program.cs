using CramMathUltra.Application.Abstractions;
using CramMathUltra.Domain.Entities;
using CramMathUltra.Presentation.CLI.Menu;
using CramMathUltra.Presentation.CLI.Rendering;
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
