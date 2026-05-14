namespace CramMathUltra.Presentation.Input;

public class ConsoleInputHandler
{
    public string ReadNumber(int expectedLength)
    {
        string input = "";

        while (true)
        {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
                throw new OperationCanceledException();

            if (key.Key == ConsoleKey.Backspace)
            {
                if (input.Length > 0)
                {
                    input = input[..^1];
                    Console.Write("\b \b");
                }
                continue;
            }

            if (!char.IsDigit(key.KeyChar))
                continue;

            input += key.KeyChar;
            Console.Write(key.KeyChar);

            if (input.Length >= expectedLength)
            {
                Console.WriteLine();
                return input;
            }
        }
    }
}