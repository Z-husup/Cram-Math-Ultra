using CramMathUltra.Application.Factories;
using CramMathUltra.Application.Sessions;
using CramMathUltra.Presentation.Audio;
using CramMathUltra.Presentation.Core;
using CramMathUltra.Presentation.Factories;
using CramMathUltra.Presentation.Screens;
using CramMathUltra.Presentation.Soundtracks;

internal class Program
{
    static void Main(string[] args)
    {
        ConsoleSetup.Init();
        
        SoundtrackPlayer.Play(
            IntroSoundtrack.Create());

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
                var config = SessionConfigurationFactory.Create();

                var engine = engineFactory.Create(config);
                var controller = new SessionController(engine, config);
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