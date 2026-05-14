using CramMathUltra.Presentation.Audio;

namespace CramMathUltra.Presentation.Soundtracks;

public static class IntroSoundtrack
{
    public static List<Tone> Create()
    {
        return
        [
            // Measure 1
            new(Note.F3, 444),
            new(Note.AS3, 444),
            new(Note.C4, 444),
            new(Note.DS4, 222),
            new(Note.F4, 222),
            new(Note.G4, 222),
            new(Note.G4, 222),
            new(Note.AS4, 222),
            new(Note.DS4, 222),
            new(Note.C5, 222),
            new(Note.G4, 444),
            new(Note.F3, 444)
        ];
    }
}