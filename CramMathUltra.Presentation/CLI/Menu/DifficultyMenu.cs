using CramMathUltra.Presentation.CLI.Screens;

namespace CramMathUltra.Presentation.CLI.Menu;

public static class DifficultyMenu
{
    public static int Show()
    {
        int choice = MenuScreen.Show(
            "SELECT DIFFICULTY",
            new List<MenuOption>
            {
                new() { Key = 1, Title = "Up to 10" },
                new() { Key = 2, Title = "Up to 100" },
                new() { Key = 3, Title = "Up to 1000" }
            });

        return choice switch
        {
            1 => 10,
            2 => 100,
            3 => 1000,
            _ => 10
        };
    }
}