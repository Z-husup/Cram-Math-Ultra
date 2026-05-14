using CramMathUltra.Presentation.Core;
using CramMathUltra.Presentation.Factories;

namespace CramMathUltra.Presentation.Screens;

public class MenuScreen
{
    private readonly Layout3Column _layout = new();

    private readonly string _center;

    public MenuScreen()
    {
        _center =
            @"
Use number keys on keyboard:

1. Start Session
2. Exit














Cram Math Ultra - is a fan-made 
console pretraining for 
3D Math Ultra, designed to 
help players build the math 
skills needed to start the 
game with ease.
";
    }

    public MenuAction Show()
    {
        while (true)
        {
            Console.Clear();

            _layout.Render(
                AsciiImage.Load("Assets/ASCII/ascii_neutral_left.txt"),
                _center,
                AsciiImage.Load("Assets/ASCII/ascii_neutral_right.txt")
            );

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                return MenuAction.StartSession;

            if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2 || key.Key == ConsoleKey.Escape)
                return MenuAction.Exit;
        }
    }
}