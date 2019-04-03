using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Music
{
    public class NoteService
    {
        public readonly Note[] Tone3 = new Note[]
        {
            new Note("Do",   261),
            new Note("Do#",  277),
            new Note("Re",   293),
            new Note("Re#",  311), 
            new Note("Mi",   329),
            new Note("Fa",   349),
            new Note("Fa#",  369),
            new Note("Sol",  391),
            new Note("Sol#", 415),
            new Note("La",   440),
            new Note("La#",  466),
            new Note("Ti",   493)
        };

        public readonly Note[] Tone4 = new Note[]
        {
            new Note("Do",   523),
            new Note("Do#",  554),
            new Note("Re",   587),
            new Note("Re#",  622),
            new Note("Mi",   659),
            new Note("Fa",   698),
            new Note("Fa#",  739),
            new Note("Sol",  783),
            new Note("Sol#", 830),
            new Note("La",   880),
            new Note("La#",  932),
            new Note("Ti",   987)
        };
    }
}
