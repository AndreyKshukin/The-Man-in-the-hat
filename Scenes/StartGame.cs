using System;
using System.Threading;
using ConsoleGame.Menu;

namespace ConsoleGame.Scenes
{
    public class StartGame : Map
    {
        private MainMenuController _menuController;
        private MainMenu _menu;

        private bool _working = true;

        public StartGame(string map) : base(map)
        {
            _menu = new MainMenu();
            _menuController = new MainMenuController();
            RunGamePlay();
        }

        public override void RunGamePlay()
        {
            Thread MusicThread = new Thread(PlayMusic);
            MusicThread.Name = "Music is playing";
            MusicThread.Start();

            _menu.DrawLogo();

            Thread AnimationThread = new Thread(Animation);
            AnimationThread.Name = "Menu animation";
            AnimationThread.Start();

            KeyboardInput();
        }

        private void Animation()
        {
            bool visibility = true;

            string str = "press the key for start the game";
            string strClean = "                                ";
            int pos_x = (Size_x - str.Length) / 2;

            do
            {
                Console.SetCursorPosition(pos_x, 31);

                if (visibility)
                    Console.Write(str);
                else
                    Console.Write(strClean);

                    Thread.Sleep(1000);
                visibility = !visibility;
            }
            while (_working);
            Console.Clear();
            Program.LevelMap = new Level(Resources.Level_1);
            Program.LevelMap.RunGamePlay();
        }

        public void PlayMusic()
        {
            _menu.PlayMusic();
        }

        private void KeyboardInput()
        {
            _menuController.GetKeyboardInput();
            _working = false;
        }
    }
}
