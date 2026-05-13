namespace CramMathUltra.Presentation.Core;

public static class AsciiImage
{
    private const int DefaultWidth = 40;
    private const int DefaultHeight = 28;

    private const int IntroWidth = 120;
    private const int IntroHeight = 28;

    public static string Load(string path)
    {
        return LoadInternal(
            path,
            DefaultWidth,
            DefaultHeight);
    }

    public static string LoadIntro(string path)
    {
        return LoadInternal(
            path,
            IntroWidth,
            IntroHeight);
    }

    private static string LoadInternal(
        string path,
        int maxWidth,
        int maxHeight)
    {
        var fullPath =
            Path.Combine(AppContext.BaseDirectory, path);

        if (!File.Exists(fullPath))
            return $"[Missing ASCII: {path}]";

        var text = File.ReadAllText(fullPath);

        var lines =
            text.Replace("\r", "")
                .Split('\n')
                .Take(maxHeight)
                .Select(line => Clamp(line, maxWidth));

        return string.Join('\n', lines);
    }

    private static string Clamp(
        string line,
        int width)
    {
        if (line.Length <= width)
            return line;

        return line[..width];
    }
}