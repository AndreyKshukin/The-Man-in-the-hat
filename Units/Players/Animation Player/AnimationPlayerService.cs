using ConsoleGame.Generic;

namespace ConsoleGame.Units.Players.Animation_Player
{
    public class AnimationPlayerService
    {
        private Player _player;
        private Animation _jump;
        private Animation _runLeft;
        private Animation _runRight;

        private Animation _wait;

        public AnimationPlayerService(Player player)
        {
            _player = player;
            CreateRunLeftAnimation();
            CreateRunRightAnimation();
            CreateJumpAnimation();
            _player.AnimationPlayer = _jump;
        }

        public void JumpAnimation()
        {
            _player.AnimationPlayer.ClearPosition();
            _player.AnimationPlayer = _jump;
        }

        public void RunLeftAnimation()
        {
            _player.AnimationPlayer.ClearPosition();
            _player.AnimationPlayer = _runLeft;
        }

        public void RunRightAnimation()
        {
            _player.AnimationPlayer.ClearPosition();
            _player.AnimationPlayer = _runRight;
        }

        private void CreateRunLeftAnimation()
        {
            string[] str = new string[4];
            str[0] = Resources.PlayerRunLeft1.Replace("\r\n", "");
            str[1] = Resources.PlayerRunLeft2.Replace("\r\n", "");
            str[2] = Resources.PlayerRunLeft3.Replace("\r\n", "");
            str[3] = Resources.PlayerRunLeft4.Replace("\r\n", "");
            _runLeft = new Animation(_player, str);
        }

        private void CreateRunRightAnimation()
        {
            string[] str = new string[4];
            str[0] = Resources.PlayerRunRight1.Replace("\r\n", "");
            str[1] = Resources.PlayerRunRight2.Replace("\r\n", "");
            str[2] = Resources.PlayerRunRight3.Replace("\r\n", "");
            str[3] = Resources.PlayerRunRight4.Replace("\r\n", "");
            _runRight = new Animation(_player, str);
        }

        private void CreateJumpAnimation()
        {
            string[] str = new string[1];
            str[0] = Resources.PlayerJump.Replace("\r\n", "");
            _jump = new Animation(_player, str);
        }
    }
}
