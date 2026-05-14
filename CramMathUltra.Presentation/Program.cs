using CramMathUltra.Application.Factories;
using CramMathUltra.Application.Sessions;
using CramMathUltra.Presentation.Core;
using CramMathUltra.Presentation.Screens;

internal class Program
{
    static void Main(string[] args)
    {
        ConsoleSetup.Init();
        
        // AudioManager.PlayLoop(
        //     "Assets/Audio/Soundtrack.wav");

        var intro = new IntroScreen();

        intro.Play();

        var engineFactory = new EngineFactory();
        var menu = new MenuScreen();

        while (true)
        {
            var action = menu.Show();

            if (action == MenuAction.Exit)
                break;

            try
            {
                var engine = engineFactory.Create();

                var controller = new SessionController(engine);

                var ui = new SessionUI(controller);

                ui.Run();
            }
            catch (OperationCanceledException)
            {
                continue;
            }
        }
    }
}