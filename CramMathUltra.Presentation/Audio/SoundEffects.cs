namespace CramMathUltra.Presentation.Audio;

public static class SoundEffects
{
    public static void Correct()
    {
        Task.Run(() =>
        {
            PlayTone(880, 35);
            PlayTone(1175, 60);
        });
    }

    public static void Wrong()
    {
        Task.Run(() =>
        {
            PlayTone(196, 140);
            PlayTone(147, 200);
        });
    }

    private static void PlayTone(int freq, int ms)
    {
        if (freq <= 0) return;
        Console.Beep(freq, ms);
    }
}