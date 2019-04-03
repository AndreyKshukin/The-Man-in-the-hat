using System;

namespace ConsoleGame.Music
{
    public class MusicMenu : Music
    {
        public MusicMenu()
        {
            Temp = 120;
        }

        public override void PlayMusic()
        {
            Melody();
        }

        private void Melody()
        {
            float length = 0.5f;

            Console.Beep((int)Tone4.Mi_b, NoteLength(length));
            Console.Beep((int)Tone4.Do, NoteLength(length));
            Console.Beep((int)Tone3.Sol, NoteLength(length));

            Console.Beep((int)Tone4.Re, NoteLength(length));
            Console.Beep((int)Tone4.Do, NoteLength(length));
            Console.Beep((int)Tone3.Sol, NoteLength(length));

            Console.Beep((int)Tone4.Re, NoteLength(length * 1.5f));
            Console.Beep((int)Tone4.Do, NoteLength(length * 2));
            Console.Beep((int)Tone3.Fa, NoteLength(length * 3));
        }
    }
}
