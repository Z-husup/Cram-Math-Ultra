using System.Collections.Concurrent;

namespace CramMathUltra.Presentation.Audio;

public static class SoundtrackPlayer
{
    private static CancellationTokenSource? _cts;

    public static void PlayLoop(List<Tone> soundtrack)
    {
        Stop();

        _cts = new CancellationTokenSource();

        var token = _cts.Token;

        Task.Run(() =>
        {
            while (!token.IsCancellationRequested)
            {
                foreach (var tone in soundtrack)
                {
                    if (token.IsCancellationRequested)
                        break;

                    PlayTone(tone);
                }
            }
        }, token);
    }
    
    public static void Play(List<Tone> soundtrack)
    {
        Stop();

        _cts = new CancellationTokenSource();

        var token = _cts.Token;

        Task.Run(() =>
        {
            {
                foreach (var tone in soundtrack)
                {
                    if (token.IsCancellationRequested)
                        break;

                    PlayTone(tone);
                }
            }
        }, token);
    }

    public static void Stop()
    {
        if (_cts == null)
            return;

        _cts.Cancel();
        _cts.Dispose();

        _cts = null;
    }

    private static void PlayTone(Tone tone)
    {
        if (tone.Note == Note.Rest)
        {
            Thread.Sleep(tone.Duration);
            return;
        }

        Console.Beep((int)tone.Note, tone.Duration);
    }
}