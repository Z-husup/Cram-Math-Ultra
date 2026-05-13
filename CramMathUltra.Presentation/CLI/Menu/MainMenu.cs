namespace CramMathUltra.CLI.Menu;

public static class MainMenu
{
    public static int Show()
    {
        Console.Clear();

        Console.WriteLine("=== Cram Math Ultra ===");
        Console.WriteLine();

        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("0. Exit");

        Console.WriteLine();
        Console.Write("Select: ");

        while (true)
        {
            var key = Console.ReadKey(true);

            if (char.IsDigit(key.KeyChar))
            {
                int value = int.Parse(key.KeyChar.ToString());

                if (value >= 0 && value <= 4)
                {
                    Console.WriteLine(value);

                    return value;
                }
            }
        }
    }
}