using CramMathUltra.Presentation.CLI.Screens;

namespace CramMathUltra.CLI.Menu;

public static class ModeMenu
{
    public static int Show()
    {
        return MenuScreen.Show(
            "SELECT MODE",
            new List<MenuOption>
            {
                new() { Key = 1, Title = "Standard" },
                new() { Key = 2, Title = "Flash Mode" },
                new() { Key = 3, Title = "Which Operation" },
                new() { Key = 4, Title = "Chain Memory" }
            });
    }
}