namespace CramMathUltra.Presentation.Core;

public class Layout3Column
{
    private const int ColumnWidth = 40;

    public void Render(string left, string center, string right)
    {
        if (!ConsoleSetup.IsValid())
            return;

        var l = Split(left);
        var c = Split(center);
        var r = Split(right);

        int max = Math.Max(l.Length, Math.Max(c.Length, r.Length));

        for (int i = 0; i < max; i++)
        {
            Console.Write(Pad(Get(l, i)));
            Console.Write(PadCenter(Get(c, i)));
            Console.WriteLine(Pad(Get(r, i)));
        }
    }

    private static string[] Split(string text)
        => text.Replace("\r", "").Split('\n');

    private static string Get(string[] arr, int i)
        => i < arr.Length ? arr[i] : "";

    private static string Pad(string s)
        => s.Length > ColumnWidth ? s[..ColumnWidth] : s.PadRight(ColumnWidth);

    private static string PadCenter(string s)
    {
        if (s.Length > ColumnWidth)
            s = s[..ColumnWidth];

        int left = (ColumnWidth - s.Length) / 2;

        return new string(' ', left) + s.PadRight(ColumnWidth - left);
    }
}