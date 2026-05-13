using CramMathUltra.Application.Abstractions;

namespace CramMathUltra.Presentation.CLI.Input;

public class ConsoleRealtimeInputHandler : IInputHandler
{
    public int ReadNumber(int expectedLength)
    {
        string input = "";

        while (true)
        {
            var key = Console.ReadKey(true);

            // BACKSPACE support
            if (key.Key == ConsoleKey.Backspace)
            {
                if (input.Length > 0)
                {
                    input = input[..^1];

                    // remove last char visually
                    Console.Write("\b \b");
                }

                continue;
            }

            // accept only digits
            if (!char.IsDigit(key.KeyChar))
                continue;

            input += key.KeyChar;
            Console.Write(key.KeyChar);

            // auto-submit when full
            if (input.Length == expectedLength)
            {
                Console.WriteLine();
                return int.Parse(input);
            }
        }
    }
}