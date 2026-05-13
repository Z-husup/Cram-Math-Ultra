using CramMathUltra.Application.Abstractions;

namespace CramMathUltra.Presentation.CLI.Input;

public class ConsoleRealtimeInputHandler : IInputHandler
{
    public int ReadNumber(int expectedLength)
    {
        while (true)
        {
            string current = "";

            while (current.Length < expectedLength)
            {
                var key = Console.ReadKey(true);

                if (!char.IsDigit(key.KeyChar))
                    continue;

                current += key.KeyChar;

                Console.Write(key.KeyChar);
            }

            if (int.TryParse(current, out int result))
                return result;
        }
    }
}