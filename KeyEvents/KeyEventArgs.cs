using System;
using System.ComponentModel;


namespace ConsoleGame.KeyEvents
{
    public class KeyEventArgs : HandledEventArgs
    {
        // нажатая кнопка
        public ConsoleKeyInfo Key;

        public KeyEventArgs(ConsoleKeyInfo key)
        {
            Key = key;
        }
    }
}
