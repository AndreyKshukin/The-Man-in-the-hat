using System;
using System.Threading;
using ConsoleGame.Music;

namespace ConsoleGame.Menu
{
    public class MainMenu
    {
        MusicMenu _music = new MusicMenu();
        private string[] _logo = new string[]
        {
            "                                                                                                                                          ",
            "████████ ██   ██ ██████       ███    ███  █████  ███   ██       ████ ███   ██       ████████ ██   ██ ██████       ██   ██  █████  ████████",
            "   ██    ██   ██ ██           ████  ████ ██   ██ ████  ██        ██  ████  ██          ██    ██   ██ ██           ██   ██ ██   ██    ██   ",
            "   ██    ███████ ██████       ██ ████ ██ ██   ██ ██ ██ ██        ██  ██ ██ ██          ██    ███████ ██████       ███████ ██   ██    ██   ",
            "   ██    ██   ██ ██           ██  ██  ██ ███████ ██  ████        ██  ██  ████          ██    ██   ██ ██           ██   ██ ███████    ██   ",
            "   ██    ██   ██ ██████       ██      ██ ██   ██ ██   ███       ████ ██   ███          ██    ██   ██ ██████       ██   ██ ██   ██    ██   "
        };

        public void DrawLogo()
        {
            int time = 0;
            int size_y = _logo.Length;
            for (int i = 0; i < 17; i++)
            {
                int pos_y = (i >= size_y)?  size_y - 1: i;

                for (int j = pos_y; j >= 0; j--)
                {
                    Console.SetCursorPosition(6, i - j);
                    Console.Write(_logo[size_y - 1 - j]);
                }

                Thread.Sleep(50 + time);
                time += 15;
            }
        }

        public void PlayMusic()
        {
            _music.PlayMusic();
        }
    }
}
