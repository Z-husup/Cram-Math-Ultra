using NAudio.Wave;

public static class AudioManager
{
    private static WaveOutEvent? _output;
    private static AudioFileReader? _reader;

    public static void PlayLoop(string path)
    {
        Stop();

        var fullPath = Path.Combine(AppContext.BaseDirectory, path);

        _reader = new AudioFileReader(fullPath);
        _output = new WaveOutEvent();

        _output.Init(_reader);
        _output.Play();

        _output.PlaybackStopped += (_, _) =>
        {
            _reader.Position = 0;
            _output.Play();
        };
    }

    public static void Stop()
    {
        _output?.Stop();
        _output?.Dispose();
        _reader?.Dispose();

        _output = null;
        _reader = null;
    }
}