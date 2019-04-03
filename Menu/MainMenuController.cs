using System;
using ConsoleGame.Generic;
using ConsoleGame.Scenes;

namespace ConsoleGame.Menu
{
    public class MainMenuController : Controller
    {
        protected override void InitKeyEvents()
        {
            moveCtrl.KeyPress += (sender, e) =>
            {
            };
        }

        public override void GetKeyboardInput()
        {
            var input = Console.ReadKey();
            moveCtrl.OnKeyPress(input);
        }
    }
}
