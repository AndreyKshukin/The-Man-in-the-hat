using System.Threading;
using ConsoleGame.Masks;
using ConsoleGame.Physics;
using ConsoleGame.Units.Players;

namespace ConsoleGame.Scenes
{
    public class Level : Map
    {
        private readonly BoxCollider _collider;

        public SolidMask SolidMask;
        private Player _player;
        private PlayerController _playerController;

        public Level(string map) : base(map)
        {
            _collider = new BoxCollider();
            _player = new Player(10, 30, 5, 11, _collider);
            _playerController = new PlayerController(_player);
        }

        public override void RunGamePlay()
        {
            Thread MoveThread = new Thread(PlayerMove);
            MoveThread.Name = "Player movement";
            MoveThread.Start();

            Thread AnimationThread = new Thread(Animation);
            AnimationThread.Name = "Player animation";
            AnimationThread.Start();
            KeyboardInput();
        }

        private void Animation()
        {
            do
            {
                _player.AnimationPlayer.UpdateShape();
                Thread.Sleep(40);
            }
            while (true);
        }

        private void PlayerMove()
        {
            do
            {
                _playerController.Move();
                Thread.Sleep(25);
            }
            while (true);
        }

        private void KeyboardInput()
        {
            do
            {
                _playerController.GetKeyboardInput();
            }
            while (true);
        }
    }
}
