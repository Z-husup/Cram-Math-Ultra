using CramMathUltra.Presentation.Core;

namespace CramMathUltra.Presentation.Screens;

public class IntroScreen
{
    private readonly string[] _frames;

    public IntroScreen()
    {
        _frames =
        [
            AsciiImage.LoadIntro("Assets/ASCII/intro/frame1.txt"),
            AsciiImage.LoadIntro("Assets/ASCII/intro/frame2.txt"),
            AsciiImage.LoadIntro("Assets/ASCII/intro/frame3.txt"),
            AsciiImage.LoadIntro("Assets/ASCII/intro/frame4.txt"),
            AsciiImage.LoadIntro("Assets/ASCII/intro/frame5.txt"),
            AsciiImage.LoadIntro("Assets/ASCII/intro/frame6.txt"),
            AsciiImage.LoadIntro("Assets/ASCII/intro/frame4.txt"),
            AsciiImage.LoadIntro("Assets/ASCII/intro/frame5.txt")
        ];
    }

    public void Play()
    {
        foreach (var frame in _frames)
        {
            Console.Clear();

            Console.SetCursorPosition(0, 0);

            Console.Write(frame);

            Thread.Sleep(444);
        }

        Console.Clear();
    }
}