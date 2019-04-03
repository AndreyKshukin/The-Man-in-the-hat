using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Music
{
    public struct Note
    {
        public readonly string Name;
        public readonly int Frequency;

        public Note(string nameNote, int frequency)
        {
            Name = nameNote;
            Frequency = frequency;
        }
    }
}
