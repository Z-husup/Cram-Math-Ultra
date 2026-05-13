using CramMathUltra.ASCII;
using CramMathUltra.CLI.Menu;

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
        Console.Write("Select: ");

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