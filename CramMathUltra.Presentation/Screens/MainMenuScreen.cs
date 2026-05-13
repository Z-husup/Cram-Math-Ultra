using CramMathUltra.Presentation.Core;

namespace CramMathUltra.Presentation.Screens;

public static class MainMenuScreen
{
    public static MenuAction Show()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("CRAM MATH ULTRA");
            Console.WriteLine();
            Console.WriteLine("1. Start Session");
            Console.WriteLine("2. Exit");
            Console.WriteLine();
            Console.Write("Select: ");

            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    return MenuAction.StartSession;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                case ConsoleKey.Escape:
                    return MenuAction.Exit;
            }
        }
    }
}