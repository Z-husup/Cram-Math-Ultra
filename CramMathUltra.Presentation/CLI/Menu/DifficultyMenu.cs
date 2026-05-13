namespace CramMathUltra.CLI.Menu;

public static class DifficultyMenu
{
    public static int Show()
    {
        Console.Clear();

        Console.WriteLine("=== Difficulty ===");
        Console.WriteLine();

        Console.WriteLine("1. Up to 10");
        Console.WriteLine("2. Up to 100");
        Console.WriteLine("3. Up to 1000");

        Console.WriteLine();
        Console.Write("Select: ");

        while (true)
        {
            var key = Console.ReadKey(true);

            switch (key.KeyChar)
            {
                case '1':
                    return 10;

                case '2':
                    return 100;

                case '3':
                    return 1000;
            }
        }
    }
}