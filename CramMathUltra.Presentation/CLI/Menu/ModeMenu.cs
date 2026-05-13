namespace CramMathUltra.CLI.Menu;

public static class ModeMenu
{
    public static int Show()
    {
        Console.Clear();

        Console.WriteLine("=== Select Mode ===");
        Console.WriteLine();

        Console.WriteLine("1. Standard");
        Console.WriteLine("2. Flash");
        Console.WriteLine("3. Which Operation");
        Console.WriteLine("4. Chain Memory");

        Console.WriteLine();
        Console.Write("Select: ");

        while (true)
        {
            var key = Console.ReadKey(true);

            if (char.IsDigit(key.KeyChar))
            {
                int value = int.Parse(key.KeyChar.ToString());

                if (value >= 1 && value <= 4)
                {
                    Console.WriteLine(value);

                    return value;
                }
            }
        }
    }
}