using CramMathUltra.Domain.Entities;
using CramMathUltra.Domain.Enums;
using CramMathUltra.Presentation.Screens;

namespace CramMathUltra.Presentation.Factories;

public static class SessionConfigurationFactory
{
    public static SessionConfiguration Create()
    {
        var modeMenu = new ModeMenuScreen();
        var diffMenu = new DifficultyMenuScreen();

        var mode = modeMenu.Show();
        var diff = diffMenu.Show();

        return new SessionConfiguration
        {
            Mode = mode,
            Difficulty = diff,
            MaxValue = diff switch
            {
                DifficultyLevel.Easy => 10,
                DifficultyLevel.Medium => 100,
                DifficultyLevel.Hard => 1000,
                _ => 10
            },
            QuestionCount = 10
        };
    }
}