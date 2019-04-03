namespace ConsoleGame.Music
{
    public class Music
    {
        public readonly NoteService Notes;
        public float Temp { get; protected set; }

        public virtual void PlayMusic()
        {
        }

        protected int NoteLength(float length)
        {
            int noteLength = 0;

            noteLength = (int)(60000 / Temp * length);
            return noteLength;
        }
    }
}