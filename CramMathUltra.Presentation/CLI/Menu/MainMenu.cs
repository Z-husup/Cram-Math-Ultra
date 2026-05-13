using CramMathUltra.Presentation.CLI.Screens;

namespace CramMathUltra.Presentation.CLI.Menu;

public static class MainMenu
{
    public static int Show()
    {
        return MenuScreen.Show(
            "CRAM MATH ULTRA",
            new List<MenuOption>
            {
                new() { Key = 1, Title = "Addition" },
                new() { Key = 2, Title = "Subtraction" },
                new() { Key = 3, Title = "Multiplication" },
                new() { Key = 4, Title = "Division" },
                new() { Key = 0, Title = "Exit" }
            });
    }
}