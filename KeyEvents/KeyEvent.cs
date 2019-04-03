using System;

namespace ConsoleGame.KeyEvents
{
    public class KeyEvent
    {
        public event EventHandler<KeyEventArgs> KeyPress;

        // метод запуска события
        public void OnKeyPress(ConsoleKeyInfo key)
        {
            KeyPress(this, new KeyEventArgs(key));
        }
    }
}
