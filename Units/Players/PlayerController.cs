using System;
using ConsoleGame.Generic;
using ConsoleGame.KeyEvents;

namespace ConsoleGame.Units.Players
{
    public class PlayerController
    {
        private Player _player;
        private KeyEvent _moveCtrl = new KeyEvent();

        public PlayerController(Player player)
        {
            _player = player;
            InitKeyEvents();
        }

        private void InitKeyEvents()
        {
            _moveCtrl.KeyPress += (sender, e) =>
            {
                if (e.Key.Key == ConsoleKey.LeftArrow)
                    _player.MoveLeft();

                else if (e.Key.Key == ConsoleKey.RightArrow)
                    _player.MoveRight();
            };

            _moveCtrl.KeyPress += (sender, e) =>
            {
                if (e.Key.Key == ConsoleKey.UpArrow)
                    _player.Jump();
            };
        }

        public void GetKeyboardInput()
        {
            var input = Console.ReadKey(true);

            if (_player.IsGrounded)
            {
                _moveCtrl.OnKeyPress(input);
                _player.CoolDownStart();
            }
        }

        public void Move()
        {
            if (!_player.IsGrounded)
                _player.Falls();
        }
    }
}
