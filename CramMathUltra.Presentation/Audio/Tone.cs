namespace CramMathUltra.Presentation.Audio;

public class Tone
{
    public Note Note { get; }
    public int Duration { get; }

    public Tone(Note note, int duration)
    {
        Note = note;
        Duration = duration;
    }
}