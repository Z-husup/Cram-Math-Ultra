using CramMathUltra.Presentation.ASCII;
using CramMathUltra.Presentation.CLI.Menu;
using CramMathUltra.Presentation.CLI.Rendering;

namespace CramMathUltra.Presentation.CLI.Screens;

public static class MenuScreen
{
    public static int Show(string title, List<MenuOption> options)
    {
        Console.Clear();

        AsciiHeader.Draw(title);

        foreach (var option in options)
        {
            AsciiBox.Draw(option.Key.ToString(), option.Title);
        }

        Console.WriteLine();
        Console.Write(ConsoleLayout.CenterLine("Select: ", ConsoleLayout.GetWidth()));

        while (true)
        {
            var key = Console.ReadKey(true);

            if (char.IsDigit(key.KeyChar))
            {
                int value = int.Parse(key.KeyChar.ToString());

                if (options.Any(o => o.Key == value))
                {
                    Console.WriteLine(value);
                    return value;
                }
            }
        }
    }
}